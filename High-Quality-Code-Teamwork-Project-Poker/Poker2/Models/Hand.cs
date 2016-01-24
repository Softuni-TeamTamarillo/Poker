using System;

namespace Poker2.Models
{
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public class Hand : IHand
    {
        private HandType type;

        private double rankFactor;

        public Hand()
        {
            Type = HandType.HighCard;
            RankFactor = 0;
        }

        public HandType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (value < HandType.HighCard || value > HandType.RoyalFlush)
                {
                    throw new ArgumentOutOfRangeException("There is no such HandType.", nameof(value));
                }
                this.type = value;
            }
        }

        public double RankFactor { get; set; }
    }
}