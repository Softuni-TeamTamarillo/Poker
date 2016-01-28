namespace PokerTests.FakeModelsTwoCards
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Poker2.Models;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public class FakePlayerTwoCardsHighCard : IPlayer
    {
        public FakePlayerTwoCardsHighCard()
        {
            this.FirstCard = new Card() { Rank = Rank.Queen, Suit = Suit.Hearts };
            this.SecondCard = new Card() { Rank = Rank.Eight, Suit = Suit.Clubs };
            this.CombinedCards = new List<ICard>()
            {
                this.FirstCard,
                this.SecondCard,
            };
        }

        public BetOptions Bet { get; set; }

        public int ChipsAmount { get; set; }

        public int Call { get; set; }

        public int Raise { get; set; }

        public bool Active { get; set; }

        public IHand Hand { get; set; }

        public ICard FirstCard { get; set; }

        public ICard SecondCard { get; set; }

        public IList<ICard> CombinedCards { get; set; }

        public Label Status { get; private set; }
    }
}
