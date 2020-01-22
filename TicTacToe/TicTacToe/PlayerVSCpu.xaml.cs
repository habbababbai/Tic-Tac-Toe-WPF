using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicTacToeLibrary;

namespace TicTacToe
{
    
    public partial class PlayerVSCpu : Window
    {
        
        Game newGame;
        
        Button[,] btnList;

        public PlayerVSCpu()
        {
            InitializeComponent();
            newGame = new Game();
            WriteScore();
            btnList = new Button[,] { {b0_0, b0_1, b0_2, b0_3, b0_4 },
                                    {b1_0, b1_1, b1_2, b1_3, b1_4 },
                                    {b2_0, b2_1, b2_2, b2_3, b2_4 },
                                    {b3_0, b3_1, b3_2, b3_3, b3_4 },
                                    {b4_0, b4_1, b4_2, b4_3, b4_4 } };
            
        }
                
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!newGame.isOver)
            {
                var button = (Button)sender;
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);

                newGame.SetBlock(row, column);
                if (newGame.gameBoard.arr[row,column] == CellState.X)
                    button.Content = "X";
                
                if (!newGame.isOver)
                {
                    newGame.SetBlockCPU();
                    btnList[newGame.lastXCPU, newGame.lastYCPU].Content = "O";
                  
                }
                WriteScore();
            }
            else
            {
                newGame.Reset();
                ClearBoard();
                WriteScore();
            }
        }
        
        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            var menu = new MenuWindow();
            menu.Show();
            this.Close();
        }
        private void ClearBoard()
        {
            for (int i = 0; i < btnList.GetLength(0); i++)
            {
                for (int j = 0; j < btnList.GetLength(1); j++)
                {
                    btnList[i, j].Content = "";
                }
            }
        }
        private void WriteScore()
        {
            
            txtbox2.Text = $"Gracz : {newGame.p1Score}     Komputer : {newGame.p2Score}";
        }

       
    }
}
