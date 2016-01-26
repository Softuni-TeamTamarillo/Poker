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
            var hightCard = this.CheckHighCard(player);
            var pair = this.CheckPair(player);
            var twoPair = this.CheckTwoPair(player);
            var threeOfAKind = this.CheckThreeOfAKind(player);
            var straight = this.CheckStraight(player);
            var flush = this.CheckFlush(player);
            var fullHouse = this.CheckFullHouse(player);
            var fourOfAKind = this.CheckFourOfAKind(player);

            ICollection<IHand> checkedHands = new List<IHand>() { hightCard, pair, twoPair, threeOfAKind, straight, flush, fullHouse, fourOfAKind };
            var bestHand =
                checkedHands.Where(h => h != null).OrderByDescending(h => h.Type).ThenByDescending(h => h.RankFactor).First();
            player.Hand = bestHand;
        }


        private IHand CheckPair(IPlayer player)
        {
            IHand hand = null;
            bool foundPair = false;
            int cardRank = 0;

            for (int rank = 1; rank <= 13; rank++)
            {
                var rankGroup = player.CombinedCards.Where(o => (int)o.Rank == rank).ToArray();
                if (rankGroup.Length == 2)
                {
                    foundPair = true;
                    if (cardRank < (int)rankGroup[0].Rank)
                    {
                        cardRank = (int)rankGroup[0].Rank;
                    }
                }
            }

            if (foundPair)
            {
                HandType type = HandType.Pair;
                int categoryFactor = (int)type;
                double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                hand = new Hand(type, rankFactor);
            }

            return hand;
        }

        private IHand CheckTwoPair(IPlayer player)
        {
            IHand hand = null;
            for (int rank = 13; rank >= 1; rank--)
            {
                var rankGroup = player.CombinedCards.Where(c => (int)c.Rank == rank).ToArray();
                if (rankGroup.Length == 2)
                {
                    for (int secRank = 13; secRank >= 1; secRank--)
                    {
                        var secRankGroup = player.CombinedCards.Where(c => (int)c.Rank == secRank).ToArray();
                        if (secRankGroup.Length == 2 && (rank != secRank))
                        {
                            HandType type = HandType.TwoPairs;
                            int firstPairCardRank = rank;
                            int secondPairRank = secRank;
                            int categoryFactor = (int)type;
                            double rankFactor = (firstPairCardRank * 2) + (secondPairRank * 2) + (categoryFactor * 100);
                            hand = new Hand(type, rankFactor);
                            return hand;
                        }
                    }
                }
            }

            return hand;
        }

        private IHand CheckThreeOfAKind(IPlayer player)
        {
            IHand hand = null;
            bool foundThree = false;
            int cardRank = 0;

            for (int rank = 1; rank <= 13; rank++)
            {
                var rankGroup = player.CombinedCards.Where(o => (int)o.Rank == rank).ToArray();

                if (rankGroup.Length == 3)
                {
                    foundThree = true;
                    if (cardRank < (int)rankGroup[0].Rank)
                    {
                        cardRank = (int)rankGroup[0].Rank;
                    }
                }
            }

            if (foundThree)
            {
                HandType type = HandType.ThreeOfAKind;
                int categoryFactor = (int)type;
                double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                hand = new Hand(type, rankFactor);
            }

            return hand;
        }

        private IHand CheckStraight(IPlayer player)
        {
            IHand hand = null;
            var distinctCards = player.CombinedCards.OrderBy(c => c.Rank).Select(c => c.Rank).Distinct().ToArray();
            for (int i = 0; i < distinctCards.Length - 4; i++)
            {
                if (distinctCards[i] + 4 == distinctCards[i + 4])
                {
                    HandType type = HandType.Straight;
                    int cardRank = (int)distinctCards[i + 4];
                    int categoryFactor = (int)type;
                    double rankFactor = cardRank + (categoryFactor * 100);
                    hand = new Hand(type, rankFactor);
                }
            }

            return hand;
        }

        private IHand CheckFlush(IPlayer player)
        {
            IHand hand = null;

            for (int suit = 1; suit <= 4; suit++)
            {
                var suitGroup = player.CombinedCards.Where(o => (int)o.Suit == suit).OrderByDescending(c => c.Rank).ToArray();
                if (suitGroup.Length >= 5)
                {
                    hand = this.CheckFlushStraightFlushOrRoyalFlush(suitGroup);
                }
            }

            return hand;
        }

        private IHand CheckFullHouse(IPlayer player)
        {
            IHand hand = null;
            for (int rank = 13; rank >= 1; rank--)
            {
                var rankGroup = player.CombinedCards.Where(c => (int)c.Rank == rank).ToArray();
                if (rankGroup.Length == 3)
                {
                    for (int secFank = 13; secFank >= 1; secFank--)
                    {
                        var secRankGroup = player.CombinedCards.Where(c => (int)c.Rank == secFank).ToArray();
                        if (secRankGroup.Length == 2 && (rank != secFank))
                        {
                            HandType type = HandType.FullHouse;
                            int cardRank = rank;
                            int categoryFactor = (int)type;
                            double rankFactor = (cardRank * 2) + (categoryFactor * 100);
                            hand = new Hand(type, rankFactor);
                            return hand;
                        }
                    }
                }
            }

            return hand;
        }

        private IHand CheckFourOfAKind(IPlayer player)
        {
            IHand hand = null;
            bool foundFour = false;
            int cardRank = 0;

            for (int i = 1; i <= 13; i++)
            {
                var rankGroup = player.CombinedCards.Where(o => (int)o.Rank == i).ToArray();
                if (rankGroup.Length == 4)
                {
                    foundFour = true;
                    if (cardRank < (int)rankGroup[0].Rank)
                    {
                        cardRank = (int)rankGroup[0].Rank;
                    }
                }
            }

            if (foundFour)
            {
                HandType type = HandType.FourOfAKind;
                int categoryFactor = (int)type;
                double rankFactor = (cardRank * 4) + (categoryFactor * 100);
                hand = new Hand(type, rankFactor);
            }

            return hand;
        }

        private IHand CheckFlushStraightFlushOrRoyalFlush(ICard[] cards)
        {
            HandType type;
            int categoryFactor;
            int cardRank;
            double rankFactor;
            for (int i = 0; i < cards.Length - 4; i++)
            {
                if (cards[i].Rank - 4 == cards[i + 4].Rank)
                {
                    if (cards[i].Rank == Rank.Ace)
                    {
                        type = HandType.RoyalFlush;
                        categoryFactor = (int)type;
                        cardRank = (int)cards[i].Rank;
                        rankFactor = cardRank + (categoryFactor * 100);
                        return new Hand(type, rankFactor);
                    }
                    else
                    {
                        type = HandType.StraightFlush;
                        categoryFactor = (int)type;
                        cardRank = (int)cards[i].Rank;
                        rankFactor = cardRank + (categoryFactor * 100);
                        return new Hand(type, rankFactor);
                    }
                }
            }

            type = HandType.Flush;
            categoryFactor = (int)type;
            cardRank = (int)cards[0].Rank;
            rankFactor = cardRank + (categoryFactor * 100);
            return new Hand(type, rankFactor);
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