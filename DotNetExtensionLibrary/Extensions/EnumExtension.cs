using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace de.efsdev.DotNetExtensionLibrary.Extensions
{
    public static class EnumExtensions
    {
        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetName(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }

        public static bool IsValueInValues<TEnum>(this TEnum value, ICollection<TEnum> values)
        {
            return values.Contains(value);
        }
    }
}
