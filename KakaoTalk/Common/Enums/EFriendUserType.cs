using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Converters;
using System.ComponentModel;

namespace Common.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter<EFriendUserType>))]
    public enum EFriendUserType
    {
        [Description("")]
        None,

        [Description("친구")]
        Friend,

        [Description("업데이트한 친구")]
        UpdateFriend,

        [Description("플러스")]
        PlusFriend,

        [Description("채널")]
        Channel,
    }
}
