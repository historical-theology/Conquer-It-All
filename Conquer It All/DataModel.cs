using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace Conquer_It_All
{
    public class DataModel : INotifyPropertyChanged
    {
        private Dispatcher _dispatcher;
        private PropertyChangedEventHandler _propertyChangedEvent;

        public DataModel()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                _propertyChangedEvent += value;
            }
            remove
            {
                _propertyChangedEvent -= value;
            }
        }

        protected void SendPropertyChanged(string propertyName)
        {
            if (_propertyChangedEvent != null)
            {
                _propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
