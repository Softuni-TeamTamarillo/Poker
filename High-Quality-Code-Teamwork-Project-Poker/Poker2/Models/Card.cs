using System;

namespace Poker2.Models
{
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public class Card : ICard
    {
        private Rank rank;

        private Suit suit;

        public Card()
        {
            //ne znam do kolko e pravilno da inicializirame s konkreten tip
            Suit = Suit.Clubs;
            Rank = Rank.Deuce;
        }

        public Rank Rank
        {
            get
            {
                return this.rank;
            }

            set
            {
                if (value < Rank.Deuce || value > Rank.Ace)
                {
                    throw new ArgumentOutOfRangeException("There is no such rank.", nameof(value));
                }
                this.rank = value;
            }
        }

        public Suit Suit
        {
            get
            {
                return this.suit;
            }

            set
            {
                if (value < Suit.Clubs || value > Suit.Spades)
                {
                    throw new ArgumentOutOfRangeException("There is no such suit.", nameof(value));
                }
                this.suit = value;
            }
        }
    }
}