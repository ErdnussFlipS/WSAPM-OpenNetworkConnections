using ArxOne.MrAdvice.Advice;
using System;

namespace de.efsdev.MrAdviceExtensionLibrary.Advice
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TrimWhitespaceAttribute : Attribute, IPropertyAdvice
    {
        public void Advise(PropertyAdviceContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var classType = context.TargetType;
            var targetProperty = context.TargetProperty;

            if (targetProperty.PropertyType != typeof(string))
            {
                throw new InvalidProgramException($"The Attribute {GetType().FullName} is not applicable to properties of type {typeof(string)}. Used for {targetProperty.Name} in {classType.FullName}");
            }

            // Is Getter or no String
            if (context.IsGetter)
            {
                context.Proceed();
                return;
            }

            // Setter
            context.Value = (context.Value as string).Trim();
            context.Proceed();
        }
    }
}
