using System;

namespace TicTacToeLibrary
{
    /// <summary>
    /// CellState enum is state of every game block.
    /// </summary>
    public enum CellState
    {
        /// <summary>
        /// State of block is empty.
        /// </summary>
        Empty,
        /// <summary>
        /// Block is occupied by X.
        /// </summary>
        X,
        /// <summary>
        /// Block is occupied by O.
        /// </summary>
        O
    }
    /// <summary>
    /// Two dimensional board which hold information of player markers.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Array which hold every block of the game.
        /// </summary>
        public CellState[,] arr = new CellState[5,5];
        /// <summary>
        /// Constructor for Board class, sets every block to empty.
        /// </summary>
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
