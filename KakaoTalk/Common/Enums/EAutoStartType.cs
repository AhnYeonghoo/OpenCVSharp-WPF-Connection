using System;
using System.Collections.Generic;
using System.Linq;
using Common.Converters;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter<EAutoStartType>))]
    public enum EAutoStartType
    {
        [Description("잠금모드")]
        LockType,
        [Description("잠금모드 해제")]
        UnLockType
    }
}
