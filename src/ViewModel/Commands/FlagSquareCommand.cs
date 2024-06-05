using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class FlagSquareCommand : ICommand
    {
        private readonly ICell<IGame> _game;
        private readonly Vector2D _position;

        public FlagSquareCommand(ICell<IGame> game, Vector2D position)
        {
            _game = game;
            _position = position;

        }

        public bool CanExecute(object parameter)
        {
            // Check if the game is in progress and the square is covered or flagged
            return _game.Value.Status == GameStatus.InProgress && (_game.Value.Board[_position].Status == SquareStatus.Covered || _game.Value.Board[_position].Status == SquareStatus.Flagged);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                // Toggle the flag on the specified square
                _game.Value = _game.Value.ToggleFlag(_position);
                Debug.WriteLine($"Flagging square at position {_position}");
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
