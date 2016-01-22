using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;
    public class Card:ICard
    {
        private Suit suit;

        private Rank rank;

        public Card()
        {
            Suit = 0;
            Rank = 0;
        }

        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
    }
}
