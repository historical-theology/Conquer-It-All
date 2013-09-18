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

namespace Conquer_It_All
{
    /// <summary>
    /// Interaction logic for StartDialog.xaml
    /// </summary>
    public partial class StartDialog : Window
    {
        private Int32 NumberPlayers;
        private ConquerItAllView cv;

        public StartDialog()
        {
            InitializeComponent();
        }

        public StartDialog(ConquerItAllView cv)
        {
            InitializeComponent();
            this.cv = cv;
        }

        private void _2PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Label.Visibility = Visibility.Visible;
            Player2Label.Visibility = Visibility.Visible;
            Player1Name.Visibility = Visibility.Visible;
            Player2Name.Visibility = Visibility.Visible;
            Player1Color.Visibility = Visibility.Visible;
            Player2Color.Visibility = Visibility.Visible;
            NumberPlayers = 2;
            cv.vm.SetNumberOfPlayers(2);
            StartGameButton.Visibility = Visibility.Visible;
        }

        private void _3PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Label.Visibility = Visibility.Visible;
            Player2Label.Visibility = Visibility.Visible;
            Player3Label.Visibility = Visibility.Visible;
            Player1Name.Visibility = Visibility.Visible;
            Player2Name.Visibility = Visibility.Visible;
            Player3Name.Visibility = Visibility.Visible;
            Player1Color.Visibility = Visibility.Visible;
            Player2Color.Visibility = Visibility.Visible;
            Player3Color.Visibility = Visibility.Visible;
            NumberPlayers = 3;
            cv.vm.SetNumberOfPlayers(3);
            StartGameButton.Visibility = Visibility.Visible;
        }

        private void _4PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Label.Visibility = Visibility.Visible;
            Player2Label.Visibility = Visibility.Visible;
            Player3Label.Visibility = Visibility.Visible;
            Player4Label.Visibility = Visibility.Visible;
            Player1Name.Visibility = Visibility.Visible;
            Player2Name.Visibility = Visibility.Visible;
            Player3Name.Visibility = Visibility.Visible;
            Player4Name.Visibility = Visibility.Visible;
            Player1Color.Visibility = Visibility.Visible;
            Player2Color.Visibility = Visibility.Visible;
            Player3Color.Visibility = Visibility.Visible;
            Player4Color.Visibility = Visibility.Visible;

            NumberPlayers = 4;
            cv.vm.SetNumberOfPlayers(4);
            StartGameButton.Visibility = Visibility.Visible;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumberPlayers == 2)
            {
                if(Player1Name.Text != "Player 1 Name" && Player2Name.Text != "Player 2 Name")
                {
                    Brush Color1 = new SolidColorBrush(Player1Color.SelectedColor);
                    Brush Color2 = new SolidColorBrush(Player2Color.SelectedColor);

                    cv.vm.AddPlayer(Player1Name.Text, Color1);
                    cv.vm.AddPlayer(Player2Name.Text, Color2);
                }
                else
                {
                    if(Player1Name.Text == "Player 1 Name")
                    {
                        Player1Name.BorderBrush = Brushes.Red;
                        Player1Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player2Name.Text == "Player 2 Name")
                    {
                        Player2Name.BorderBrush = Brushes.Red;
                        Player2Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                }
            }
            if (NumberPlayers == 3)
            {
                if (Player1Name.Text != "Player 1 Name" && Player2Name.Text != "Player 2 Name" && Player3Name.Text != "Player 3 Name")
                {
                    Brush Color1 = new SolidColorBrush(Player1Color.SelectedColor);
                    Brush Color2 = new SolidColorBrush(Player2Color.SelectedColor);
                    Brush Color3 = new SolidColorBrush(Player3Color.SelectedColor);

                    cv.vm.AddPlayer(Player1Name.Text, Color1);
                    cv.vm.AddPlayer(Player2Name.Text, Color2);
                    cv.vm.AddPlayer(Player3Name.Text, Color3);
                }
                else
                {
                    if(Player1Name.Text == "Player 1 Name")
                    {
                        Player1Name.BorderBrush = Brushes.Red;
                        Player1Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player2Name.Text == "Player 2 Name")
                    {
                        Player2Name.BorderBrush = Brushes.Red;
                        Player2Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player3Name.Text == "Player 3 Name")
                    {
                        Player3Name.BorderBrush = Brushes.Red;
                        Player3Name.BorderThickness = new Thickness(5.0, 5.0, 5.0, 5.0);
                    }
                }
            }
            if (NumberPlayers == 4)
            {
                if (Player1Name.Text != "Player 1 Name" && Player2Name.Text != "Player 2 Name" && Player3Name.Text != "Player 3 Name" && Player4Name.Text != "Player 4 Name")
                {
                    Brush Color1 = new SolidColorBrush(Player1Color.SelectedColor);
                    Brush Color2 = new SolidColorBrush(Player2Color.SelectedColor);
                    Brush Color3 = new SolidColorBrush(Player3Color.SelectedColor);
                    Brush Color4 = new SolidColorBrush(Player4Color.SelectedColor);

                    cv.vm.AddPlayer(Player1Name.Text, Color1);
                    cv.vm.AddPlayer(Player2Name.Text, Color2);
                    cv.vm.AddPlayer(Player3Name.Text, Color3);
                    cv.vm.AddPlayer(Player4Name.Text, Color4);
                }
                else
                {
                    if(Player1Name.Text == "Player 1 Name")
                    {
                        Player1Name.BorderBrush = Brushes.Red;
                        Player1Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player2Name.Text == "Player 2 Name")
                    {
                        Player2Name.BorderBrush = Brushes.Red;
                        Player2Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player3Name.Text == "Player 3 Name")
                    {
                        Player3Name.BorderBrush = Brushes.Red;
                        Player3Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                    if(Player4Name.Text == "Player 4 Name")
                    {
                        Player4Name.BorderBrush = Brushes.Red;
                        Player4Name.BorderThickness = new Thickness(5.0,5.0,5.0,5.0);
                    }
                }
            }

            this.Visibility = Visibility.Hidden;
            cv.vm.StartGame();
            cv.vm.CreateGameBoard();
       }

        private void Player1Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Player1Name.BorderBrush = null;
            if(Player1Name.Text == "Player 1 Name")
                Player1Name.Text = "";
        }

        private void Player2Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Player2Name.BorderBrush = null;
            if (Player2Name.Text == "Player 2 Name") 
                Player2Name.Text = "";
        }

        private void Player3Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Player3Name.BorderBrush = null;
            if (Player3Name.Text == "Player 3 Name") 
                Player3Name.Text = "";
        }

        private void Player4Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Player4Name.BorderBrush = null;
            if (Player4Name.Text == "Player 4 Name") 
                Player4Name.Text = "";
        }

        private void Player1Name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Player1Name.Text == "Player 1 Name")
                Player1Name.Text = "";
        }

        private void Player2Name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Player2Name.Text == "Player 2 Name")
                Player2Name.Text = "";
        }

        private void Player3Name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Player3Name.Text == "Player 3 Name")
                Player3Name.Text = "";
        }

        private void Player4Name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Player4Name.Text == "Player 4 Name")
                Player4Name.Text = "";
        }
    }
}
