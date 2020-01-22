using System;


namespace TicTacToeLibrary
{
    /// <summary>
    /// Class maintaining game logic.
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
        public int lastXCPU { get; set; }

        /// <summary>
        /// Last column on which cpu set its block.
        /// </summary>
        public int lastYCPU { get; set; }

        /// <summary>
        /// CPU add block on random position if cannot do otherwise.
        /// </summary>
        public Random rnd = new Random();

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

            if (gameBoard.arr[x, y] == CellState.Empty)
            {
                if (player1Turn == true)
                {
                    gameBoard.arr[x, y] = CellState.X;
                }
                else
                {
                    gameBoard.arr[x, y] = CellState.O;
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
        /// Method checks for line of same blocks.
        /// </summary>
        /// <returns></returns>
        public bool CheckForLine()
        {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonal())
                return true;
            return false;
        }
        /// <summary>
        /// Method checks for vertical line.
        /// </summary>
        /// <returns>Return true if there is a vertical line.</returns>
        public bool CheckVertical()
        {
            for (int i = 0; i < 5; i++)
            {
                if (gameBoard.arr[i, 0] != CellState.Empty &&
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
        /// <returns>Returns true if there is horizontal line.</returns>
        public bool CheckHorizontal()
        {
            for (int i = 0; i < 5; i++)
            {
                if (gameBoard.arr[0, i] != CellState.Empty &&
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
        /// <returns>Returns true if there is diagonal line.</returns>
        public bool CheckDiagonal()
        {
            if (gameBoard.arr[2, 2] != CellState.Empty &&
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
        /// <returns>Return true if all block are either X or O and none player won.</returns>
        public bool CheckDraw()
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
        public void EndGame()
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
        public void SetScore()
        {
            if (player1Turn)
                p1Score++;
            else
                p2Score++;
        }
        /// <summary>
        /// If CPU cannot do otherwise it sets O on random place in game array
        /// </summary>
        public void SetBlockCPURandom()
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

                SetBlockCPURandom();
            }
        }


        /// <summary>
        /// Method setting block by CPU.
        /// </summary>
        public void SetBlockCPU()
        {

            if (!player1Turn)
            {
                if (SetBlockCPUHorizontal()) ;
                else if (SetBlockCPUVertical()) ;
                else if (SetBlockCPUDiagonal()) ;

                else
                {
                    SetBlockCPURandom();
                }
                player1Turn = true;
            }
        }
        /// <summary>
        /// Check if CPU should block players horizontal line for win.
        /// </summary>
        /// <returns>Return true if CPU blocked player from winning.</returns>
        public bool SetBlockCPUHorizontal()
        {

            //sprawdzenie czy gracz nie wygra w następnej rundzie oraz blokada gracza zeby nie wygrał
            if (gameBoard.arr[0, 0] == CellState.Empty &&  // (0,0) sprawdzenie czy za 1 runde gracz nie wygra
                gameBoard.arr[0, 1] == CellState.X &&
                gameBoard.arr[0, 2] == CellState.X &&
                gameBoard.arr[0, 3] == CellState.X &&
                gameBoard.arr[0, 4] == CellState.X)
            {
                gameBoard.arr[0, 0] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 0;
                return true;
            }

            else if (gameBoard.arr[0, 1] == CellState.Empty &&    //(0,1) <--- gdy gracz da X w to pole to wygra
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[0, 2] == CellState.X &&
                    gameBoard.arr[0, 3] == CellState.X &&
                    gameBoard.arr[0, 4] == CellState.X)
            {
                gameBoard.arr[0, 1] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 1;
                return true;
            }


            else if (gameBoard.arr[0, 2] == CellState.Empty &&  //(0,2)
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[0, 1] == CellState.X &&
                    gameBoard.arr[0, 3] == CellState.X &&
                    gameBoard.arr[0, 4] == CellState.X)
            {
                gameBoard.arr[0, 2] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[0, 4] == CellState.Empty && //(0,4) 
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[0, 1] == CellState.X &&
                    gameBoard.arr[0, 2] == CellState.X &&
                    gameBoard.arr[0, 3] == CellState.X)
            {
                gameBoard.arr[0, 4] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 4;
                return true;
            }

            else if (gameBoard.arr[1, 0] == CellState.Empty && //(1,0)
                    gameBoard.arr[1, 1] == CellState.X &&
                    gameBoard.arr[1, 2] == CellState.X &&
                    gameBoard.arr[1, 3] == CellState.X &&
                    gameBoard.arr[1, 4] == CellState.X)
            {
                gameBoard.arr[1, 0] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 0;
                return true;
            }

            else if (gameBoard.arr[1, 1] == CellState.Empty &&  //(1,1)
                   gameBoard.arr[1, 0] == CellState.X &&
                   gameBoard.arr[1, 2] == CellState.X &&
                   gameBoard.arr[1, 3] == CellState.X &&
                   gameBoard.arr[1, 4] == CellState.X)
            {
                gameBoard.arr[1, 1] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 1;
                return true;
            }


            else if (gameBoard.arr[1, 2] == CellState.Empty && //(1,2)
                   gameBoard.arr[1, 0] == CellState.X &&
                   gameBoard.arr[1, 1] == CellState.X &&
                   gameBoard.arr[1, 3] == CellState.X &&
                   gameBoard.arr[1, 4] == CellState.X)
            {
                gameBoard.arr[1, 2] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 2;
                return true;
            }



            else if (gameBoard.arr[1, 4] == CellState.Empty && //(1,4)
                    gameBoard.arr[1, 0] == CellState.X &&
                    gameBoard.arr[1, 1] == CellState.X &&
                    gameBoard.arr[1, 2] == CellState.X &&
                    gameBoard.arr[1, 3] == CellState.X)
            {
                gameBoard.arr[1, 4] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 4;
                return true;
            }

            else if (gameBoard.arr[2, 0] == CellState.Empty &&  //(2,0)
                    gameBoard.arr[2, 1] == CellState.X &&
                    gameBoard.arr[2, 2] == CellState.X &&
                    gameBoard.arr[2, 3] == CellState.X &&
                    gameBoard.arr[2, 4] == CellState.X)
            {
                gameBoard.arr[2, 0] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 0;
                return true;
            }


            else if (gameBoard.arr[2, 1] == CellState.Empty && //(2,1)
                    gameBoard.arr[2, 0] == CellState.X &&
                    gameBoard.arr[2, 2] == CellState.X &&
                    gameBoard.arr[2, 3] == CellState.X &&
                    gameBoard.arr[2, 4] == CellState.X)
            {
                gameBoard.arr[2, 1] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 1;
                return true;
            }


            else if (gameBoard.arr[2, 2] == CellState.Empty && //(2,2)
                    gameBoard.arr[2, 0] == CellState.X &&
                    gameBoard.arr[2, 1] == CellState.X &&
                    gameBoard.arr[2, 3] == CellState.X &&
                    gameBoard.arr[2, 4] == CellState.X)
            {
                gameBoard.arr[2, 2] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 2;
                return true;
            }


            else if (gameBoard.arr[2, 3] == CellState.Empty && //(2,3)
                    gameBoard.arr[2, 0] == CellState.X &&
                    gameBoard.arr[2, 1] == CellState.X &&
                    gameBoard.arr[2, 2] == CellState.X &&
                    gameBoard.arr[2, 4] == CellState.X)
            {
                gameBoard.arr[2, 3] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 3;
                return true;
            }

            else if (gameBoard.arr[4, 0] == CellState.Empty && //(4,0)
                    gameBoard.arr[4, 1] == CellState.X &&
                    gameBoard.arr[4, 2] == CellState.X &&
                    gameBoard.arr[4, 3] == CellState.X &&
                    gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[4, 0] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 0;
                return true;
            }


            else if (gameBoard.arr[4, 1] == CellState.Empty && //(4,1)
                    gameBoard.arr[4, 0] == CellState.X &&
                    gameBoard.arr[4, 2] == CellState.X &&
                    gameBoard.arr[4, 3] == CellState.X &&
                    gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[4, 1] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 1;
                return true;
            }


            else if (gameBoard.arr[4, 2] == CellState.Empty &&
                    gameBoard.arr[4, 0] == CellState.X &&   //(4,2)
                    gameBoard.arr[4, 1] == CellState.X &&
                    gameBoard.arr[4, 3] == CellState.X &&
                    gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[4, 2] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 2;
                return true;
            }


            else if (gameBoard.arr[4, 4] == CellState.Empty && //(4,4)
                    gameBoard.arr[4, 0] == CellState.X &&
                    gameBoard.arr[4, 1] == CellState.X &&
                    gameBoard.arr[4, 2] == CellState.X &&
                    gameBoard.arr[4, 3] == CellState.X)
            {
                gameBoard.arr[4, 4] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 4;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if CPU should block players vertical winning line.
        /// </summary>
        /// <returns>Return true if blocked player from winning.</returns>
        public bool SetBlockCPUVertical()
        {

            //zabezpieczenie pionowe 

            if (gameBoard.arr[0, 0] == CellState.Empty && //(0,0)
                   gameBoard.arr[1, 0] == CellState.X &&
                   gameBoard.arr[2, 0] == CellState.X &&
                   gameBoard.arr[3, 0] == CellState.X &&
                   gameBoard.arr[4, 0] == CellState.X)
            {
                gameBoard.arr[0, 0] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 0;
                return true;
            }

            else if (gameBoard.arr[1, 0] == CellState.Empty && //(1,0)
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[2, 0] == CellState.X &&
                    gameBoard.arr[3, 0] == CellState.X &&
                    gameBoard.arr[4, 0] == CellState.X)
            {
                gameBoard.arr[1, 0] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 0;
                return true;
            }


            else if (gameBoard.arr[4, 0] == CellState.Empty &&  //(4,0)
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[1, 0] == CellState.X &&
                    gameBoard.arr[2, 0] == CellState.X &&
                    gameBoard.arr[3, 0] == CellState.X)
            {
                gameBoard.arr[4, 0] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 0;
                return true;
            }


            else if (gameBoard.arr[4, 1] == CellState.Empty &&  //(4,1)
                     gameBoard.arr[0, 1] == CellState.X &&
                     gameBoard.arr[1, 1] == CellState.X &&
                     gameBoard.arr[2, 1] == CellState.X &&
                     gameBoard.arr[3, 1] == CellState.X)
            {
                gameBoard.arr[4, 1] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 1;
                return true;
            }

            else if (gameBoard.arr[0, 2] == CellState.Empty && //(0,2)
                     gameBoard.arr[1, 2] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 2] == CellState.X &&
                     gameBoard.arr[4, 2] == CellState.X)
            {
                gameBoard.arr[0, 2] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[1, 2] == CellState.Empty && //(1,2)
                     gameBoard.arr[0, 2] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 2] == CellState.X &&
                     gameBoard.arr[4, 2] == CellState.X)
            {
                gameBoard.arr[1, 2] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[2, 2] == CellState.Empty && //(2,2)
                    gameBoard.arr[0, 2] == CellState.X &&
                    gameBoard.arr[1, 2] == CellState.X &&
                    gameBoard.arr[3, 2] == CellState.X &&
                    gameBoard.arr[4, 2] == CellState.X)
            {
                gameBoard.arr[2, 2] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[4, 2] == CellState.Empty && //(4,2)
                     gameBoard.arr[0, 2] == CellState.X &&
                     gameBoard.arr[1, 2] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 2] == CellState.X)
            {
                gameBoard.arr[4, 2] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[0, 3] == CellState.Empty && //(0,3)
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[2, 3] == CellState.X &&
                     gameBoard.arr[3, 3] == CellState.X &&
                     gameBoard.arr[4, 3] == CellState.X)
            {
                gameBoard.arr[0, 3] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 3;
                return true;
            }



            else if (gameBoard.arr[2, 3] == CellState.Empty && //(2,3)
                     gameBoard.arr[0, 3] == CellState.X &&
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[3, 3] == CellState.X &&
                     gameBoard.arr[4, 3] == CellState.X)
            {
                gameBoard.arr[2, 3] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 3;
                return true;
            }

            else if (gameBoard.arr[4, 3] == CellState.Empty && //(4,3)
                     gameBoard.arr[0, 3] == CellState.X &&
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[2, 3] == CellState.X &&
                     gameBoard.arr[3, 3] == CellState.X)
            {
                gameBoard.arr[4, 3] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 3;
                return true;
            }

            else if (gameBoard.arr[0, 4] == CellState.Empty &&//(0,4)  
                     gameBoard.arr[1, 4] == CellState.X &&
                     gameBoard.arr[2, 4] == CellState.X &&
                     gameBoard.arr[3, 4] == CellState.X &&
                     gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[0, 4] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 4;
                return true;
            }


            else if (gameBoard.arr[1, 4] == CellState.Empty && //(1,4)
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[2, 4] == CellState.X &&
                     gameBoard.arr[3, 4] == CellState.X &&
                     gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[1, 4] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 4;
                return true;
            }


            else if (gameBoard.arr[2, 4] == CellState.Empty && //(2,4)
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[1, 4] == CellState.X &&
                     gameBoard.arr[3, 4] == CellState.X &&
                     gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[2, 4] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 4;
                return true;
            }

            else if (gameBoard.arr[4, 4] == CellState.Empty &&  //(4,4)
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[1, 4] == CellState.X &&
                     gameBoard.arr[2, 4] == CellState.X &&
                     gameBoard.arr[3, 4] == CellState.X)
            {
                gameBoard.arr[4, 4] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 4;
                return true;
            }
            return false;

        }


        /// <summary>
        /// Checks if CPU should block players winning line.
        /// </summary>
        /// <returns>Return true if blocked player from winning</returns>
        public bool SetBlockCPUDiagonal()
        {

            if (gameBoard.arr[0, 0] == CellState.Empty && //(0,0) ukos\
                gameBoard.arr[1, 1] == CellState.X &&
                gameBoard.arr[2, 2] == CellState.X &&
                gameBoard.arr[3, 3] == CellState.X &&
                gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[0, 0] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 0;
                return true;
            }

            else if (gameBoard.arr[1, 1] == CellState.Empty && //(1,1) ukos\
                     gameBoard.arr[0, 0] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 3] == CellState.X &&
                     gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[1, 1] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 1;
                return true;
            }


            else if (gameBoard.arr[2, 2] == CellState.Empty && //(2,2) ukos\
                     gameBoard.arr[0, 0] == CellState.X &&
                     gameBoard.arr[1, 1] == CellState.X &&
                     gameBoard.arr[3, 3] == CellState.X &&
                     gameBoard.arr[4, 4] == CellState.X)
            {
                gameBoard.arr[2, 2] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 2;
                return true;
            }


            else if (gameBoard.arr[4, 4] == CellState.Empty && //(4,4) ukos\
                    gameBoard.arr[0, 0] == CellState.X &&
                    gameBoard.arr[1, 1] == CellState.X &&
                    gameBoard.arr[2, 2] == CellState.X &&
                    gameBoard.arr[3, 3] == CellState.X)
            {
                gameBoard.arr[4, 4] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 4;
                return true;
            }

            else if (gameBoard.arr[0, 4] == CellState.Empty &&//(0,4) ukos/    tutu
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 1] == CellState.X &&
                     gameBoard.arr[4, 0] == CellState.X)
            {
                gameBoard.arr[0, 4] = CellState.O;
                lastXCPU = 0;
                lastYCPU = 4;
                return true;
            }


            else if (gameBoard.arr[1, 3] == CellState.Empty && //(1,3) ukos/
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 1] == CellState.X &&
                     gameBoard.arr[4, 0] == CellState.X)
            {
                gameBoard.arr[1, 3] = CellState.O;
                lastXCPU = 1;
                lastYCPU = 3;
                return true;
            }

            else if (gameBoard.arr[2, 2] == CellState.Empty &&  //(2,2) ukos/
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[3, 1] == CellState.X &&
                     gameBoard.arr[4, 0] == CellState.X)
            {
                gameBoard.arr[2, 2] = CellState.O;
                lastXCPU = 2;
                lastYCPU = 2;
                return true;
            }

            else if (gameBoard.arr[4, 0] == CellState.Empty && //(4,0) ukos/
                     gameBoard.arr[0, 4] == CellState.X &&
                     gameBoard.arr[1, 3] == CellState.X &&
                     gameBoard.arr[2, 2] == CellState.X &&
                     gameBoard.arr[3, 1] == CellState.X)
            {
                gameBoard.arr[4, 0] = CellState.O;
                lastXCPU = 4;
                lastYCPU = 0;
                return true;
            }
            return false;


        }



    }
}