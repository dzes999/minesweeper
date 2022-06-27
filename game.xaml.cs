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

namespace minesweeper
{
    public partial class Game : Page
    {
        Button[] buttons;
        int difficulty;
        public Game()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBoard();
        }
        public void CreateBoard()
        {
            Style style = this.FindResource("BT_Looks") as Style;
            //difficulty
            difficulty = Convert.ToInt32(System.IO.File.ReadAllText(@"C:/Users/grzes/Desktop/si szarp/minesweeper/minesweeper/TextFile1.txt").Split(" ")[1]);

            //creating buttons array
            buttons = new Button[difficulty * difficulty];

            //creating a grid
            Grid board = new Grid();

            //creating buttons
            for (int i = 0, j = 0; i < difficulty * difficulty; i++)
            {
                if ((i % difficulty) == 0 && i != 0)
                {
                    j++;
                }
                buttons[i] = new Button();
                buttons[i].Width = 25;
                buttons[i].Height = 25;
                buttons[i].Name = "BT_" + j + "_" + (i % difficulty);
                buttons[i].BorderThickness = new Thickness(0.5);
                buttons[i].Click += default_click;
                buttons[i].MouseRightButtonDown += rightclick;
                buttons[i].Content = 0;
                buttons[i].Foreground = new SolidColorBrush(Colors.White);
                buttons[i].Background = new SolidColorBrush(Colors.White);
                buttons[i].Style =  style;
            }

            //creating rows and columns
            for (int i = 0; i < difficulty; i++)
            {
                board.RowDefinitions.Add(new RowDefinition());
                board.ColumnDefinitions.Add(new ColumnDefinition());

                //setting buttons
                for (int j = 0; j < difficulty; j++)
                {
                    Grid.SetRow(buttons[j + (i * difficulty)], i);
                    Grid.SetColumn(buttons[j + (i * difficulty)], j);
                    board.Children.Add(buttons[j + (i * difficulty)]);
                }
            }

            //board alignment
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            this.Content = board;

            mines();
        }
        public void mines()
        {
            //creating and setting mines
            int mines;

            for (int i = 0; i < difficulty; i++)
            {
                Random rnd = new Random();
                mines = rnd.Next(1, difficulty * difficulty);
                buttons[mines].Tag = "boom";

                int help = 0;

                //proximity numeration
                if (mines < 24)
                {
                    help = Convert.ToInt32(buttons[mines + 1].Content);
                    help++;
                    buttons[mines +1].Content = help;
                    help = 0;
                }
                
                if (mines > 0)
                {
                    help = Convert.ToInt32(buttons[mines - 1].Content);
                    help++;
                    buttons[mines - 1].Content = help;
                    help = 0;
                }

                if (mines < 20)
                {
                    help = Convert.ToInt32(buttons[mines + 5].Content);
                    help++;
                    buttons[mines + 5].Content = help;
                    help = 0;
                }

                if(mines > 4)
                {
                    help = Convert.ToInt32(buttons[mines - 5].Content);
                    help++;
                    buttons[mines - 5].Content = help;
                    help = 0;
                }

                if (mines < 21)
                {
                    help = Convert.ToInt32(buttons[mines + 4].Content);
                    help++;
                    buttons[mines + 4].Content = help;
                    help = 0;
                }

                if (mines > 3)
                {
                    help = Convert.ToInt32(buttons[mines - 4].Content);
                    help++;
                    buttons[mines - 4].Content = help;
                    help = 0;
                }

                if (mines < 19)
                {
                    help = Convert.ToInt32(buttons[mines + 6].Content);
                    help++;
                    buttons[mines + 6].Content = help;
                    help = 0;
                }

                if (mines > 5)
                {
                    help = Convert.ToInt32(buttons[mines - 6].Content);
                    help++;
                    buttons[mines - 6].Content = help;
                    help = 0;
                }
            }
            for(int i = 0; i < difficulty*difficulty; i++)
            {
                if (buttons[i].Tag == "boom")
                {
                    buttons[i].Content = "";
                }
            }
        }
        private void default_click(object sender, RoutedEventArgs e)
        {
            //disabling the button
            ((Button)sender).IsEnabled = false;

            //losing
            if (((Button)sender).Tag == "boom")
            {
                MessageBox.Show("you lost");
                MainMenu mainMenu = new MainMenu();
                ((MainWindow)Application.Current.MainWindow).Content = mainMenu;
            }
        }
        private void rightclick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "flag";
        }
        private void flag()
        {
            
        }
    }
}
