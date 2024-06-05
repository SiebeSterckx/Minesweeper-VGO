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
    public class UncoverSquareCommand : ICommand
    {
        private readonly ICell<IGame> _game;
        private readonly Vector2D _position;


        public UncoverSquareCommand(ICell<IGame> game, Vector2D position)
        {
            _game = game;
            _position = position;
            
        }

        public bool CanExecute(object parameter)
        {
            // Check if the square is covered and the game is in progress
            return _game.Value.Board[_position].Status == SquareStatus.Covered && _game.Value.Status == GameStatus.InProgress;
        }

        public void Execute(object parameter)
        {
            // Uncover the square at the specified position
            _game.Value = _game.Value.UncoverSquare(_position);
            Debug.WriteLine($"Uncovering square at position {_position}");

            // Check if the game is lost
            if (_game.Value.Status == GameStatus.Lost)
            {
                Debug.WriteLine("Game Lost");
                GameStatusCommand = "game over";
            }


        }

        public event EventHandler CanExecuteChanged;

        // Represents the status of the game (lost, won, in progress)
        public String GameStatusCommand { get; set; }

    }
}
