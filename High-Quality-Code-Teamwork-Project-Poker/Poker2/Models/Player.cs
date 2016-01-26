using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;
    public abstract class Player : IPlayer
    {
        public const int DefaultBankroll = 10000;

        private int chipsAmount;

        private int call;

        private int raise;

        private bool active;

        private ICard firstCard;

        private ICard secondCard;

        private IHand hand;

        private BetOptions bet;

        public Player()
        {
            this.Call = 0;
            this.Raise = 0;
            this.chipsAmount = DefaultBankroll;
            this.Active = false;
            this.FirstCard = null;
            this.SecondCard = null;
            this.CombinedCards = null;
            this.Hand = null;
            this.Bet = BetOptions.None;
        }

        public BetOptions Bet { get; set; }
        public int ChipsAmount { get; set; }

        public int Call { get; set; }

        public int Raise { get; set; }

        public bool Active { get; set; }

        public ICard FirstCard { get; set; }

        public ICard SecondCard { get; set; }
        public IHand Hand { get; set; }
        public IList<ICard> CombinedCards { get; set; }

        public void AddPreFlopCards()
        {
            CombinedCards.Add(this.FirstCard);
            CombinedCards.Add(this.SecondCard);
        }

        public void AddFlopCards(ICard thirdCard, ICard forthCard, ICard fifthCard)
        {
            CombinedCards.Add(thirdCard);
            CombinedCards.Add(forthCard);
            CombinedCards.Add(fifthCard);
        }

        public void AddTurnCard(ICard sixthCard)
        {
            CombinedCards.Add(sixthCard);
        }

        public void AddRiverCard(ICard seventhCard)
        {
            CombinedCards.Add(seventhCard);
        }
    }
}
