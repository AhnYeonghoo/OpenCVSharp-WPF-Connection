using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Common.Behaviors
{
    public class ListBoxScrollIntoViewBehavior : DependencyObject
    {
        public static readonly DependencyProperty ScrollIntoTargetProperty =
            DependencyProperty.RegisterAttached("ScrollintoTarget",
                typeof(Object), typeof(ListBoxScrollIntoViewBehavior),
                new UIPropertyMetadata(null, ScrollIntoTargetChanged));

        public static object GetScrollIntoTarget(DependencyObject obj)
        {
            return (object)obj.GetValue(ScrollIntoTargetProperty);
        }

        public static void SetScrollIntoTarget(DependencyObject obj, object value)
        {
            obj.SetValue(ScrollIntoTargetProperty, value);
        }

        public static void ScrollIntoTargetChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;

            var listBox = o as ListBox;
            listBox!.ScrollIntoView(e.NewValue);
        }
    }
}
