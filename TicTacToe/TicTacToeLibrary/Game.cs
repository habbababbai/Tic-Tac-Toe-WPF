using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Game
    {
        public bool player1Turn { get; private set; }
        public Board gameBoard { get; private set; }
        public bool isOver { get; private set; }
        public int p1Score { get; private set; }
        public int p2Score { get; private set; }
        public Game()
        {
            gameBoard = new Board();
            player1Turn = true;
            isOver = false;
            p1Score = 0;
            p2Score = 0;
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
                if (CheckDraw())
                    EndGame();
                if (CheckForLine())
                {
                    EndGame();
                    SetScore();
                }
                else
                    player1Turn = !player1Turn;
            }
        }
        private bool CheckForLine()
        {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonal())
                return true;
            return false;
        }
        private bool CheckVertical()
        {
           for (int i = 0; i < 5; i++)
            {
                if (gameBoard.arr[i,0] != CellState.Empty &&
               gameBoard.arr[i, 0] == gameBoard.arr[i, 1] &&
               gameBoard.arr[i, 1] == gameBoard.arr[i, 2] &&
               gameBoard.arr[i, 2] == gameBoard.arr[i, 3] &&
               gameBoard.arr[i, 3] == gameBoard.arr[i, 4])
                    return true;
            }
            return false;
        }
        private bool CheckHorizontal()
        {
            for (int i = 0; i < 5; i++)
            {
                if (gameBoard.arr[0,i] != CellState.Empty &&
               gameBoard.arr[0, i] == gameBoard.arr[1, i] &&
               gameBoard.arr[1, i] == gameBoard.arr[2, i] &&
               gameBoard.arr[2, i] == gameBoard.arr[3, i] &&
               gameBoard.arr[3, i] == gameBoard.arr[4, i])
                    return true;
            }
            return false;
        }
        private bool CheckDiagonal()
        {
            if (gameBoard.arr[2,2] != CellState.Empty &&
                (gameBoard.arr[0, 0] == gameBoard.arr[1, 1] &&
                gameBoard.arr[1, 1] == gameBoard.arr[2, 2] &&
                gameBoard.arr[2, 2] == gameBoard.arr[3, 3] &&
                gameBoard.arr[3, 3] == gameBoard.arr[4, 4]) ||

                (gameBoard.arr[0, 4] == gameBoard.arr[1, 3] &&
                gameBoard.arr[1, 3] == gameBoard.arr[2, 2] &&
                gameBoard.arr[2, 2] == gameBoard.arr[3, 1]) &&
                gameBoard.arr[3, 1] == gameBoard.arr[4, 0] &&
                gameBoard.arr[2, 2] != CellState.Empty)
                return true;
            return false;
        }
        private bool CheckDraw()
        {
            bool draw = true;
            for (int i = 0; i < gameBoard.arr.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.arr.GetLength(1); j++)
                {
                    if (gameBoard.arr[i, j] == CellState.Empty)
                        draw = false;
                }
            }
            return draw;
        }
        private void EndGame()
        {
            isOver = true;
        }
        public void Reset()
        {
            gameBoard = new Board();
            isOver = false;
            player1Turn = true;
        }
        private void SetScore()
        {
            if (player1Turn)
                p1Score++;
            else
                p2Score++;
        }
    }
}
