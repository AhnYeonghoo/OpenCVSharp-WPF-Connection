using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Common.Controls
{
    public class EllipseButton : ImageButton
    {
        public EllipseButton()
        {
            DefaultStyleKey = typeof(EllipseButton);
        }

        public static readonly DependencyProperty? NormalBackgroundProperty =
            DependencyProperty.Register(
                "NormalBackground",
                typeof(Brush),
                typeof(EllipseButton),
                new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"))));

        public Brush? NormalBackground
        {
            get { return (Brush)this.GetValue(NormalBackgroundProperty); }
            set { this.SetValue(NormalBackgroundProperty, value); }
        }

        public static readonly DependencyProperty? PressBackgroundProperty =
            DependencyProperty.Register(
                "PressBackground",
                typeof(Brush),
                typeof(EllipseButton),
                new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF690100")!)));

        public Brush? PressBackground
        {
            get { return (Brush)this.GetValue(PressBackgroundProperty); }
            set { this.SetValue(PressBackgroundProperty, value); }
        }

        public static readonly DependencyProperty? IsEllipseVisibleProperty =
            DependencyProperty.Register(
                "IsEllipseVisible", typeof(Boolean), typeof(EllipseButton), new PropertyMetadata(true));

        public bool IsEllipseVisible
        {
            get { return (Boolean)this.GetValue(IsEllipseVisibleProperty); }
            set { this.SetValue(IsEllipseVisibleProperty, value); }
        }

        public static readonly DependencyProperty? IsDecriptVisibleProperty =
            DependencyProperty.Register(
                "IsDescriptVisible",
                typeof(Boolean),
                typeof(EllipseButton), new PropertyMetadata(true));

    }
}
