using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Game
    {
        public bool player1Turn;
        public Board gameBoard;
        public Game()
        {
            gameBoard = new Board();
            player1Turn = true;
        }
        public void SetBlock(int index)
        {
            if (gameBoard.arr[index] == CellState.Empty)
            {
                if (player1Turn == true)
                {
                    gameBoard.arr[index] = CellState.X;
                }
                else
                {
                    gameBoard.arr[index] = CellState.O;
                }
                player1Turn = !player1Turn;
            }
        }
    }
}
