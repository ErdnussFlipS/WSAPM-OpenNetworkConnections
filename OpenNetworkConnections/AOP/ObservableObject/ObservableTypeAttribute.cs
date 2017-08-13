using ArxOne.MrAdvice.Advice;
using ArxOne.MrAdvice.Annotation;
using de.efsdev.wsapm.OpenNetworkConnections.Library;
using de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP
{
    [Priority(AspectPriority.ObservableType)]
    public abstract class ObservableTypeAttribute : Attribute, IPropertyAdvice
    {
        public void Advise(PropertyAdviceContext propertyContext)
        {
            var classType = propertyContext.TargetType;
            var propertyType = propertyContext.TargetProperty;

            if (!classType.IsSameOrSubclassOf(typeof(ObservableObject)))
            {
                throw new InvalidProgramException($"The Attribute {GetType().FullName} is not applicable to {classType.FullName}. {classType.FullName} must derived from {nameof(ObservableObject)}.");
            }

            // Getter
            if (propertyContext.IsGetter)
            {
                propertyContext.Proceed();
                return;
            }

            // Setter
            propertyContext.Proceed();
            (propertyContext.Target as ObservableObject).InvokePropertyChanged(propertyType.Name);
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ObservableObjectAttribute : ObservableTypeAttribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class ObservablePropertyAttribute : ObservableTypeAttribute { }
}
