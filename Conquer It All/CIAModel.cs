using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Conquer_It_All
{
    public class CIAModel : DataModel
    {
        private string[][] ConnectingTerritories = new string[][] 
        {
        new string[] {"2","22","28"}, new string[] {"1","3","8","22"}, new string[] {"2","4","5","7","22"},  
        new string[] {"3","5"}, new string[] {"3","4","6"}, new string[] {"5","7"},
        new string[] {"3","6","8","45"}, new string[] {"2","7","9"}, new string[] {"8","10","12","26"},
        new string[] {"9","11","25"}, new string[] {"10","12","15"}, new string[] {"9","11","44"},
        new string[] {"42","44"}, new string[] {"16","42"}, new string[] {"11","16"},
        new string[] {"14","15","18"}, new string[] {"18","20"}, new string[] {"16","17","19"},
        new string[] {"18","20","21"}, new string[] {"17","19","21"}, new string[] {"19","20"},
        new string[] {"1","2","3","23","41"}, new string[] {"22","24","41"}, new string[] {"23","41"},
        new string[] {"10","26","27","28"}, new string[] {"9","25"}, new string[] {"25","29","35"},
        new string[] {"1","25","32","35"}, new string[] {"27","30","35"}, new string[] {"29","31"},
        new string[] {"30","40"}, new string[] {"28","33","46"}, new string[] {"32","41"},
        new string[] {"41","46"}, new string[] {"27","28","46"}, new string[] {"37","46"},
        new string[] {"36","38","45"}, new string[] {"37","40"}, new string[] {"31","46"},
        new string[] {"22","23","24","33","34","38"}, new string[] {"13","14","42","44"}, new string[] {"41","44"},
        new string[] {"12","13","44"}, new string[] {"7","41","42","43"},new string[] {"32","34","35","37","46"},
        new string[] {"36","39","45"}
        };
        private string[][] AreaEnclosedTerritories = new string[][] 
        {
        new string[] {"Red","4","29","30","31","36","37","39","46"},    
        new string[] {"Yellow","5","33","34","37","38","40"},   
        new string[] {"Blue","2","32","35","45"},  
        new string[] {"Purple","7","9","10","11","12","15","25","26","28"}, 
        new string[] {"Brown","7","13","14","41","42","43","44"},
        new string[] {"Grey","4","17","18","19","20","21"},
        new string[] {"Orange","8","1","2","3","4","5","6","7","8","22","23","24"},
        };
        private static Int32 numPlayers = 0;
        private static List<Territory> TerritoryList = new List<Territory>();
        private static List<Territory> availableTerritories = new List<Territory>();
        private static List<Area> AreaList = new List<Area>();
        private List<Player> PlayerList = new List<Player>();
        private String[] Phases = { "Recruitment", "Attack", "Fortification" };
        private List<Random> AttackerDice;
        private List<Random> DefenderDice;
        private ConquerItAllView ciav;

        public CIAModel(ConquerItAllView ciav)
        {
            AttackerDice = new List<Random>();

            for (int i = 0; i < 3; i++)
            {
                AttackerDice.Add(new Random((int)DateTime.Now.Ticks & 0x0000FFFF));
                Thread.Sleep(50);
            }

            DefenderDice = new List<Random>();
            
            this.ciav = ciav;

            for (int i = 0; i < 2; i++)
            {
                DefenderDice.Add(new Random((int)DateTime.Now.Ticks & 0x0000FFFF));
                Thread.Sleep(50);
            }
        }

        public List<Random> GetAttackerDice()
        {
            return AttackerDice;
        }

        public static List<Territory> GetAvailableTerritories()
        {
            return availableTerritories;
        }

        public List<Random> GetDefenderDice()
        {
            return DefenderDice;
        }

        public static List<Territory> GetTerritoryList()
        {
            return TerritoryList;
        }

        public static Int32 NumberPlayers
        {
            get { return numPlayers; }
            set { numPlayers = value; }
        }

        public void CreateGameBoard()
        {
            CreateTerritories();
            CreateAreas();
        }

        public String[] GetPhases()
        {
            return Phases;
        }

        public List<Player> GetPlayers()
        {
            return PlayerList;
        }

        private void CreateAreas()
        {
            foreach (string[] EnclosingAreaList in AreaEnclosedTerritories)
            {
                Area TempArea = new Area(EnclosingAreaList[0], Convert.ToInt32(EnclosingAreaList[1]));
                List<Territory> EnclosedTerritory = new List<Territory>();

                for (int i = 2; i < EnclosingAreaList.Length; i++)
                {
                    string TerritoryName = "Territory" + EnclosingAreaList[i];
                    Territory TempTerritory = new Territory(TerritoryName);
                    EnclosedTerritory.Add(TempTerritory);
                }

                TempArea.AddEnclosedTerritories(EnclosedTerritory);

                AreaList.Add(TempArea);
            }
        }

        private void CreateTerritories()
        {
            int i = 1;
            foreach (string[] ConnectingTerritoryOriginNumber in ConnectingTerritories)
            {
                List<Territory> ConnectingTerritorieList = new List<Territory>();
                foreach (string ConnectingTerritory in ConnectingTerritoryOriginNumber)
                {
                    string ConnectingTerritoryName = "Territory" + ConnectingTerritory;
                    Territory Territory = new Territory(ConnectingTerritoryName);
                    ConnectingTerritorieList.Add(Territory);
                }
                string TerritoryName = "Territory" + i;
                Territory OfficialTerritory = new Territory(TerritoryName);
                OfficialTerritory.AddConnectingTerritories(ConnectingTerritorieList);
                TerritoryList.Add(OfficialTerritory);
                availableTerritories.Add(OfficialTerritory);
                i++;
            }
        }
    }
}
