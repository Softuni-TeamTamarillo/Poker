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
            var players = this.Database.Players.Where(x => !x.Bet.Equals(BetOptions.Fold));
            IHandChecker handChecker = new HandChecker();
            IList<IHand> competingHands = new List<IHand>();
            foreach (var player in players)
            {
                competingHands.Add(handChecker.CheckHands(player));
            }
        }

        public void CheckBestHands()
        {
            
        }

        public void RewardTheWinner()
        {
            
        }
    }
}
