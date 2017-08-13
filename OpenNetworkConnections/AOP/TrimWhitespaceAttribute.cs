using ArxOne.MrAdvice.Advice;
using ArxOne.MrAdvice.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP
{
    [AttributeUsage(AttributeTargets.Property)]
    [Priority(AspectPriority.ViewModelProxy)]
    public class TrimWhitespaceAttribute : Attribute, IPropertyAdvice
    {
        public void Advise(PropertyAdviceContext propertyContext)
        {
            var classType = propertyContext.TargetType;
            var targetProperty = propertyContext.TargetProperty;

            if (targetProperty.PropertyType != typeof(string))
            {
                throw new InvalidProgramException($"The Attribute {GetType().FullName} is not applicable to properties of type {typeof(string)}. Used for {targetProperty.Name} in {classType.FullName}");
            }

            // Is Getter or no String
            if (propertyContext.IsGetter)
            {
                propertyContext.Proceed();
                return;
            }

            // Setter
            propertyContext.Value = (propertyContext.Value as string).Trim();
            propertyContext.Proceed();
        }
    }
}
