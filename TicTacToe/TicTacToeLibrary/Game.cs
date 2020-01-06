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
        public void SetBlock(int x, int y)
        {
            if (gameBoard.arr[x,y] == CellState.Empty)
            {
                if (player1Turn == true)
                {
                    gameBoard.arr[x,y] = CellState.X;
                }
                else
                {
                    gameBoard.arr[x,y] = CellState.O;
                }
                player1Turn = !player1Turn;
            }
        }
        public void CheckForLine()
        {

        }
        public void CheckVertical()
        {
            for (int i = 0; i < 5; i += 5) ;
        }
    }
}
