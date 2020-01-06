﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Game : INotifyPropertyChanged
    {
        public bool player1Turn;
        public Board gameBoard;
        public bool isOver;
        public Game()
        {
            gameBoard = new Board();
            player1Turn = true;
            isOver = false;
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
                if (CheckForLine())
                    EndGame();

                player1Turn = !player1Turn;
            }
        }
        public bool CheckForLine()
        {
            if (CheckHorizontal() || CheckVertical())
                return true;
            return false;
        }
        public bool CheckVertical()
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
        public bool CheckHorizontal()
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
        public void EndGame()
        {
            isOver = true;
            gameBoard = new Board();
            player1Turn = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
