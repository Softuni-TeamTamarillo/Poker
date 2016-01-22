using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;
    public abstract class Player:IPlayer, IBetter
    {
        public const int DefaultBankroll = 10000;

        private int chipsAmount;

        private int call;

        private int raise;

        private bool active;

        private bool isFolded;

        private bool hasCalled;

        private bool hasChecked;

        private bool hasRaised;

        private bool isAllIn;

        private ICard firstCard;

        private ICard secondCard;

        private IHand hand;

        public Player()
        {
            this.Call = 0;
            this.Raise = 0;
            this.chipsAmount = DefaultBankroll;
            Active = false;
            this.isFolded = false;
            HasCalled = false;
            HasChecked = false;
            HasRaised = false;
            IsAllIn = false;
            FirstCard = new Card();
            SecondCard = null;
            Hand = null;
        }

        public int ChipsAmount { get; set; }

        public int Call { get; set; }

        public int Raise { get; set; }

        public bool Active { get; set; }

        public bool IsFolded { get; set; }

        public bool HasCalled { get; set; }

        public bool HasChecked { get; set; }

        public bool HasRaised { get; set; }

        public bool IsAllIn { get; set; }

        public ICard FirstCard { get; set; }

        public ICard SecondCard { get; set; }
        public IHand Hand { get; set; }

        public void GetCards(Card card1, Card card2)
        {
            FirstCard.Suit = card1.Suit;
            FirstCard.Rank = card1.Rank;
            SecondCard.Suit = card2.Suit;
            SecondCard.Rank = card2.Rank;
        }

        public void Checks()
        {
            
        }

        public void Calls()
        {
            
        }

        public void Raises()
        {
            
        }

        public void GoesAllIn()
        {
            
        }

        public void Folds()
        {
            
        }
    }
}
