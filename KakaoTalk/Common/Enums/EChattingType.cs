using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Common.Converters;


namespace Common.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter<EChattingRoomType>))]
    public enum EChattingRoomType
    {
        [Description("1:1채팅")]
        PersonalChat,

        [Description("그룹")]
        GroupChat,

        [Description("플러스 친구 채팅")]
        PlusChat,

        [Description("오픈 채팅")]
        OpenChat,
    }

    public enum EChattingMsgType
    {
        Normal,
        Reply,
        Notice,
        Photo,
    }

    public enum EChattingSpeechType
    {
        Mine,
        Opponent,
    }
}
