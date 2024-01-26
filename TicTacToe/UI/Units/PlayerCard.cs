using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.UI.Units
{
    public class PlayerCard : Control
    {
        static PlayerCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayerCard), new FrameworkPropertyMetadata(typeof(PlayerCard)));
        }
    }
}
