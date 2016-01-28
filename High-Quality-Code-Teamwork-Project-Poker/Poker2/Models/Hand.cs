namespace Poker2.Models
{
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class holding the parameters of the card combinations in the game.
    /// </summary>
    public class Hand : IHand
    {
        private HandType type;

        private Rank rank;

        public Hand()
        {
            this.Type = default(HandType);
            this.RankFactor = 0;
        }

        public Hand(HandType type, double rankFactor)
        {
            this.Type = type;
            this.RankFactor = rankFactor;
        }

        public HandType Type { get; set; }

        public double RankFactor { get; set; }
    }
}
