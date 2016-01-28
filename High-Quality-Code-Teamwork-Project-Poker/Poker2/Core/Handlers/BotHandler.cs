﻿namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class that describes the bot's logic in making a choice.
    /// </summary>
    public class BotHandler : IBotHandler
    {
        private readonly PokerTable pokerTable;
        private IBotBetMaker botBetMaker;

        public BotHandler(PokerTable pokerTable, int index)
        {
            this.pokerTable = pokerTable;
            this.Index = index;
        }

        public int Index { get; set; }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }

        /// <summary>
        /// Places the bet, previously returned in IBotBetMaker variable.
        /// </summary>
        public void Execute()
        {
            IBotBetMaker betMaker = this.SelectBetMaker();
            betMaker.Execute();
        }

        /// <summary>
        /// Choice of the kind of bet to be placed by the bot depending on the hand.
        /// </summary>
        /// <returns>IBotBetMaker</returns>
        private IBotBetMaker SelectBetMaker()
        {
            IBotBetMaker betMaker = null;
            IPlayer bot = this.PokerTable.Players[this.Index];
            IHand hand = bot.Hand;
            switch (hand.Type)
            {
                case HandType.HighCard:
                    {
                        betMaker = new BotBetMakerHighCardHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.Pair:
                    {
                        betMaker = new BotBetMakerPairHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.TwoPairs:
                    {
                        betMaker = new BotBetMakerTwoPairsHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.ThreeOfAKind:
                    {
                        betMaker = new BotBetMakerThreeOfAKindHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.Straight:
                    {
                        betMaker = new BotBetMakerStraightHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.Flush:
                    {
                        betMaker = new BotBetMakerFlushHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.FullHouse:
                    {
                        betMaker = new BotBetMakerFullHouseHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.FourOfAKind:
                    {
                        betMaker = new BotBetMakerFourOfAKindHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.StraightFlush:
                    {
                        betMaker = new BotBetMakerStraightFlushHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                case HandType.RoyalFlush:
                    {
                        betMaker = new BotBetMakerRoyalFlushHand(this.PokerTable, this.Index);
                        return betMaker;
                    }

                default:
                    {
                        Console.WriteLine("Not a valid poker hand type.");
                        return null;
                    }
            }
        }
    }
}
