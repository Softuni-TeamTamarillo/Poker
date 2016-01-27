using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using System.Collections;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

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
            var competingHands = CompareBestHands();
            CheckWinningHands(competingHands);
            RewardTheWinner();
        }

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

        private void CheckWinningHands(IEnumerable<IHand> competingHands)
        {
            var winningHand = competingHands.OrderBy(x => x.Type).ThenBy(x => x.RankFactor).First();
            var winners =
                this.Database.Players.Where(x => x != null)
                    .Where(x => (x.Hand.Type == winningHand.Type && x.Hand.RankFactor == winningHand.RankFactor))
                    .ToList();
        }

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
