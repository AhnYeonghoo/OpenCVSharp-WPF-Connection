using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Converters
{
    public class EnumDescriptionConverter<T> : EnumConverter
    {
        public EnumDescriptionConverter() : base(typeof(T))
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
            object value, Type destinationType)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi is null) return null;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length < 1)
            {
                return null;
            }
            else
            {
                string description = attributes[0].Description;
                return description;
                
                
            }
        }
    }
}
