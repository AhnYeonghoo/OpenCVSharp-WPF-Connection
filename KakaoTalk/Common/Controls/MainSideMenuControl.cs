using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Common.Controls
{
    public class MainSideMenuControl : ItemsControl
    {
        public MainSideMenuControl()
        {
            this.DefaultStyleKey = typeof(MainSideMenuControl);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MainSideMenuControl();
        }
    }

    public class MainSideMenuItemControl : RadioButton
    {
        public MainSideMenuItemControl()
        {
            this.DefaultStyleKey = typeof(MainSideMenuItemControl);
            base.GroupName = "MainSideMenu";
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        public Int16 Badge
        {
            get { return (Int16)base.GetValue(BadgeProperty); }
            set { base.SetValue(IconImageProperty, value); }
        }

        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.Register("Badge", typeof(Int16), typeof(MainSideMenuItemControl));

        public ImageSource? IconImage
        {
            get { return base.GetValue(IconImageProperty) as ImageSource; }
            set { base.SetValue(IconImageProperty, value); }
        }

        public static readonly DependencyProperty IconImageProperty =
            DependencyProperty.Register("IconImage", typeof(ImageSource), typeof(MainSideMenuItemControl));

        public ImageSource? MouseOverIconImage
        {
            get { return base.GetValue(MouseOverIconImageProperty) as ImageSource; }
            set { base.SetValue(MouseOverIconImageProperty, value); }
        }

        public static readonly DependencyProperty MouseOverIconImageProperty =
            DependencyProperty.Register("MouseOverIconImage", typeof(ImageSource), typeof(MainSideMenuItemControl));

        public ImageSource? SelectedIconImage
        {
            get { return base.GetValue(SelectedIconImageProperty) as ImageSource; }
            set { base.SetValue(SelectedIconImageProperty, value); }
        }

        public static readonly DependencyProperty SelectedIconImageProperty =
            DependencyProperty.Register("SelectedIconImage", typeof(ImageSource), typeof(MainSideMenuItemControl));
    }
}
