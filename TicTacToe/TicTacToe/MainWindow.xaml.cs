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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeLibrary;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game newGame;
        public MainWindow()
        {
            InitializeComponent();
            newGame = new Game();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 5);
            newGame.SetBlock(row, column);
            if (newGame.gameBoard.arr[row, column] == CellState.X)
                button.Content = "X";
            if (newGame.gameBoard.arr[row, column] == CellState.O)
                button.Content = "O";
        }
    }
}
