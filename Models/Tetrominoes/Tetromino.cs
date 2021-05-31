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
                if (Grid.Cells.Contains(cell.Row, cell.Column - 1))
                    return false;                 
            }

            // if tetromino in the 1st column
            if (CoveredCells.HasColumn(1))
                return false;

            return true;
        }

        //available to move Right
        public bool CanMoveRight()
        {
            //if occupied cells to the right in the Grid exists
            foreach (Cell cell in CoveredCells.GetRightmost())
            {
                if (Grid.Cells.Contains(cell.Row, cell.Column + 1))
                    return false;
            }

            // if tetromino in the last column
            if (CoveredCells.HasColumn(Grid.Wigth))
                return false;

            return true;
        }

        public void MoveLeft()
        {
            if (CanMoveLeft())
                CenterPieceColumn--;
        }

        public void MoveRight()
        {
            if (CanMoveRight())
                CenterPieceColumn++;
        }

        //available to move Down
        public bool CanMoveDown()
        {
            //if occupied cells lower in the Grid exists
            foreach (Cell cell in CoveredCells.GetLowest())
            {
                if (Grid.Cells.Contains(cell.Row - 1, cell.Column))
                    return false;
            }

            // if tetromino in the last column
            if (CoveredCells.HasRow(1))
                return false;

            return true;
        }

        public void MoveDown()
        {
            if (CanMoveDown())
                CenterPieceRow--;
        }

        public void Rotete()
        {
            switch(Orientation)
            {
                case TetrominoOrientation.UpDown:
                    Orientation = TetrominoOrientation.RightLeft;
                    break;

                case TetrominoOrientation.RightLeft:
                    Orientation = TetrominoOrientation.DownUp;
                    break;

                case TetrominoOrientation.DownUp:
                    Orientation = TetrominoOrientation.LeftRight;
                    break;

                case TetrominoOrientation.LeftRight:
                    Orientation = TetrominoOrientation.UpDown;
                    break;
            }

            var coveredSpase = CoveredCells;

            if (coveredSpase.HasColumn(-1))
            {
                CenterPieceColumn += 2;
            }
            if (coveredSpase.HasColumn(12))
            {
                CenterPieceColumn -= 2;
            }
            if (coveredSpase.HasColumn(0))
            {
                CenterPieceColumn++;
            }
            if (coveredSpase.HasColumn(11))
            {
                CenterPieceColumn--;
            }
        }
    }
}
