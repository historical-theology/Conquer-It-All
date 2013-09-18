using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace Conquer_It_All
{
    public class CIAViewModel
    {
        private ConquerItAllView _CIA;
        private static CIAModel CIAM;
        private static List<Territory> availableTerritories = CIAModel.GetAvailableTerritories();
        private bool[] firstTimeThrough = { false, false, false, false };

        public CIAViewModel(ConquerItAllView CIA)
        {
            _CIA = CIA;
            CIAM = new CIAModel(_CIA);
        }

        public void SetNumberOfPlayers(Int32 Num)
        {
            CIAModel.NumberPlayers = Num;
        }

        public void CreateGameBoard()
        {
            CIAM.CreateGameBoard();
        }

        public bool TerritoryGrab(String name)
        {
            if (availableTerritories.Count == 1)
            {
                _CIA.SetPlayerAndPhase(CIAM.GetPlayers()[0].Name, MoveToNextPhase());
                startRecruitment();
                
                foreach (Territory T in availableTerritories)
                {
                    if (T.GetName() == name)
                    {
                        availableTerritories.Remove(T);
                        return false;
                    }
                }
            }

            if (availableTerritories.Count > 0)
            {
                foreach (Territory T in availableTerritories)
                {
                    if (T.GetName() == name)
                    {
                        availableTerritories.Remove(T);
                        return false;
                    }
                }
            }

            return true;
        }

        private void startRecruitment()
        {
            _CIA.ShowActionLabels();

            string currentPlayerName = GetCurrentPlayer();
            List<Player> Players = CIAM.GetPlayers();
            Player[] players = new Player[Players.Count()];

            for (int i = 0; i < Players.Count(); i++)
            {
                players[i] = Players[i];
            }

            Player currentPlayer = new Player();

            foreach (Player p in Players)
            {
                if(p.Name == currentPlayerName)
                    currentPlayer = p;
            }

            int playerPosition = Array.IndexOf(players, currentPlayer);
            int infantryReceived = currentPlayer.Territories.Count() / 3;

            if (firstTimeThrough[playerPosition] == false)
            {
                if (Players.Count() == 2)
                {
                    int infantry = 30 + infantryReceived;
                    currentPlayer.GiveInfantry(infantry);
                    _CIA.ActionLabel1Text("New Infantry: " + infantry);
                    _CIA.ActionLabel2Text("Infantry Left: " + infantry);
                }
                if (Players.Count() == 2)
                {
                    int infantry = 35 + infantryReceived;
                    currentPlayer.GiveInfantry(35 + infantryReceived);
                    _CIA.ActionLabel1Text("New Infantry: " + infantry);
                    _CIA.ActionLabel2Text("Infantry Left: " + infantry);
                }
                if (Players.Count() == 2)
                {
                    int infantry = 40 + infantryReceived;
                    currentPlayer.GiveInfantry(infantry);
                    _CIA.ActionLabel1Text("New Infantry: " + infantry);
                    _CIA.ActionLabel2Text("Infantry Left: " + infantry);
                }
                firstTimeThrough[playerPosition] = true;
            }
            else
            {
                currentPlayer.GiveInfantry(infantryReceived);
                _CIA.ActionLabel1Text("New Infantry: " + infantryReceived);
                _CIA.ActionLabel2Text("Infantry Left: " + infantryReceived);
            }
        }

        public void AddPlayer(String PlayerName, Brush Color)
        {
            Player NewPlayer = new Player();
            NewPlayer.Name = PlayerName;
            NewPlayer.Color = Color;
            CIAM.GetPlayers().Add(NewPlayer);
        }

        public List<Territory> GetTerritoryList()
        {
            return CIAModel.GetTerritoryList();
        }

        public void ExchangeCards(Card CardTypeToExchange, Int32 Amount)
        {

        }

        public void MoveInfantry(Territory SourceTerritory, Territory DestinationTerritory, Int32 NumberOfTroops)
        {
            SourceTerritory.RemoveInfantry(NumberOfTroops);
            SourceTerritory.AddInfantry(NumberOfTroops);
        }

        public String MoveToNextPhase()
        {
            String[] Phases = CIAM.GetPhases();
            String CurrentPlayerPhase = _CIA.CurrentPhase;

            if (CurrentPlayerPhase == "Territory Grab")
            {
                _CIA.Recruitment();
                return "Recruitment";
            }

            for (int i = 0; i < Phases.Count(); i++)
            {
                if (CurrentPlayerPhase == Phases[i])
                {
                    int a = i + 1;
                    if (a < Phases.Count())
                    {
                        CurrentPlayerPhase = Phases[a];
                        if (CurrentPlayerPhase == "Recruitment")
                            _CIA.Recruitment();
                        if (CurrentPlayerPhase == "Attack")
                            _CIA.Attack();
                        if (CurrentPlayerPhase == "Fortification")
                            _CIA.Fortification();
                        break;
                    }
                    else
                    {
                        CurrentPlayerPhase = Phases[0];
                        if (CurrentPlayerPhase == "Recruitment")
                            _CIA.Recruitment();
                        break;
                    }
                }
            }

            return CurrentPlayerPhase;
        }

        public string MoveToNextPlayer()
        {
            List<Player> Players = CIAM.GetPlayers();
            string CurrentPlayerTurn = _CIA.CurrentPlayer;

            for(int i = 0; i < Players.Count(); i ++)
            {
                if(CurrentPlayerTurn == Players[i].Name)
                {
                    int a = i + 1;
                    if (a < Players.Count())
                    {
                        _CIA.CurrentPlayer = Players[i + 1].Name;
                    }
                    else
                    {
                        _CIA.CurrentPlayer = Players[0].Name;
                    }
                }
            }

            return CurrentPlayerTurn;
        }

        public Player DecideBattle(Player Attacker, Player Defender, Territory Attacking, Territory Defending, Int32 NumberAttackerDice, Int32 NumberDefenderDice)
        {
            Int32[] AttackDiceResults = new Int32[NumberAttackerDice];
            Int32[] DefenseDiceResults = new Int32[NumberDefenderDice];

            for (int i = 0; i < NumberAttackerDice; i++)
            {
                AttackDiceResults[i] = CIAM.GetAttackerDice()[i].Next(1, 6);
            }

            for (int i = 0; i < NumberDefenderDice; i++)
            {
                DefenseDiceResults[i] = CIAM.GetDefenderDice()[i].Next(1, 6);
            }

            Player[] BattleResults = new Player[NumberDefenderDice];

            for (int i = 0; i < NumberDefenderDice; i++)
            {
                if (AttackDiceResults[i] > DefenseDiceResults[i])
                    BattleResults[i] = Attacker;
                else
                    BattleResults[i] = Defender;
            }

            if (!BattleResults.Contains(Attacker))
            {
                Attacker.RemoveInfantry(BattleResults.Length);
                Attacking.RemoveInfantry(BattleResults.Length);
            }
            else
            {
                if (!BattleResults.Contains(Defender))
                {
                    Defender.RemoveInfantry(BattleResults.Length);
                    Defending.RemoveInfantry(BattleResults.Length);
                }
                else
                {
                    foreach (Player Fighter in BattleResults)
                    {
                        if (Fighter == Attacker)
                        {
                            Defender.RemoveInfantry(1);
                            Defending.RemoveInfantry(1);
                        }
                        if (Fighter == Defender)
                        {
                            Attacker.RemoveInfantry(1);
                            Attacking.RemoveInfantry(1);
                        }
                    }

                    if (Attacking.GetOccupyingInfantry() == 0)
                        return Defender;
                    if (Defending.GetOccupyingInfantry() == 0)
                        return Attacker;
                }
            }
            return null;
        }

        public void StartGame()
        {
            _CIA.CurrentPlayer = CIAM.GetPlayers()[0].Name;
            _CIA.CurrentPhase = "Territory Grab";
        }

        public string GetCurrentPlayer()
        {
            return _CIA.CurrentPlayer;
        }

        public String GetCurrentPhase()
        {
            return _CIA.CurrentPhase;
        }

        public List<Player> GetCurrentPlayers()
        {
            return CIAM.GetPlayers();
        }
    }
}
