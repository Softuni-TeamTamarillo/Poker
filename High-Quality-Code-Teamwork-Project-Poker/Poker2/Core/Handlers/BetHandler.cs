namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class responsible for betting states of the players.
    /// </summary>
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

        /// <summary>
        /// Void method that handles bet choice of the player 
        /// </summary>
        /// <param name="player">The given bot or human player.</param>
        /// <param name="index">Internal index for accessing the player.</param>
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

        /// <summary>
        /// Handles the cases with all possible betting scenarios.
        /// </summary>
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
