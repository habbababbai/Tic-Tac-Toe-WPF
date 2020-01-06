using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public enum CellState
    {
        Empty,
        X,
        O
    }
    public class Board
    {
        public CellState[] arr = new CellState[25];
        public Board()
        {
            for (int i=0; i < arr.Length; i++)
            {
                arr[i] = CellState.Empty;
            }
        }
    }
}
