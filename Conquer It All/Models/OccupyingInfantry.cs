using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_It_All.Models
{
    class OccupyingInfantry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object sender, string PropertyThatChanged)
        {
            if (PropertyThatChanged != null)
                PropertyChanged(sender, new PropertyChangedEventArgs(PropertyThatChanged));
        }

        public Int32 Infantry
        {
            get
            {
                return Infantry;
            }
            set
            {
                Infantry = value;
                OnPropertyChanged(this, "OccupyingInfantry");
            }
        }
    }
}
