using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tetris_Razor.Models.Enums;

namespace Tetris_Razor.Models.Tetrominoes
{
    public class Block : Tetromino
    {
        public Block(Grid grid) : base(grid) { }
        public override TetrominoStyle Style => TetrominoStyle.Block;
        public override string CssClass => "tetris-yellow-cell";
        public override CellCollection CoveredCells
        {
            get
            {
                CellCollection cells = new();
                cells.Add(CenterPieceRow, CenterPieceColumn);
                cells.Add(CenterPieceRow - 1, CenterPieceColumn);
                cells.Add(CenterPieceRow, CenterPieceColumn + 1);
                cells.Add(CenterPieceRow - 1, CenterPieceColumn + 1);
                return cells;
            }
        }
    }
}
