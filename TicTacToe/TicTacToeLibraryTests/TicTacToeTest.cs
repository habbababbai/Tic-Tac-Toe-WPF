using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLibrary;


namespace TicTacToeLibraryTest
{
    [TestClass]
    public class BoardTest
    {

        public CellState[,] arr = new CellState[5, 5];


        [TestMethod]
        public void CreateBoardTest()
        {
            Board board = new Board();


        }
        [TestMethod]
        public void EqualBoardSize()
        {
            int k = 0, l = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                l++;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = CellState.Empty;
                    k++;
                }

            }
            Assert.AreEqual(25, k, "Tablice nie są równe");
            Assert.AreEqual(5, l, "Tablice nie są równe");
        }
    }


    [TestClass]
    public class GameTest
    {
        Game game = new Game();
        [TestMethod]
        public void CreateGameTest()
        {

            Assert.AreEqual(0, game.p1Score, "nie poprawna przypsiana");
            Assert.AreEqual(0, game.p2Score, "nie poprawna przypsiana");
            Assert.AreEqual(true, game.player1Turn, "Nie poprawna Dana");
            Assert.AreEqual(false, game.isOver, "Nie poprawna Dana");

        }

        [TestMethod]
        public void CheckHorizontalTest()
        {
            for (int i = 0; i < 5; i++)
            {
                if (game.gameBoard.arr[0, i] != CellState.Empty)
                    if (game.gameBoard.arr[0, i] == game.gameBoard.arr[1, i])
                        if (game.gameBoard.arr[1, i] == game.gameBoard.arr[2, i])
                            if (game.gameBoard.arr[2, i] == game.gameBoard.arr[3, i])
                                if (game.gameBoard.arr[3, i] == game.gameBoard.arr[4, i])
                                {
                                    Assert.IsTrue(game.gameBoard.arr[0, i] == CellState.Empty);
                                }



            }



        }
        [TestMethod]
        public void ResetTest()
        {
            game.Reset();

            Assert.AreEqual(false, game.isOver, "Gra Nie została zrestartowana");
            Assert.AreEqual(true, game.player1Turn, "Gra nie została zrestartowana");



        }

        [TestMethod]
        public void EndGameTest()
        {
            game.EndGame();
            Assert.AreEqual(true, game.isOver, "Gra Nie Została zakonczona");

        }
        [TestMethod]
        public void CheckForLineTest()
        {
            game.CheckForLine();
            if (game.CheckHorizontal() || game.CheckVertical() || game.CheckDiagonal())
            {
                Assert.IsTrue(game.CheckHorizontal() || game.CheckVertical() || game.CheckDiagonal());
            }
            Assert.IsFalse(game.CheckHorizontal() || game.CheckVertical() || game.CheckDiagonal());

        }
        [TestMethod]
        public void SetScoreTest()
        {

            game.SetScore();
            if (game.player1Turn == true)
            {
                Assert.IsTrue(game.player1Turn);
            }

        }
        [TestMethod]
        public void CheckDrawTest()
        {
            game.CheckDraw();
            for (int i = 0; i < game.gameBoard.arr.GetLength(0); i++)
            {
                for (int j = 0; j < game.gameBoard.arr.GetLength(1); j++)
                {
                    if (game.gameBoard.arr[i, j] == CellState.Empty)
                        Assert.AreEqual(CellState.Empty, game.gameBoard.arr[i, j], "Nie Ma Remisu");
                    else
                    {
                        Assert.AreNotEqual(CellState.Empty, game.gameBoard.arr[i, j], "Remis");
                    }

                }
            }

        }

        [TestMethod]
        public void SetBlockTest()
        {

            game.SetBlock(0, 1);

            game.gameBoard.arr[0, 1] = CellState.O;
            if (game.gameBoard.arr[0, 1] != CellState.O)
                Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 1], "Blad Wybierania Gracza Pola Nalozene");



        }
        [TestMethod]
        public void SetBlockCPUTest()
        {

            game.SetBlockCPU();
            if (game.player1Turn == false)
            {
                if (game.SetBlockCPUHorizontal() == true)

                {
                    game.SetBlockCPUHorizontal();
                    if (game.gameBoard.arr[0, 0] == CellState.Empty &&          //[0,0]
               game.gameBoard.arr[0, 1] == CellState.X &&
               game.gameBoard.arr[0, 2] == CellState.X &&
               game.gameBoard.arr[0, 3] == CellState.X &&
               game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 0], "mamy problem (0,0)");
                    }
                    else if (game.gameBoard.arr[0, 0] == CellState.X &&
               game.gameBoard.arr[0, 1] == CellState.Empty &&
               game.gameBoard.arr[0, 2] == CellState.X &&
               game.gameBoard.arr[0, 3] == CellState.X &&
               game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 1], "mamy problem (0,1)");
                    }

                    else if (game.gameBoard.arr[0, 0] == CellState.X &&
                             game.gameBoard.arr[0, 1] == CellState.X &&
                             game.gameBoard.arr[0, 2] == CellState.Empty &&
                             game.gameBoard.arr[0, 3] == CellState.X &&
                            game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 2], "mamy problem (0,2)");
                    }
                    else if (game.gameBoard.arr[0, 0] == CellState.X &&
                             game.gameBoard.arr[0, 1] == CellState.X &&
                             game.gameBoard.arr[0, 2] == CellState.X &&
                             game.gameBoard.arr[0, 3] == CellState.X &&
                            game.gameBoard.arr[0, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 4], "mamy problem (0,4)");
                    }
                    else if (game.gameBoard.arr[1, 0] == CellState.Empty &&
                            game.gameBoard.arr[1, 1] == CellState.X &&
                            game.gameBoard.arr[1, 2] == CellState.X &&
                            game.gameBoard.arr[1, 3] == CellState.X &&
                             game.gameBoard.arr[1, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 0], "mamy problem (1,0)");
                    }
                    else if (game.gameBoard.arr[1, 0] == CellState.X &&
                            game.gameBoard.arr[1, 1] == CellState.X &&
                            game.gameBoard.arr[1, 2] == CellState.Empty &&
                            game.gameBoard.arr[1, 3] == CellState.X &&
                            game.gameBoard.arr[1, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 2], "mamy problem (1,2)");
                    }
                    else if (game.gameBoard.arr[1, 0] == CellState.X &&
                          game.gameBoard.arr[1, 1] == CellState.X &&
                          game.gameBoard.arr[1, 2] == CellState.X &&
                          game.gameBoard.arr[1, 3] == CellState.X &&
                          game.gameBoard.arr[1, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 4], "mamy problem (1,4)");
                    }
                    else if (game.gameBoard.arr[2, 0] == CellState.Empty &&
                          game.gameBoard.arr[2, 1] == CellState.X &&
                          game.gameBoard.arr[2, 2] == CellState.X &&
                          game.gameBoard.arr[2, 3] == CellState.X &&
                          game.gameBoard.arr[2, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 0], "mamy problem (2,0)");
                    }
                    else if (game.gameBoard.arr[2, 0] == CellState.X &&
                          game.gameBoard.arr[2, 1] == CellState.Empty &&
                          game.gameBoard.arr[2, 2] == CellState.X &&
                          game.gameBoard.arr[2, 3] == CellState.X &&
                          game.gameBoard.arr[2, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 0], "mamy problem (2,1)");
                    }
                    else if (game.gameBoard.arr[2, 0] == CellState.X &&
                          game.gameBoard.arr[2, 1] == CellState.X &&
                          game.gameBoard.arr[2, 2] == CellState.Empty &&
                          game.gameBoard.arr[2, 3] == CellState.X &&
                          game.gameBoard.arr[2, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 2], "mamy problem (2,2)");
                    }
                    else if (game.gameBoard.arr[2, 0] == CellState.X &&
                              game.gameBoard.arr[2, 1] == CellState.X &&
                              game.gameBoard.arr[2, 2] == CellState.X &&
                              game.gameBoard.arr[2, 3] == CellState.Empty &&
                              game.gameBoard.arr[2, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 2], "mamy problem (2,3)");
                    }
                    else if (game.gameBoard.arr[4, 0] == CellState.Empty &&
                             game.gameBoard.arr[4, 1] == CellState.X &&
                             game.gameBoard.arr[4, 2] == CellState.X &&
                             game.gameBoard.arr[4, 3] == CellState.X &&
                            game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 0], "mamy problem (4,0)");
                    }
                    else if (game.gameBoard.arr[4, 0] == CellState.X &&
                             game.gameBoard.arr[4, 1] == CellState.Empty &&
                             game.gameBoard.arr[4, 2] == CellState.X &&
                             game.gameBoard.arr[4, 3] == CellState.X &&
                             game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 1], "mamy problem (4,1)");
                    }
                    else if (game.gameBoard.arr[4, 0] == CellState.X &&
                             game.gameBoard.arr[4, 1] == CellState.X &&
                            game.gameBoard.arr[4, 2] == CellState.Empty &&
                             game.gameBoard.arr[4, 3] == CellState.X &&
                            game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 2], "mamy problem (4,2)");
                    }
                    else if (game.gameBoard.arr[4, 0] == CellState.X &&
                            game.gameBoard.arr[4, 1] == CellState.X &&
                            game.gameBoard.arr[4, 2] == CellState.X &&
                            game.gameBoard.arr[4, 3] == CellState.X &&
                            game.gameBoard.arr[4, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 4], "mamy problem (4,4)");
                    }
                }
                else if (game.SetBlockCPUVertical() == true)
                {
                    game.SetBlockCPUVertical();


                    if (game.gameBoard.arr[0, 0] == CellState.Empty &&          //[0,0]
                        game.gameBoard.arr[0, 1] == CellState.X &&
                        game.gameBoard.arr[0, 2] == CellState.X &&
                        game.gameBoard.arr[0, 3] == CellState.X &&
                        game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 0], "mamy problem (0,0) Vertical");
                    }
                    else if (game.gameBoard.arr[0, 0] == CellState.X &&
                             game.gameBoard.arr[1, 0] == CellState.Empty &&
                             game.gameBoard.arr[2, 0] == CellState.X &&
                             game.gameBoard.arr[3, 0] == CellState.X &&
                             game.gameBoard.arr[4, 0] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 0], "mamy problem (1,0)");
                    }
                    else if (game.gameBoard.arr[0, 0] == CellState.X &&
                            game.gameBoard.arr[1, 0] == CellState.X &&
                            game.gameBoard.arr[2, 0] == CellState.X &&
                            game.gameBoard.arr[3, 0] == CellState.X &&
                            game.gameBoard.arr[4, 0] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 0], "mamy problem (4,0)");
                    }
                    else if (game.gameBoard.arr[0, 1] == CellState.X &&
                             game.gameBoard.arr[1, 1] == CellState.X &&
                             game.gameBoard.arr[2, 1] == CellState.X &&
                             game.gameBoard.arr[3, 1] == CellState.X &&
                             game.gameBoard.arr[4, 1] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 1], "mamy problem (4,1)");
                    }
                    if (game.gameBoard.arr[0, 2] == CellState.Empty &&          //[0,2]
                        game.gameBoard.arr[1, 2] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 2] == CellState.X &&
                        game.gameBoard.arr[4, 2] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 2], "mamy problem (0,2) Vertical");
                    }
                    if (game.gameBoard.arr[0, 2] == CellState.X &&          //[1,2]
                        game.gameBoard.arr[1, 2] == CellState.Empty &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 2] == CellState.X &&
                        game.gameBoard.arr[4, 2] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 2], "mamy problem (1,2) Vertical");
                    }
                    if (game.gameBoard.arr[0, 2] == CellState.X &&          //[2,2]
                        game.gameBoard.arr[1, 2] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.Empty &&
                        game.gameBoard.arr[3, 2] == CellState.X &&
                        game.gameBoard.arr[4, 2] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 2], "mamy problem (2,2) Vertical");
                    }
                    if (game.gameBoard.arr[0, 2] == CellState.X &&          //[4,2]
                        game.gameBoard.arr[1, 2] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 2] == CellState.X &&
                        game.gameBoard.arr[4, 2] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 2], "mamy problem (4,2) Vertical");
                    }
                    if (game.gameBoard.arr[0, 3] == CellState.Empty &&          //[0,3]
                        game.gameBoard.arr[1, 3] == CellState.X &&
                        game.gameBoard.arr[2, 3] == CellState.X &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 3] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 3], "mamy problem (0,3) Vertical");
                    }
                    if (game.gameBoard.arr[0, 3] == CellState.X &&          //[2,3]
                        game.gameBoard.arr[1, 3] == CellState.X &&
                        game.gameBoard.arr[2, 3] == CellState.Empty &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 3] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 3], "mamy problem (2,3) Vertical");
                    }
                    if (game.gameBoard.arr[0, 3] == CellState.X &&          //[4,3]
                        game.gameBoard.arr[1, 3] == CellState.X &&
                        game.gameBoard.arr[2, 3] == CellState.X &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 3] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 3], "mamy problem (4,3) Vertical");
                    }
                    if (game.gameBoard.arr[0, 4] == CellState.Empty &&          //[0,4]
                        game.gameBoard.arr[1, 4] == CellState.X &&
                        game.gameBoard.arr[2, 4] == CellState.X &&
                        game.gameBoard.arr[3, 4] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 4], "mamy problem (0,4) Vertical");
                    }
                    if (game.gameBoard.arr[0, 4] == CellState.X &&          //[1,4]
                        game.gameBoard.arr[1, 4] == CellState.Empty &&
                        game.gameBoard.arr[2, 4] == CellState.X &&
                        game.gameBoard.arr[3, 4] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 4], "mamy problem (1,4) Vertical");
                    }
                    if (game.gameBoard.arr[0, 4] == CellState.X &&          //[2,4]
                        game.gameBoard.arr[1, 4] == CellState.X &&
                        game.gameBoard.arr[2, 4] == CellState.Empty &&
                        game.gameBoard.arr[3, 4] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 4], "mamy problem (0,4) Vertical");
                    }
                    if (game.gameBoard.arr[0, 4] == CellState.X &&          //[4,4]
                        game.gameBoard.arr[1, 4] == CellState.X &&
                        game.gameBoard.arr[2, 4] == CellState.X &&
                        game.gameBoard.arr[3, 4] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 4], "mamy problem (4,4) Vertical");
                    }




                }
                else if (game.SetBlockCPUDiagonal() == true)
                {
                    game.SetBlockCPUDiagonal();
                    if (game.gameBoard.arr[0, 0] == CellState.Empty &&          //[0,0]
                        game.gameBoard.arr[1, 1] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 0], "mamy problem (0,0) Diagonal");
                    }
                    if (game.gameBoard.arr[0, 0] == CellState.X &&          //[1,1]
                        game.gameBoard.arr[1, 1] == CellState.Empty &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 1], "mamy problem (1,1) Diagonal");
                    }
                    if (game.gameBoard.arr[0, 0] == CellState.X &&          //[2,2]
                        game.gameBoard.arr[1, 1] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.Empty &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 2], "mamy problem (2,2) Diagonal");
                    }
                    if (game.gameBoard.arr[0, 0] == CellState.X &&          //[4,4]
                        game.gameBoard.arr[1, 1] == CellState.X &&
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 3] == CellState.X &&
                        game.gameBoard.arr[4, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 4], "mamy problem (4,4) Diagonal");
                    }
                    if (game.gameBoard.arr[1, 3] == CellState.X &&          //[0,4]
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 1] == CellState.X &&
                        game.gameBoard.arr[4, 0] == CellState.X &&
                        game.gameBoard.arr[0, 4] == CellState.Empty)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[0, 4], "mamy problem (0,4) Diagonal");
                    }
                    if (game.gameBoard.arr[1, 3] == CellState.Empty &&          //[1,3]
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 1] == CellState.X &&
                        game.gameBoard.arr[4, 0] == CellState.X &&
                        game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[1, 3], "mamy problem (1,3) Diagonal");
                    }
                    if (game.gameBoard.arr[1, 3] == CellState.X &&          //[2,2]
                        game.gameBoard.arr[2, 2] == CellState.Empty &&
                        game.gameBoard.arr[3, 1] == CellState.X &&
                        game.gameBoard.arr[4, 0] == CellState.X &&
                        game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[2, 2], "mamy problem (2,2) Diagonal");
                    }
                    if (game.gameBoard.arr[1, 3] == CellState.X &&          //[4,0]
                        game.gameBoard.arr[2, 2] == CellState.X &&
                        game.gameBoard.arr[3, 1] == CellState.X &&
                        game.gameBoard.arr[4, 0] == CellState.Empty &&
                        game.gameBoard.arr[0, 4] == CellState.X)
                    {
                        Assert.AreEqual(CellState.O, game.gameBoard.arr[4, 0], "mamy problem (4,0) Diagonal");
                    }



                }
                else
                {
                    game.SetBlockCPURandom();
                }

                Assert.AreEqual(true, game.player1Turn == true, "Brak Rundy dla gracza");

            }
        }


    }
}



