namespace PokerTests.FakeModelsSevenCards
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Poker2.Models;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public class FakePlayerStraight : IPlayer
    {
        public FakePlayerStraight()
        {
            this.FirstCard = new Card() { Rank = Rank.Six, Suit = Suit.Spades };
            this.SecondCard = new Card() { Rank = Rank.Three, Suit = Suit.Hearts };
            this.CombinedCards = new List<ICard>()
            {
                this.FirstCard,
                this.SecondCard,
                new Card() { Rank = Rank.Eight, Suit = Suit.Diamonds },
                new Card() { Rank = Rank.Nine, Suit = Suit.Clubs },
                new Card() { Rank = Rank.Seven, Suit = Suit.Clubs },
                new Card() { Rank = Rank.Seven, Suit = Suit.Hearts },
                new Card() { Rank = Rank.Five, Suit = Suit.Spades },
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
