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
    /// Interaction logic for ConquerItAllView.xaml
    /// </summary>
    public partial class ConquerItAllView : Window
    {
        private bool finishTerritorySwap = false;
        public CIAViewModel vm;
        public CIAModel m;

        public ConquerItAllView()
        {
            InitializeComponent();
        }

        private void Cards_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //CardDialog.Visibility = Visibility.Visible;
        }

        #region CurrentPhase

        public String CurrentPhase
        {
            get { return (string)GetValue(CurrentPhaseMessageProperty); }
            set { SetValue(CurrentPhaseMessageProperty, value); }
        }

        public static readonly DependencyProperty CurrentPhaseMessageProperty =
            DependencyProperty.Register(
                "CurrentPhase", typeof(string), typeof(ConquerItAllView),
                new UIPropertyMetadata(string.Empty));

        #endregion

        #region CurrentPlayer

        public String CurrentPlayer
        {
            get { return (string)GetValue(CurrentPlayerMessageProperty); }
            set { SetValue(CurrentPlayerMessageProperty, value); }
        }

        public static readonly DependencyProperty CurrentPlayerMessageProperty =
            DependencyProperty.Register(
                "CurrentPlayer", typeof(string), typeof(ConquerItAllView),
                new UIPropertyMetadata(string.Empty));

        #endregion

        private void NextStageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (vm.GetCurrentPhase() == "Fortification")
            {
                vm.MoveToNextPlayer();
                vm.MoveToNextPhase();
            }
            else
            {
                vm.MoveToNextPhase();
            }
        }

        public void StartTerritoryGrab()
        {
            CurrentStageLabel.Text = "Territory Grab";
            PlayerNameLabel.Text = vm.GetCurrentPlayer();
        }

        public void SetPlayerAndPhase(string player, string phase)
        {
            CurrentStageLabel.Text = phase;
            PlayerNameLabel.Text = player;
        }

        public void Recruitment()
        {

            InfantryToAdd.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
        }

        private void Territory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label TerritoryLabel = (Label)sender;
            Territory selectedTerritory;
            List<Territory> territoryList = vm.GetTerritoryList();
            finishTerritorySwap = vm.TerritoryGrab(TerritoryLabel.Name);

            string stage = vm.GetCurrentPhase();

            if (stage == "Reinforcement")
            {
                TerritoryLabel.BorderThickness = new Thickness(2);
                TerritoryLabel.BorderBrush = Brushes.White;
                TerritoryLabel.Foreground = Brushes.Black;
            }
            if (stage == "Attack")
            {
            }
            if (stage == "Fortification")
            {
            }

            if (finishTerritorySwap == false && stage != "Reinforcement" && stage != "Attack" && stage != "Fortification")
            {
                foreach (Territory _territory in territoryList)
                {
                    string a = _territory.GetName();
                    string b = TerritoryLabel.Name;
                    if (a == b)
                    {
                        selectedTerritory = new Territory(_territory.GetName());

                        Player _player = new Player();

                        foreach (Player P in vm.GetCurrentPlayers())
                        {
                            if (P.Name == vm.GetCurrentPlayer())
                            {
                                _player = P;
                            }
                        }


                        _player.Territories.Add(selectedTerritory);
                        _player.TerritoryLabels.Add(TerritoryLabel);

                        MarkAsCurrentPlayersTerritory(TerritoryLabel, _player);
                        PlayerNameLabel.Text = vm.MoveToNextPlayer();
                        break;
                    }
                }
            }
        }

        private void MarkAsCurrentPlayersTerritory(Label Territory, Player _player)
        {
            Territory.Background = _player.Color;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new CIAViewModel(this);
            m = new CIAModel(this);
            StartDialog sd = new StartDialog(this);
            sd.Owner = this;
            sd.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            sd.Visibility = Visibility.Visible;
        }

        public void ShowActionLabels()
        {
            CurrentStageActionLabel1.Visibility = Visibility.Visible;
            CurrentStageActionLabel2.Visibility = Visibility.Visible;
        }

        public void ActionLabel1Text(string text)
        {
            CurrentStageActionLabel1.Text = text;
        }

        public void ActionLabel2Text(string text)
        {
            CurrentStageActionLabel2.Text = text;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        internal void Attack()
        {
            throw new NotImplementedException();
        }

        internal void Fortification()
        {
            throw new NotImplementedException();
        }
    }
}
