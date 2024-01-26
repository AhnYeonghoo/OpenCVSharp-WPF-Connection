using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Converters;
using System.ComponentModel;

namespace Common.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter<ELockModelTime>))]
    public enum ELockModelTime
    {
        [Description("1분 후")]
        m1,
        [Description("2분 후")]
        m2,
        [Description("3분 후")]
        m3,
        [Description("5분 후")]
        m5,
        [Description("10분 후")]
        m10
    }
}
