using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.UI.Units
{
    public class GameBoardItem : ListBoxItem
    {
        static GameBoardItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameBoardItem), new FrameworkPropertyMetadata(typeof(GameBoardItem)));
        }
    }
}
