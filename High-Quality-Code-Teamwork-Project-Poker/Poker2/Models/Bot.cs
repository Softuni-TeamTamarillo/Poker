using System.Diagnostics;

namespace Poker2.Models
{
    using System.Collections.Generic;
    using Poker2.Models.Interfaces;

    public class Bot : Player, IBot
    {
        private IList<ICard> commbinedCards;

        public Bot() : base()
        {
            SetCombinedCards();
        }

        public IList<ICard> CombinedCards { get; set; }

        private void SetCombinedCards()
        {
            CombinedCards = new List<ICard>();
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
