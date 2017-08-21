using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.efsdev.DotNetExtensionLibrary.Extensions
{
    public static class TypeExtension
    {
        public static bool IsSameOrSubclassOf(this Type potentialDescendant, Type potentialBase)
        {
            return potentialDescendant == potentialBase || potentialDescendant.IsSubclassOf(potentialBase);
        }

        public static bool HasProperty(this Type type, string name)
        {
            return type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        public static bool HasField(this Type type, string name)
        {
            return type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        public static bool HasAttribute<TAttribute>(this Type type, bool inherit = true)
        {
            var attributeType = typeof(TAttribute);
            return type.GetCustomAttributes(attributeType, inherit).Any();
        }

        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if (type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }
    }
}
