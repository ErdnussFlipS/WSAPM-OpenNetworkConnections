using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.DotNetExtensionLibrary.Attributes
{
    public class UnderlyingValueAttribute : Attribute
    {
        Type UnderlyingType { get; set; }
        object UnderlyingValue { get; set; }

        public UnderlyingValueAttribute(object underlyingValue)
        {
            if (underlyingValue == null)
            {
                throw new ArgumentNullException(nameof(underlyingValue));
            }

            UnderlyingType = underlyingValue?.GetType();
            UnderlyingValue = underlyingValue;
        }

        public TUnderlyingType GetUnderlyingValue<TUnderlyingType>()
        {
            if (!UnderlyingType.Equals(typeof(TUnderlyingType)))
            {
                throw new InvalidCastException($"{nameof(TUnderlyingType)} is not the type of the underlying value {UnderlyingType}");
            }

            return (TUnderlyingType)UnderlyingValue;
        }
    }
}
