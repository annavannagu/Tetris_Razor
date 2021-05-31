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

        // add a CSS class to each cell in a Row
        public void SetCSSClass(int row, string css)
        {
            cells.Where(
                c => c.Row == row
                )
                .ToList()
                .ForEach(
                c => c.CSSClass = css
                );
        }

        // move all upper cells down
        public void CollapseRows(List<int> rows)
        {
            // get all cells in collapsed rows
            var selectedRows = cells.Where(c => rows.Contains(c.Row));

            // add cells to temporary collection
            List<Cell> toRemove = new();
            foreach (Cell c in selectedRows)
            {
                toRemove.Add(c);
            }

            // remove temporary cells from real collection
            cells.RemoveAll(c => toRemove.Contains(c));

            // collapse rows
            foreach (Cell c in cells)
            {
                int number = rows.Where(r => r <= c.Row).Count();
                c.Row -= number;
            }
        }

        // get Rightmost cells in collection
        public List<Cell> GetRightmost()
        {
            List<Cell> _cells = new();

            foreach (Cell c in cells)
            {
                if (!Contains(c.Row, c.Column + 1))
                    _cells.Add(c);
            }
            return _cells;
        }

        // get Leftmost cells in collection
        public List<Cell> GetLeftmost()
        {
            List<Cell> _cells = new();

            foreach (Cell c in cells)
            {
                if (!Contains(c.Row, c.Column - 1))
                    _cells.Add(c);
            }
            return _cells;
        }

        // get Loweest cells in collection
        public List<Cell> GetLowest()
        {
            List<Cell> _cells = new();

            foreach (Cell c in cells)
            {
                if (!Contains(c.Row - 1, c.Column))
                    _cells.Add(c);
            }
            return _cells;
        }
    }

    
}
    