using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_It_All
{
    public class CardsOwned : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection<Card> Cards
        {
            get
            {
                return Cards;
            }
            set
            {
                Cards = value;
                OnCollectionChanged(this, NotifyCollectionChangedAction.Add);
            }
        }

        public void AddCard(Card CardToAdd)
        {
            Cards.Add(CardToAdd);
            OnCollectionChanged(this, NotifyCollectionChangedAction.Add);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedAction CollectionChange)
        {
            CollectionChanged(sender, new NotifyCollectionChangedEventArgs(CollectionChange));
        }

        public void RemoveCards(String TypeOfCardToRemove, Int32 NumberOfCardsToRemove)
        {
            Int32 LeftToRemove = NumberOfCardsToRemove;
            foreach (Card card in Cards)
            {
                if (card.GetName() == TypeOfCardToRemove)
                {
                    Cards.Remove(card);
                    LeftToRemove--;
                    OnCollectionChanged(this, NotifyCollectionChangedAction.Remove);
                }
            }
        }
    }
}
