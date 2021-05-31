using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tetris_Razor.Models.Enums;

namespace Tetris_Razor.Models
{
    public class Grid
    {
        public int Wigth { get; } = 10;
        public int Height { get; } = 20;
        public CellCollection Cells { get; set; } = new();

        public GameState State { get; set; } = GameState.NotStarted;

        public bool IsStarted
        {
            get
            {
                return State == GameState.Playing
                    || State == GameState.GameOver;
            }
        }
    }
}
