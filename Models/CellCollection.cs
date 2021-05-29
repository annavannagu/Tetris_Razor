using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tetris_Razor.Models
{
    public class CellCollection
    {
        private readonly List<Cell> cells = new();


        // is there  occupied cells in the Row
        public bool HasRow(int row)
        {
            return cells.Any(c => c.Row == row);
        }


        // is there occupied cells in the Column
        public bool HasColumn(int column)
        {
            return cells.Any(c => c.Column == column);
        }

        // is there occupied cell on coordinate
        public bool Contains(int row, int column)
        {
            return cells.Any(c => c.Row == row && c.Column == column);
        }

        // add new cell to collection
        public void Add(int row, int column)
        {
            cells.Add(new Cell(row, column));
        }

        // add several cells with css slass
        public void AddMany(List<Cell> _cells, string css)
        {
            foreach(Cell c in _cells)
            {
                cells.Add(new Cell(c.Row, c.Column, c.CSSClass));
            }
        }

        // return all cells
        public List<Cell> GetAll()
        {
            return cells;
        }
    }

    
}
    