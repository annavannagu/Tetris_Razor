using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tetris_Razor.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string CSSClass { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Cell(int row, int column, string cssClass)
        {
            Row = row;
            Column = column;
            CSSClass = cssClass;
        }
    }
}
