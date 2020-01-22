using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // przycisk który przenosi nas do gry 
        {
            var GameWindow = new MainWindow();
            
            GameWindow.Show();  // otwiera okno z gra
            this.Close();     // gasi ekran startowy 

          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // przycisk gaszący gre
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var PlayerVsCpu = new PlayerVSCpu();
            PlayerVsCpu.Show();
            this.Close();
        }
    }
}
