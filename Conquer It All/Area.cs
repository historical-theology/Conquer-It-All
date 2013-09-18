using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_It_All
{
    class Area
    {
        private String Name;
        private List<Territory> EnclosedTerritories;
        private Player Owner;
        private Int32 BonusValue;

        public Area(String Name, Int32 BonusValue)
        {
            this.Name = Name;
            this.BonusValue = BonusValue;
        }

        public String GetName()
        {
            return Name;
        }

        public List<Territory> GetEnclosedTerritories()
        {
            return EnclosedTerritories;
        }

        public Player GetOwner()
        {
            return Owner;
        }

        public void SetOwner(Player NewOwner)
        {
            Owner = NewOwner;
        }

        public Int32 GetBonusValue()
        {
            return BonusValue;
        }

        public void AddEnclosedTerritories(List<Territory> EnclosedTerritories)
        {
            this.EnclosedTerritories = EnclosedTerritories;
        }
    }
}
