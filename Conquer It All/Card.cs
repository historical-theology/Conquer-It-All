using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_It_All
{
    public class Card
    {
        String Name;
        Int32 TypeValue;
        
        public Card(String Name, Int32 AmountInfantryAwarded)
        {
            this.Name = Name;
            TypeValue = AmountInfantryAwarded;
        }

        public String GetName()
        {
            return Name;
        }

        public Int32 GetTypeValue()
        {
            return TypeValue;
        }
    }
}
