using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tetris_Razor.Models.Enums;

namespace Tetris_Razor.Models.Tetrominoes
{
    public class Tetromino
    {
        // Grid in whish exists
        public Grid Grid { get; set; }

        // Current orientation
        public TetrominoOrientation Orientation { get; set; }
            = TetrominoOrientation.LeftRight;

        // y oordinate of the center
        public int CenterPieceRow { get; set; }

        // x oordinate of the center
        public int CenterPieceColumn { get; set; }

        // style
        public virtual TetrominoStyle Style { get; }

        //CSS style
        public virtual string CssClass { get; }

        //collection of cells in this tetromino
        public virtual CellCollection CoveredCells { get; }

        // constructor
        public Tetromino(Grid grid)
        {
            Grid = grid;
            CenterPieceRow = grid.Height;
            CenterPieceColumn = grid.Width / 2;
        }

        //available to move Left
        public bool CanMoveLeft()
        {
            //if occupied cells to the left in the Grid exists
            foreach (Cell cell in CoveredCells.GetLeftmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column - 1)
                    return false;                 
            }
        }
    }
}
