using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.UI.Units
{
    public class ScoreBox
    {
        static ScoreBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScoreBox), new FrameworkPropertyMetadata(typeof(ScoreBox)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ScoreBoxItem();
        }
    }
}
