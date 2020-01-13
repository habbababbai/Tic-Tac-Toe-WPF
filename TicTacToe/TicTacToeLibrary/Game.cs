using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    /// <summary>
    /// Klasa Game zajmująca się logiką gry
    /// </summary>
    public class Game
    {
        /// <summary>
        /// player1Turn checks which player turn it is.
        /// </summary>
        public bool player1Turn { get; private set; }
        /// <summary>
        /// gameBoard is object that holds information of every game block.
        /// </summary>
        public Board gameBoard { get; private set; }
        /// <summary>
        /// isOver checks if game is over.
        /// </summary>
        public bool isOver { get; private set; }
        /// <summary>
        /// Score of player one.
        /// </summary>
        public int p1Score { get; private set; }
        /// <summary>
        /// Score of player2
        /// </summary>
        public int p2Score { get; private set; }
        /// <summary>
        /// Last row on which cpu set its block.
        /// </summary>
        public int lastXCPU { get; private set; }
        /// <summary>
        /// Last column on which cpu set its block.
        /// </summary>
        public int lastYCPU { get; private set; }
        private Random rnd = new Random();
        /// <summary>
        /// Constructor for Game class.
        /// </summary>
        public Game()
        {
            gameBoard = new Board();
            player1Turn = true;
            isOver = false;
            p1Score = 0;
            p2Score = 0;
        }
        /// <summary>
        /// Method allowing to change specific block state.
        /// </summary>
        /// <param name="x">Row of block next to change.</param>
        /// <param name="y">Column of block next to change</param>
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
        /// <summary>
        /// Method setting block by CPU.
        /// </summary>
        public void SetBlockCPU()
        {
            if(!player1Turn)
            {
                int x = rnd.Next(0, 5);
                int y = rnd.Next(0, 5);
                if (gameBoard.arr[x, y] == CellState.Empty)
                {
                    gameBoard.arr[x, y] = CellState.O;
                    lastXCPU = x;
                    lastYCPU = y;
                    if (CheckDraw())
                        EndGame();
                    if (CheckForLine())
                    {
                        EndGame();
                        SetScore();
                    }
                }
                else
                {
                    SetBlockCPU();
                }
            }
            player1Turn = true;
        }
        /// <summary>
        /// Method checks for line of same blocks.
        /// </summary>
        /// <returns></returns>
        private bool CheckForLine()
        {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonal())
                return true;
            return false;
        }
        /// <summary>
        /// Method checks for vertical line.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Method checks for horizontal line.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Method checks for diagonal line.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Method checks if every block is set as X or O.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Method ends game.
        /// </summary>
        private void EndGame()
        {
            isOver = true;
        }
        /// <summary>
        /// Method resets gameBoard.
        /// </summary>
        public void Reset()
        {
            gameBoard = new Board();
            isOver = false;
            player1Turn = true;
        }
        /// <summary>
        /// Method sets scores for players.
        /// </summary>
        private void SetScore()
        {
            if (player1Turn)
                p1Score++;
            else
                p2Score++;
        }
    }
}
