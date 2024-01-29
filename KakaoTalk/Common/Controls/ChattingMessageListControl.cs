using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Common.Controls
{
    [TemplatePart(Name = ChatListScrollViewerPartName, Type = typeof(ScrollViewer))]
    [TemplatePart(Name = ScrollIntoBottomBtnPartName, Type = typeof(Button)]
    public class ChattingMessageListControl : ListBox
    {
        private const string ChatListScrollViewerPartName = "PART_ChatListScrollViewer";
        private const string ScrollIntoBottomBtnPartName = "PART_ScrollIntoBottomBtn";

        private ScrollViewer? _scrollViewerPart;
        private Button? _scrollIntoBottomBtnPart;

        public ChattingMessageListControl()
        {
            this.DefaultStyleKey = typeof(ChattingMessageListControl);
        }

        public static readonly DependencyProperty ScrollIntoBottomCommandProperty =
            DependencyProperty.Register(
                "ScrollIntoBottomCommand", typeof(ICommand), typeof(ChattingMessageListControl),
                new UIPropertyMetadata(null));

        public ICommand ScrollIntoBottomCommand
        {
            get
            {
                return (ICommand)GetValue(ScrollIntoBottomCommandProperty);
            }
            set
            {
                SetValue(ScrollIntoBottomCommandProperty, value);
            }
        }

        public static readonly DependencyProperty ScrollIntoBottomCommandParameterProperty =
            DependencyProperty.Register(
                "ScrollIntoBottomCommandParameter",
                typeof(Object),
                typeof(ChattingMessageListControl),
                new UIPropertyMetadata(null));

        public Object? ScrollIntoBottomcommandParameter
        {
            get
            {
                return (Object?)GetValue(ScrollIntoBottomCommandParameterProperty);
            }
            set
            {
                SetValue(ScrollIntoBottomCommandParameterProperty, value);
            }
        }

        public static readonly DependencyProperty RequestGetDataCommandProperty =
            DependencyProperty.Register(
                "RequestGetDataCommand",
                typeof(ICommand),
                typeof(ChattingMessageListControl),
                new UIPropertyMetadata(null));

        public ICommand RequestGetDataCommand
        {
            get
            {
                return (ICommand)GetValue(RequestGetDataCommandProperty);
            }
            set
            {
                SetValue(RequestGetDataCommandProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _scrollViewerPart = GetTemplateChild(ChatListScrollViewerPartName) as ScrollViewer;
            _scrollIntoBottomBtnPart = GetTemplateChild(ScrollIntoBottomBtnPartName) as Button;

            if (_scrollViewerPart is not null)
            {
                _scrollIntoBottomBtnPart.Visibility = Visibility.Collapsed;
            }
            
            if (_scrollIntoBottomBtnPart is not null)
            {
                _scrollIntoBottomBtnPart.Visibility = Visibility.Collapsed;
                _scrollIntoBottomBtnPart.Click += (_, __) =>
                {
                    if (ScrollIntoBottomCommand is not null) ScrollIntoBottomCommand.Execute(ScrollIntoBottomcommandParameter);
                }
            }
        }
    }
}
