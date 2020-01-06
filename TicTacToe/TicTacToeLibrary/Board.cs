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
        public CellState[,] arr = new CellState[5,5];
        public Board()
        {
            for (int i=0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = CellState.Empty;
                }
            }
        }
    }
}
