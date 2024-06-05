using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class SquareViewModel
    {
        // Represents whether the game is lost and the square contains a mine
        public ICell<bool> GameLostContainingMines { get; }

        public ICell<Square> Square { get; }
        public ICommand Uncover { get; }
        public ICommand Flag { get; }

        public SquareViewModel(ICell<IGame> game, Vector2D position)
        {
            // Create a derived cell for the game board
            ICell<IGameBoard> gameboard = game.Derive(g => g.Board);
            // Create a derived cell for the specific square at the given position
            Square = gameboard.Derive(board => board[position]);

            //Uncover command
            Uncover = new UncoverSquareCommand(game, position);
            //Flag command
            Flag = new FlagSquareCommand(game, position);
            // Display all mines in a game that is lost and contains the given position
            GameLostContainingMines = game.Derive(g => g.Status == GameStatus.Lost && g.Mines.Contains(position));
        }

    }
}
