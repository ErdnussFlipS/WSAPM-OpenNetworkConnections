using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.efsdev.DotNetExtensionLibrary.Extensions
{
    public static class MemberInfoExtension
    {
        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo, bool inherit = true)
        {
            var attributeType = typeof(TAttribute);
            return memberInfo.GetCustomAttributes(attributeType, inherit).Any();
        }

        public static TValue GetAttributeValue<TAttribute, TValue>(this MemberInfo memberInfo, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if (memberInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }

        public static object GetValue(this PropertyInfo property, object obj)
        {
            return property.GetValue(obj, null);
        }

        public static void SetValue(this PropertyInfo property, object obj, object value)
        {
            property.SetValue(obj, value, null);
        }
    }
}
