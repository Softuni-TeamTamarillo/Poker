using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;
    public class Hand:IHand
    {
        private HandType type;

        private double rankFactor;

        public Hand()
        {
            Type = default(HandType);
            RankFactor = 0;
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
