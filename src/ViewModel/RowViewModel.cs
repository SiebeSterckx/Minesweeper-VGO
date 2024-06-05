using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RowViewModel
    {
        public RowViewModel(IEnumerable<Square> squares, int rowIndex, ICell<IGame> game)
        {
            // Create SquareViewModel for each square in the row, using game cell and position
            Squares = squares.Select((s, i) => new SquareViewModel(game, new Vector2D(i, rowIndex)));
        }

        // Represents the collection of SquareViewModels for the row
        public IEnumerable<SquareViewModel> Squares { get; }
    }
}
