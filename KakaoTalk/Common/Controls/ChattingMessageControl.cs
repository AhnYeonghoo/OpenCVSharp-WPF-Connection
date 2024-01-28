using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Common.Controls
{
    [TemplatePart(Name = ProfilePartName, Type = typeof(Button))]
    public  class ChattingMessageControl : Control
    {
        private const string ProfilePartName = "PART_Profile";
        private Button? _profilePart;

        public ChattingMessageControl()
        {
            this.DefaultStyleKey = typeof(ChattingMessageControl);
        }

        public static readonly DependencyProperty ChatContentProperty =
            DependencyProperty.Register("ChatContent", typeof(object), typeof(ChattingMessageControl)
                , new UIPropertyMetadata(null));

        public object? ChatContent
        {
            get { return base.GetValue(ChatContentProperty) as object; }
            set { base.SetValue(ChatContentProperty, value); }
        }

        public static readonly DependencyProperty? SelectionBackgroundProperty =
            DependencyProperty.Register(
                "SelectionBackground",
                typeof(Brush),
                typeof(ChattingMessageControl),
                new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF606264"))!));

        public Brush SelectionBackground
        {
            get { return (Brush)this.GetValue(SelectionBackgroundProperty); }
            set { this.SetValue(SelectionBackgroundProperty, value); }
        }
    }
}
