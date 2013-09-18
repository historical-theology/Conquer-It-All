using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace Conquer_It_All
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private Int32 Infantry, NewInfantry;
        private CardsOwned Cards;
        private string name = "";
        private Brush _color;
        private ObservableCollection<Territory> _territories;
        private List<Label> _labeledTerritories = new List<Label>();

        public Player()
        {
            Infantry = 0;
            NewInfantry = 0;
            Cards = new CardsOwned();
            _territories = new ObservableCollection<Territory>();
            _color = new SolidColorBrush();
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(this, "Name");
            }
        }
        public List<Label> TerritoryLabels
        {
            get{ return _labeledTerritories; }
            set { _labeledTerritories = value; }
        }

        public Brush Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged(this, "Color");
            }
        }

        public ObservableCollection<Territory> Territories
        {
            get
            {
                return _territories;
            }
            set
            {
                _territories = value;
                OnCollectionChanged(this, NotifyCollectionChangedAction.Add);
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedAction CollectionChange)
        {
            CollectionChanged(sender, new NotifyCollectionChangedEventArgs(CollectionChange));
        }

        private void OnPropertyChanged(object sender, string PropertyThatChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(sender, new PropertyChangedEventArgs(PropertyThatChanged));
        }

        public void GiveInfantry(Int32 Infantry)
        {
            NewInfantry = Infantry;
            this.Infantry += Infantry;
        }

        public Int32 GetNewInfantry()
        {
            return NewInfantry;
        }

        public void RemoveNewInfantry(Int32 Infantry)
        {
            NewInfantry -= Infantry;
        }

        public void RemoveInfantry(Int32 Infantry)
        {
            this.Infantry -= Infantry;
        }
    }
}
