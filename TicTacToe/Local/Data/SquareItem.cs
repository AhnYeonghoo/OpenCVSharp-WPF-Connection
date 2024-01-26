using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevNcore.UI.Foundation.Mvvm;
using System.Windows.Input;

namespace TicTacToe.Local.Data
{
    public class SquareItem : ObservableObject
    {
        public ICommand ChoiceCommand { get; set; }

        private Player _player;
        public Player Player
        {
            get => _player;
            set { _player = value; OnPropertyChanged() }
        }

        public string WinnerMessage => "Win : " + Player;
        public SquareItem(ICommand choice)
        {
            ChoiceCommand = choice;
        }
    }
}
