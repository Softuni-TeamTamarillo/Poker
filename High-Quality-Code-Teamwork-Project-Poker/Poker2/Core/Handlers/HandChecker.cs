namespace Poker2.Core.Handlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    public class HandChecker : IHandChecker
    {
        public void CheckHands(IPlayer player)
        {

        }
        private IHand CheckPairFromHand(IPlayer player)
        {
            IHand hand = new Hand();

            if (player.FirstCard.Rank == player.SecondCard.Rank)
            {
                HandType type = HandType.Pair;

                int cardRank = (int)player.FirstCard.Rank;
                int categoryFactor = (int)type;
                double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                hand.Type = type;
                hand.RankFactor = rankFactor;
            }
            else
            {
                var tableCards = player.CombinedCards.Skip(2).ToArray();
                bool havePair = false;
                int cardRank = 0;

                for (int i = 0; i < tableCards.Length; i++)
                {
                    if (player.FirstCard.Rank == tableCards[i].Rank ||
                        player.SecondCard.Rank == tableCards[i].Rank)
                    {
                        havePair = true;
                        if (cardRank < (int)tableCards[i].Rank)
                        {
                            cardRank = (int)tableCards[i].Rank;
                        }
                    }
                }

                if (havePair)
                {
                    HandType type = HandType.Pair;
                    int categoryFactor = (int)type;
                    double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                    hand.Type = type;
                    hand.RankFactor = rankFactor;
                }
            }

            return hand;
        }

        private IHand CheckPairFromTable(IPlayer player)
        {
            IHand hand = new Hand();
            var tableCards = player.CombinedCards.Skip(2).OrderBy(c => c.Rank).ToArray();
            bool havePair = false;
            int cardRank = 0;

            for (int i = 0; i < tableCards.Length - 1; i++)
            {
                if (tableCards[i].Rank == tableCards[i + 1].Rank)
                {
                    havePair = true;
                    if (cardRank < (int)tableCards[i].Rank)
                    {
                        cardRank = (int)tableCards[i].Rank;
                    }
                }
            }

            if (havePair)
            {
                HandType type = HandType.PairTable;
                int categoryFactor = (int)type;
                double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                hand.Type = type;
                hand.RankFactor = rankFactor;
            }

            return hand;
        }

        private IHand CheckTwoPair(IPlayer player)
        {
            IHand hand = new Hand();
            var clubs = player.CombinedCards.Where(c => c.Suit == Suit.Clubs).OrderBy(c => c.Rank).ToArray();
            var diamonds = player.CombinedCards.Where(c => c.Suit == Suit.Diamonds).OrderBy(c => c.Rank).ToArray();
            var hearts = player.CombinedCards.Where(c => c.Suit == Suit.Hearts).OrderBy(c => c.Rank).ToArray();
            var spades = player.CombinedCards.Where(c => c.Suit == Suit.Spades).OrderBy(c => c.Rank).ToArray();
            var distinctCards = new List<ICard[]>() { clubs, diamonds, hearts, spades };

            for (int i = 0; i < distinctCards.Count; i++)
            {
                if (distinctCards[i].Length == 2)
                {
                    for (int j = 0; j < distinctCards.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (distinctCards[j].Length == 2)
                        {
                            HandType type = HandType.TwoPairs;
                            int firstCardRank = (int)distinctCards[i].Rank;
                            if (firstCardRank == (int)Rank.Ace)
                            {
                                firstCardRank *= 2;
                            }

                            int secondCardRank = (int)distinctCards[j].Rank;
                            if (secondCardRank == (int)Rank.Ace)
                            {
                                secondCardRank *= 2;
                            }

                            int categoryFactor = (int)type;
                            double rankFactor = (firstCardRank * 2) + (secondCardRank * 2) + (categoryFactor * 100);
                            hand.Type = type;
                            hand.RankFactor = rankFactor;
                        }
                    }
                }
            }

            return hand;
        }

        private IHand CheckThreeOfAKind(IPlayer player)
        {
            IHand hand = new Hand();
            var combinedCards = player.CombinedCards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToArray();
            for (int i = 0; i < 5; i++)
            {
                if (combinedCards[i].Rank == combinedCards[i + 1].Rank &&
                    combinedCards[i].Rank == combinedCards[i + 2].Rank)
                {
                    HandType type = HandType.ThreeOfAKind;
                    int cardRank = (int)combinedCards[i].Rank;
                    int categoryFactor = (int)type;
                    double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                    hand.Type = type;
                    hand.RankFactor = rankFactor;
                }
            }

            return hand;
        }

        private IHand CheckStraight(IPlayer player)
        {
            IHand hand = new Hand();
            var distinctCards = player.CombinedCards.OrderBy(c => c.Rank).Select(c => c.Rank).Distinct().ToArray();
            for (int i = 0; i < distinctCards.Length - 4; i++)
            {
                if (distinctCards[i] + 4 == distinctCards[i + 4])
                {
                    HandType type = HandType.Straight;
                    int cardRank = (int)distinctCards[i + 4];
                    int categoryFactor = (int)type;
                    double rankFactor = cardRank + (categoryFactor * 100);
                    hand.Type = type;
                    hand.RankFactor = rankFactor;
                }
            }

            return hand;
        }


        private IHand CheckFlush(IPlayer player)
        {
            IHand hand = new Hand();

            var clubs = player.CombinedCards.Where(c => c.Suit == Suit.Clubs).OrderBy(c => c.Rank).ToArray();
            var diamonds = player.CombinedCards.Where(c => c.Suit == Suit.Diamonds).OrderBy(c => c.Rank).ToArray();
            var hearts = player.CombinedCards.Where(c => c.Suit == Suit.Hearts).OrderBy(c => c.Rank).ToArray();
            var spades = player.CombinedCards.Where(c => c.Suit == Suit.Spades).OrderBy(c => c.Rank).ToArray();
            var distinctCards = new List<ICard[]>() { clubs, diamonds, hearts, spades };

            foreach (var cards in distinctCards)
            {
                if (cards.Length >= 5)
                {
                    HandType type = this.CheckFlushStraightFlushOrRoyalFlush(cards);
                    int cardRank = (int)cards[cards.Length - 1].Rank;
                    int categoryFactor = (int)type;
                    double rankFactor = cardRank + (categoryFactor * 100);
                    hand.Type = type;
                    hand.RankFactor = rankFactor;
                }
            }

            return hand;
        }

        private IHand CheckFullHouse(IPlayer player)
        {
            IHand hand = new Hand();
            var clubs = player.CombinedCards.Where(c => c.Suit == Suit.Clubs).OrderBy(c => c.Rank).ToArray();
            var diamonds = player.CombinedCards.Where(c => c.Suit == Suit.Diamonds).OrderBy(c => c.Rank).ToArray();
            var hearts = player.CombinedCards.Where(c => c.Suit == Suit.Hearts).OrderBy(c => c.Rank).ToArray();
            var spades = player.CombinedCards.Where(c => c.Suit == Suit.Spades).OrderBy(c => c.Rank).ToArray();
            var distinctCards = new List<ICard[]>() { clubs, diamonds, hearts, spades };

            for (int i = 0; i < distinctCards.Count; i++)
            {
                if (distinctCards[i].Length == 3)
                {
                    for (int j = 0; j < distinctCards.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (distinctCards[j].Length == 2)
                        {
                            HandType type = HandType.FullHouse;
                            int cardRank = (int)distinctCards[i].Rank;
                            int categoryFactor = (int)type;
                            double rankFactor = (cardRank * 2) + (categoryFactor * 100);
                            hand.Type = type;
                            hand.RankFactor = rankFactor;
                        }
                    }
                }
            }

            return hand;
        }

        private IHand CheckFourOfAKind(IPlayer player)
        {
            IHand hand = new Hand();
            var combinedCards = player.CombinedCards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToArray();
            for (int i = 0; i < 3; i++)
            {
                if (combinedCards[i].Rank == combinedCards[i + 1].Rank &&
                    combinedCards[i].Rank == combinedCards[i + 2].Rank &&
                    combinedCards[i].Rank == combinedCards[i + 3].Rank)
                {
                    HandType type = HandType.FourOfAKind;
                    int cardRank = (int)combinedCards[i].Rank;
                    int categoryFactor = (int)type;
                    double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                    hand.Type = type;
                    hand.RankFactor = rankFactor;
                }
            }

            return hand;
        }
        //Това предполагам, че го правиш вътре в метода флаш.
        private HandType CheckFlushStraightFlushOrRoyalFlush(ICard[] cards)
        {
            for (int i = 0; i < cards.Length - 4; i++)
            {
                if (cards[i].Rank + 4 == cards[i + 4].Rank)
                {
                    if (cards[cards.Length - 1].Rank == Rank.Ace)
                    {
                        return HandType.RoyalFlush;
                    }
                    else
                    {
                        return HandType.StraightFlush;
                    }
                }
            }

            return HandType.Flush;
        }

        private IHand CheckHighCard(IPlayer player)
        {
            var higherCard = player.FirstCard;
            if (player.SecondCard.Rank > higherCard.Rank)
            {
                higherCard = player.SecondCard;
            }

            HandType type = HandType.HighCard;
            double rankFactor = (double)higherCard.Rank;
            IHand hand = new Hand(type, rankFactor);
            return hand;
        }
    }
}