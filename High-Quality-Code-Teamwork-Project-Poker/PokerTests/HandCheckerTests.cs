namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker2.Core.Handlers;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    using PokerTests.FakeModelsSevenCards;
    using PokerTests.FakeModelsTwoCards;

    [TestClass]
    public class HandCheckerTests
    {
        [TestMethod]
        public void TestCheckHands_AllSevenCardsDifferentWithoutMatching_ShouldReturnHighCardType()
        {
            IPlayer player = new FakePlayerAllCardsDifferentWithoutMatching();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.HighCard, 10);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor, "Rank factor does not match, should be factor 10 -> Jack.");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should return HighCard Type (-1).");
        }

        [TestMethod]
        public void TestCheckHands_AllSevenCardsDifferentWithoutMatchingSecondCardHigher_ShouldReturnHighCardType()
        {
            IPlayer player = new FakePlayerAllCardsDifferentWithoutMatchingSecondHandCardHigher();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.HighCard, 10);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor, "Rank factor does not match, should be factor 10 -> Jack.");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should return HighCard Type (-1).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsOnePair_SouldRerurnPairHandType()
        {
            IPlayer player = new FakePlayerOnePair();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.Pair, 140);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 140 -> 4*10(Jack) + 1*100(Pair).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be Pair (1).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsOnePairFromHand_SouldRerurnPairHandType()
        {
            IPlayer player = new FakePlayerOnePairFromHand();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.Pair, 140);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 140 -> 4*10(Jack) + 1*100(Pair).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be Pair (1).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsTwoPairs_SouldReturnTwoPairsHandType()
        {
            IPlayer player = new FakePlayerTwoPairs();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.TwoPairs, 230);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 230 -> 2*10(Jack) + 2*5(Six) + 2*100(TwoPairs).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be TwoPairs (2).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsThreeOfAKind_ShouldReturnThreeOfAKindHandType()
        {
            IPlayer player = new FakePlayerThreeOfAKind();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.ThreeOfAKind, 340);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 340 -> 4*10(Jack) + 3*100(ThreeOfAKind).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be ThreeOfAKinf (3).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsFourOfAKind_ShouldReturnFourOfAKindHandType()
        {
            IPlayer player = new FakePlayerFourOfAKind();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.FourOfAKind, 740);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 740 -> 4*10(Jack) + 7*100(FourOfAKind).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be FourOfAKind (7).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsStraight_ShouldReturnStraightHandType()
        {
            IPlayer player = new FakePlayerStraight();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.Straight, 408);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 408 -> 8(Nine) + 4*100(Straight).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be Straight (4).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsFlush_ShouldReturnFlushHandType()
        {
            IPlayer player = new FakePlayerFlush();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.Flush, 513);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 513 -> 13(Ace) + 5*100(Flush)");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be Flush (5).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsStraightFlush_ShouldReturnStraightFlushHandType()
        {
            IPlayer player = new FakePlayerStraightFlush();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.StraightFlush, 809);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 809 -> 9(Ten) + 8*100(StraightFlush).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be StraightFlush (8).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsRoyalFlush_ShouldReturnRoyalFlushHandType()
        {
            IPlayer player = new FakePlayerRoyalFlush();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.RoyalFlush, 913);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 913 -> 13(Ace) + 9*100(RoyalFlush).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be RoyalFlush (9).");
        }

        [TestMethod]
        public void TestCheckHands_SevenCardsFullHouse_ShouldReturnFullHouseHandType()
        {
            IPlayer player = new FakePlayerFullHouse();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.FullHouse, 620);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 620 -> 2*10(Jack) + 6*100(FullHouse).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be FullHouse (6).");
        }

        [TestMethod]
        public void TestCheckHands_TwoCardsPairFromHand_ShouldReturnPairHandType()
        {
            IPlayer player = new FakePlayerTwoCardsPairFromHand();
            var handChecker = new HandChecker();

            handChecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.Pair, 128);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 128 -> 4*7(Eight) + 1*100(Pair).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be Pair (1).");
        }

        [TestMethod]
        public void TestCheckHands_TwoCardsHighCard_ShouldReturnHighCardHandType()
        {
            IPlayer player = new FakePlayerTwoCardsHighCard();
            var handhecker = new HandChecker();

            handhecker.CheckHands(player);
            var result = player.Hand;
            var expectedResult = new Hand(HandType.HighCard, 11);

            Assert.AreEqual(expectedResult.RankFactor, result.RankFactor,
                "Rank factor does not match, should be factor 11 -> 11(Queen).");
            Assert.AreEqual(expectedResult.Type, result.Type, "Hand type does not match, should be HighCard (-1).");
        }
    }
}
