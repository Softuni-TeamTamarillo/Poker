namespace Poker2.Core.Handlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class that hold the logic for determining the winning hand by comparing all player hands.
    /// </summary>
    public class WinnersFixer : IWinnersFixer
    {
        private readonly IDatabase database;

        public WinnersFixer(IDatabase database)
        {
            this.database = database;
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public void CheckWinners()
        {
            var competingHands = this.CompareBestHands();
            this.CheckWinningHands(competingHands);
            this.RewardTheWinner();
        }

        /// <summary>
        /// Method that determines which hands are competing.
        /// </summary>
        /// <returns>IList of IHands</returns>
        private IList<IHand> CompareBestHands()
        {
            var players = this.Database.Players.Where(x => !x.Bet.Equals(BetOptions.Fold));
            IHandChecker handChecker = new HandChecker();
            IList<IHand> competingHands = new List<IHand>();
            foreach (var player in players)
            {
                if (player != null)
                {
                    handChecker.CheckHands(player);
                    competingHands.Add(player.Hand);
                }
            }

            return competingHands;
        }

        /// <summary>
        /// Determins which hands from the competing hands list are winning.
        /// </summary>
        /// <param name="competingHands">The competing hands.</param>
        private void CheckWinningHands(IEnumerable<IHand> competingHands)
        {
            var winningHand = competingHands.OrderBy(x => x.Type).ThenBy(x => x.RankFactor).First();
            var winners =
                this.Database.Players.Where(x => x != null)
                    .Where(x => (x.Hand.Type == winningHand.Type && x.Hand.RankFactor == winningHand.RankFactor))
                    .ToList();
        }

        /// <summary>
        /// Allocates the chips reward after the round has ended.
        /// </summary>
        private void RewardTheWinner()
        {
            var players = this.Database.Players;
            int playerProfit = this.Database.PotChipsAmount / players.Count;
            foreach (var player in players)
            {
                player.ChipsAmount += playerProfit;
            }
        }
    }
}
