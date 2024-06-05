using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGame> _game;

        public GameBoardViewModel(ICell<IGame> game)
        {
            _game = game;
        }

        public IEnumerable<RowViewModel> Rows => MultipleRows().Select((squares, index) => new RowViewModel(squares, index, _game));

        //Returns an IEnumerable of Squares for a given row
        public IEnumerable<Square> SingleRow(int row)
        {
            return Enumerable.Range(0, _game.Value.Board.Height).Select(column => _game.Value.Board[new Vector2D(column, row)]);
        }

        //Returns an IEnumerable of Squares for multiple rows
        public IEnumerable<IEnumerable<Square>> MultipleRows()
        {
            return Enumerable.Range(0, _game.Value.Board.Width).Select(row => SingleRow(row));
        }
    }
}
