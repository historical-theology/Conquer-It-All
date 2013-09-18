using Conquer_It_All.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_It_All
{
    public class Territory: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String Name;
        private Player _owner;
        private OccupyingInfantry OccupyingInfantry;
        private List<Territory> ConnectingTerritories;

        public Territory(String Name)
        {
            this.Name = Name;
            _owner = new Player();
            OccupyingInfantry = new OccupyingInfantry();
        }

        private void OnPropertyChanged(object sender, string PropertyThatChanged)
        {
            if (PropertyThatChanged != null)
                PropertyChanged(sender, new PropertyChangedEventArgs(PropertyThatChanged));
        }

        public Player Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
                OnPropertyChanged(this, "TerritoryOwner");
            }
        }

        public void AddInfantry(Int32 Infantry)
        {
            OccupyingInfantry.Infantry += Infantry;
        }

        public void RemoveInfantry(Int32 Infantry)
        {
            OccupyingInfantry.Infantry -= Infantry;
        }

        public Int32 GetOccupyingInfantry()
        {
            return OccupyingInfantry.Infantry;
        }

        public String GetName()
        {
            return Name;
        }

        public void AddConnectingTerritories(List<Territory> ConnectingTerritories)
        {
            this.ConnectingTerritories = ConnectingTerritories;
        }
    }
}
