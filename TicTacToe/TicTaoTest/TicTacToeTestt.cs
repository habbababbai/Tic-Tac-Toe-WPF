using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLibrary;

namespace TicTacToeTestt
{
    [TestClass]
    public class BoardTest
    {

        public CellState[,] arr = new CellState[5, 5];

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
            Assert.AreEqual(25, k, "Tablice nie s¹ równe");
            Assert.AreEqual(5, l, "Tablice nie s¹ równe");
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

                Assert.AreEqual(false, game.isOver, "Gra Nie zosta³a zrestartowana");
                Assert.AreEqual(true, game.player1Turn, "Gra nie zosta³a zrestartowana");



            }

            [TestMethod]
            public void EndGameTest()
            {
                Assert.AreEqual(false, game.isOver, "Gra Nie Zosta³a zakonczona");

            }
            [TestMethod]
            public void CheckDrawTest()
            {

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
            public void SetBlockTest(int x, int y)
            {

                Game game = new Game();



            }

            //UWAGA SPAM CPU xD

            [TestMethod]
            public void CPUTEST()
            {
                Game game = new Game();


                if (game.gameBoard.arr[0, 1] == CellState.X)    //[0,0]
                    if (game.gameBoard.arr[0, 2] == CellState.X)
                        if (game.gameBoard.arr[0, 3] == CellState.X)
                            if (game.gameBoard.arr[0, 4] == CellState.X)
                                if (game.gameBoard.arr[0, 0] == CellState.O)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }

                if (game.gameBoard.arr[0, 1] == CellState.O)
                    if (game.gameBoard.arr[0, 2] == CellState.X)
                        if (game.gameBoard.arr[0, 3] == CellState.X)
                            if (game.gameBoard.arr[0, 4] == CellState.X)
                                if (game.gameBoard.arr[0, 0] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }

                if (game.gameBoard.arr[0, 1] == CellState.X)
                    if (game.gameBoard.arr[0, 2] == CellState.O)
                        if (game.gameBoard.arr[0, 3] == CellState.X)
                            if (game.gameBoard.arr[0, 4] == CellState.X)
                                if (game.gameBoard.arr[0, 0] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 1] == CellState.X)
                    if (game.gameBoard.arr[0, 2] == CellState.X)
                        if (game.gameBoard.arr[0, 3] == CellState.O)
                            if (game.gameBoard.arr[0, 4] == CellState.X)
                                if (game.gameBoard.arr[0, 0] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 1] == CellState.X)
                    if (game.gameBoard.arr[0, 2] == CellState.X)
                        if (game.gameBoard.arr[0, 3] == CellState.X)
                            if (game.gameBoard.arr[0, 4] == CellState.O)
                                if (game.gameBoard.arr[0, 0] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 0] == CellState.O) // [1,0]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[1, 2] == CellState.X)
                            if (game.gameBoard.arr[1, 3] == CellState.X)
                                if (game.gameBoard.arr[1, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 0] == CellState.X) // [1,1]
                    if (game.gameBoard.arr[1, 1] == CellState.O)
                        if (game.gameBoard.arr[1, 2] == CellState.X)
                            if (game.gameBoard.arr[1, 3] == CellState.X)
                                if (game.gameBoard.arr[1, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 0] == CellState.X) // [1,2]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[1, 2] == CellState.O)
                            if (game.gameBoard.arr[1, 3] == CellState.X)
                                if (game.gameBoard.arr[1, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 0] == CellState.X) // [1,3]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[1, 2] == CellState.X)
                            if (game.gameBoard.arr[1, 3] == CellState.O)
                                if (game.gameBoard.arr[1, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 0] == CellState.X) // [1,4]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[1, 2] == CellState.X)
                            if (game.gameBoard.arr[1, 3] == CellState.X)
                                if (game.gameBoard.arr[1, 4] == CellState.O)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[2, 0] == CellState.O) // [2,0]
                    if (game.gameBoard.arr[2, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[2, 3] == CellState.X)
                                if (game.gameBoard.arr[2, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[2, 0] == CellState.X) // [2,1]
                    if (game.gameBoard.arr[2, 1] == CellState.O)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[2, 3] == CellState.X)
                                if (game.gameBoard.arr[2, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[2, 0] == CellState.X) // [2,2]
                    if (game.gameBoard.arr[2, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.O)
                            if (game.gameBoard.arr[2, 3] == CellState.X)
                                if (game.gameBoard.arr[2, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[2, 0] == CellState.O) // [2,3]
                    if (game.gameBoard.arr[2, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[2, 3] == CellState.X)
                                if (game.gameBoard.arr[2, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[2, 0] == CellState.X) // [2,4]
                    if (game.gameBoard.arr[2, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[2, 3] == CellState.X)
                                if (game.gameBoard.arr[2, 4] == CellState.O)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.O) // [4,0]
                    if (game.gameBoard.arr[4, 1] == CellState.X)
                        if (game.gameBoard.arr[4, 2] == CellState.X)
                            if (game.gameBoard.arr[4, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [4,1]
                    if (game.gameBoard.arr[4, 1] == CellState.O)
                        if (game.gameBoard.arr[4, 2] == CellState.X)
                            if (game.gameBoard.arr[4, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [4,2]
                    if (game.gameBoard.arr[4, 1] == CellState.X)
                        if (game.gameBoard.arr[4, 2] == CellState.O)
                            if (game.gameBoard.arr[4, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [4,3]
                    if (game.gameBoard.arr[4, 1] == CellState.X)
                        if (game.gameBoard.arr[4, 2] == CellState.X)
                            if (game.gameBoard.arr[4, 3] == CellState.O)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [4,4]
                    if (game.gameBoard.arr[4, 1] == CellState.X)
                        if (game.gameBoard.arr[4, 2] == CellState.X)
                            if (game.gameBoard.arr[4, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }


                //Pionowe CPU

                if (game.gameBoard.arr[0, 0] == CellState.O) // [0,0]
                    if (game.gameBoard.arr[1, 0] == CellState.X)
                        if (game.gameBoard.arr[2, 0] == CellState.X)
                            if (game.gameBoard.arr[3, 0] == CellState.X)
                                if (game.gameBoard.arr[4, 0] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 0] == CellState.X) // [1,0]
                    if (game.gameBoard.arr[1, 0] == CellState.O)
                        if (game.gameBoard.arr[2, 0] == CellState.X)
                            if (game.gameBoard.arr[3, 0] == CellState.X)
                                if (game.gameBoard.arr[4, 0] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 0] == CellState.X) // [4,0]
                    if (game.gameBoard.arr[1, 0] == CellState.X)
                        if (game.gameBoard.arr[2, 0] == CellState.X)
                            if (game.gameBoard.arr[3, 0] == CellState.X)
                                if (game.gameBoard.arr[4, 0] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 1] == CellState.X) // [4,1]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 1] == CellState.X)
                            if (game.gameBoard.arr[3, 1] == CellState.X)
                                if (game.gameBoard.arr[4, 1] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 2] == CellState.O) // [0,2]
                    if (game.gameBoard.arr[1, 2] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 2] == CellState.X)
                                if (game.gameBoard.arr[4, 2] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[1, 2] == CellState.X) // [1,2]
                    if (game.gameBoard.arr[1, 2] == CellState.O)
                        if (game.gameBoard.arr[1, 2] == CellState.X)
                            if (game.gameBoard.arr[1, 2] == CellState.X)
                                if (game.gameBoard.arr[1, 2] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 2] == CellState.X) // [2,2]
                    if (game.gameBoard.arr[1, 2] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.O)
                            if (game.gameBoard.arr[3, 2] == CellState.X)
                                if (game.gameBoard.arr[4, 2] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 2] == CellState.X) // [4,2]
                    if (game.gameBoard.arr[1, 2] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 2] == CellState.X)
                                if (game.gameBoard.arr[4, 2] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 3] == CellState.O) // [0,3]
                    if (game.gameBoard.arr[1, 3] == CellState.X)
                        if (game.gameBoard.arr[2, 3] == CellState.X)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 3] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 3] == CellState.X) // [2,3]
                    if (game.gameBoard.arr[1, 3] == CellState.X)
                        if (game.gameBoard.arr[2, 3] == CellState.O)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 3] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 3] == CellState.X) // [4,3]
                    if (game.gameBoard.arr[1, 3] == CellState.X)
                        if (game.gameBoard.arr[2, 3] == CellState.X)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 3] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 4] == CellState.O) // [0,4]
                    if (game.gameBoard.arr[1, 4] == CellState.X)
                        if (game.gameBoard.arr[2, 4] == CellState.X)
                            if (game.gameBoard.arr[3, 4] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 4] == CellState.X) // [1,4]
                    if (game.gameBoard.arr[1, 4] == CellState.O)
                        if (game.gameBoard.arr[2, 4] == CellState.X)
                            if (game.gameBoard.arr[3, 4] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 4] == CellState.X) // [2,4]
                    if (game.gameBoard.arr[1, 4] == CellState.X)
                        if (game.gameBoard.arr[2, 4] == CellState.O)
                            if (game.gameBoard.arr[3, 4] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 4] == CellState.X) // [4,4]
                    if (game.gameBoard.arr[1, 4] == CellState.X)
                        if (game.gameBoard.arr[2, 4] == CellState.X)
                            if (game.gameBoard.arr[3, 4] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }

                //UKOSY
                if (game.gameBoard.arr[0, 0] == CellState.O) // [0,0]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(0, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 0] == CellState.X) // [1,1]
                    if (game.gameBoard.arr[1, 1] == CellState.O)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(1, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 0] == CellState.X) // [2,2]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.O)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[0, 0] == CellState.X) // [4,4]
                    if (game.gameBoard.arr[1, 1] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 3] == CellState.X)
                                if (game.gameBoard.arr[4, 4] == CellState.O)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(4, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [1,3]
                    if (game.gameBoard.arr[1, 3] == CellState.O)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 1] == CellState.X)
                                if (game.gameBoard.arr[0, 4] == CellState.X)
                                {
                                    Assert.AreEqual(1, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(3, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.X) // [2,2]
                    if (game.gameBoard.arr[1, 3] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.O)
                            if (game.gameBoard.arr[3, 1] == CellState.X)
                                if (game.gameBoard.arr[0, 4] == CellState.X)
                                {
                                    Assert.AreEqual(2, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(2, game.lastYCPU, "Kolumna zly");
                                }
                if (game.gameBoard.arr[4, 0] == CellState.O) // [4,0]
                    if (game.gameBoard.arr[1, 3] == CellState.X)
                        if (game.gameBoard.arr[2, 2] == CellState.X)
                            if (game.gameBoard.arr[3, 1] == CellState.X)
                                if (game.gameBoard.arr[0, 4] == CellState.X)
                                {
                                    Assert.AreEqual(4, game.lastXCPU, "Wiersz zly");
                                    Assert.AreEqual(0, game.lastYCPU, "Kolumna zly");
                                }

            }
        }

    }
}



