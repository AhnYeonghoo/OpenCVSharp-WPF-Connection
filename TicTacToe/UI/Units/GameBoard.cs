using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TicTacToe.UI.Units
{
    public class GameBoard : ListBox
    {
        static GameBoard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameBoard), new FrameworkPropertyMetadata(typeof(GameBoard)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new GameBoardItem();
        }

    }
}
