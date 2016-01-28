namespace Poker2.Models
{
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class holding the properties of the cards.
    /// </summary>
    public class Card : ICard
    {
        private Suit suit;

        private Rank rank;

        public Card(Rank rank, Suit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public Card()
        {
            this.Suit = Suit.Clubs;
            this.Rank = Rank.Deuce;
        }

        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
    }
}
