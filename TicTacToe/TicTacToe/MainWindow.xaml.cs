using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToeLibrary;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game newGame;
        List<Button> bList;
        
        public MainWindow()
        {
            InitializeComponent();
            newGame = new Game();
            bList = new List<Button>();
            WriteScore();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!newGame.isOver)
            {
                var button = (Button)sender;
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);
                newGame.SetBlock(row, column);
                bList.Add(button);
                if (newGame.gameBoard.arr[row, column] == CellState.X)
                    button.Content = "X";
                if (newGame.gameBoard.arr[row, column] == CellState.O)
                    button.Content = "O";
                WriteScore();
            }
            else
            {
                newGame.Reset();
                ClearBoard();
                WriteScore();
            }
        }
        private void ClearBoard()
        {
            foreach (Button b in bList)
            {
                b.Content = "";
            }
        }
        private void WriteScore()
        {
            txtbox2.Text = $"Gracz 1 : {newGame.p1Score}     Gracz 2 : {newGame.p2Score}";
        }
        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            var menu = new MenuWindow();
            menu.Show();
            this.Close();
        }
    }
}
