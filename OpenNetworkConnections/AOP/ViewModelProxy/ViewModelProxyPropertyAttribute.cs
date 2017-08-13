using ArxOne.MrAdvice.Advice;
using ArxOne.MrAdvice.Annotation;
using de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy
{
    [AttributeUsage(AttributeTargets.Property)]
    [Priority(AspectPriority.ViewModelProxy)]
    public class ViewModelProxyPropertyAttribute : Attribute, IPropertyAdvice
    {
        public string PropertyName { get; set; }
        public string ProxyPropertyName { get; set; }

        public void Advise(PropertyAdviceContext propertyContext)
        {
            var classInstance = propertyContext.Target;
            var classType = propertyContext.TargetType;
            var propertyType = propertyContext.TargetProperty;

            if (!classType.HasProperty(PropertyName))
            {
                throw new InvalidProgramException($"The class {classType.FullName} doesn't have the property {PropertyName}.");
            }

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            var proxyPropertyName = ProxyPropertyName ?? propertyType.Name;
            var property = classType.GetProperty(PropertyName, bindingFlags);
            var proxyPropetyType = property.PropertyType;

            if (!proxyPropetyType.HasProperty(proxyPropertyName))
            {
                throw new InvalidProgramException($"The class {proxyPropetyType.FullName} of property {PropertyName} doesn't have the property {proxyPropertyName}.");
            }

            var propertyValue = property.GetValue(classInstance);
            var propertyOfProxyProperty = proxyPropetyType.GetProperty(proxyPropertyName, bindingFlags);
            
            // Getter
            if (propertyContext.IsGetter)
            {
                propertyContext.Proceed();
                propertyContext.ReturnValue = propertyOfProxyProperty.GetValue(propertyValue);
                return;
            }

            // Setter
            propertyOfProxyProperty.SetValue(propertyValue, propertyContext.Value);
            propertyContext.Proceed();
        }
    }
}
