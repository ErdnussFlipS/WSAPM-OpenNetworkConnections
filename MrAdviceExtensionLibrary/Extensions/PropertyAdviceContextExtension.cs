using ArxOne.MrAdvice.Advice;

namespace de.efsdev.MrAdviceExtensionLibrary.Extensions
{
    public static class PropertyAdviceContextExtension
    {
        public static object GetTargetPropertyValue(this PropertyAdviceContext context, object[] index = null)
        {
            return context.TargetProperty.GetValue(context.Target, index);
        }

        public static TType GetTargetPropertyValue<TType>(this PropertyAdviceContext context, object[] index = null)
        {
            return (TType)context.TargetProperty.GetValue(context.Target, index);
        }
    }
}
