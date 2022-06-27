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
using System.IO;
namespace minesweeper
{
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }
        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();

            mainMenu.Label_Difficulty.Content = "Difficulty is set to: easy";
            ((MainWindow)Application.Current.MainWindow).Content = mainMenu;
            File.WriteAllText(@"C:/Users/grzes/Desktop/si szarp/minesweeper/minesweeper/TextFile1.txt", "difficulty: 5");    
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();

            mainMenu.Label_Difficulty.Content = "Difficulty is set to: normal";
            ((MainWindow)Application.Current.MainWindow).Content = mainMenu;
            File.WriteAllText(@"C:/Users/grzes/Desktop/si szarp/minesweeper/minesweeper/TextFile1.txt", "difficulty: 10");
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();

            mainMenu.Label_Difficulty.Content = "Difficulty is set to: hard";
            ((MainWindow)Application.Current.MainWindow).Content = mainMenu;
            File.WriteAllText(@"C:/Users/grzes/Desktop/si szarp/minesweeper/minesweeper/TextFile1.txt", "difficulty: 15");
        }
       
        
        //BACK BUTTON
        private void BT_Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            ((MainWindow)Application.Current.MainWindow).Content = mainMenu;
        }
    }
}
