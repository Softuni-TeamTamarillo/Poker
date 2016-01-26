using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

    public class BetChecker : IBetChecker
    {
        private readonly IDatabase database;

        private int indexLastRaised;

        private int indexLastChecked;

        public BetChecker(IDatabase database)
        {
            this.database = database;
            this.IndexLastRaised = 0;
            this.IndexLastChecked = -1;
        }
        public int IndexLastRaised { get; set; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public int IndexLastChecked { get; set; }

        public void CheckPlayerBet(IPlayer player, int index)
        {
            switch (player.Bet)
            {
                case BetOptions.Fold:
                case BetOptions.AllIn:
                {
                    this.Database.PlayersNotFoldedOrAllIn[index] = null;
                }
                break;
                case BetOptions.Check:
                {
                    this.indexLastChecked = index;
                }
                break;
                case BetOptions.Raise:
                    {
                        this.IndexLastRaised = index;
                    }
                    break;
                case BetOptions.Call:
                    {
                        
                    }
                    break;
                default:
                    throw new ArgumentException("Bet can be only Fold, Raise,Call, AllIn or Check");
            }
        }

        public void UseABetHandler()
        {
            if (this.IndexLastChecked == this.IndexLastRaised)
            {
                ICommunityRoundHandler roundHandler = new CommunityRoundHandler();
                roundHandler.AdvanceRounds();
            }

            else if (this.Database.PlayersNotFoldedOrAllIn.Where(x => x != null).Count() == 1)
                
            {
                IWinnersFixer winnerFixer = new WinnersFixer();
                winnerFixer.CheckWinners();
            }
        }
    }
}
