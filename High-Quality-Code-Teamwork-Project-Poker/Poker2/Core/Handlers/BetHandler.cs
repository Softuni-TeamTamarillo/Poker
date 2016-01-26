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

    public class BetHandler : IBetHandler
    {
        private readonly IDatabase database;

        public BetHandler(IDatabase database)
        {
            this.database = database;
            this.IndexLastRaised = this.Database.IndexLastRaised;
            this.IndexLastChecked = this.Database.IndexLastChecked;
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
                    {
                        this.Database.PlayersNotFoldedOrAllIn[index] = null;
                        this.Database.FoldedPlayersCount++;
                    }
                    break;
                case BetOptions.AllIn:
                {
                    this.Database.PlayersNotFoldedOrAllIn[index] = null;
                    this.Database.AllInPlayersCount++;
                }
                break;
                case BetOptions.Check:
                {
                    this.IndexLastChecked = index;
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
                    throw new ArgumentException("Bet can be only Fold, Raise, Call, AllIn or Check");
            }
        }

        public void UseABetHandler()
        {
            if (this.IndexLastRaised == this.IndexLastChecked && !this.Database.RoundType.Equals(CommunityCardRound.River))
            {
                ICommunityRoundHandler roundHandler = new CommunityRoundHandler();
                roundHandler.AdvanceRounds();
            }
            else if (((this.IndexLastChecked == this.IndexLastRaised) && this.Database.RoundType == CommunityCardRound.River) ||
                (this.Database.LeftPlayersCount - this.Database.FoldedPlayersCount == 1))                
            {
                IWinnersFixer winnerFixer = new WinnersFixer(this.Database);
                winnerFixer.CheckWinners();
            }
            else if (this.Database.LeftPlayersCount - this.Database.FoldedPlayersCount - this.Database.AllInPlayersCount <= 1 &&
                this.Database.AllInPlayersCount >= 1)
            {
                while (!this.Database.RoundType.Equals(CommunityCardRound.River))
                {
                    ICommunityRoundHandler roundHandler = new CommunityRoundHandler();
                    roundHandler.AdvanceRounds();
                }
                 IWinnersFixer winnerFixer = new WinnersFixer(this.Database);
                winnerFixer.CheckWinners();
            }


        }
    }
}
