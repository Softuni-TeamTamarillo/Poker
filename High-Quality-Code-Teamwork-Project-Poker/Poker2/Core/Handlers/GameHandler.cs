using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    using Poker2.Core;
    using Poker2.Core.Controllers;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class holding the carry-through game logic.
    /// </summary>
    public class GameHandler :IGameHandler
    {
        public const int MaxPlayers = 6;

        private readonly IDatabase database;

        private readonly PokerTable pokerTable;

        private readonly IDealHandler dealHandler;

        private readonly IBetHandler betHandler;

        private readonly ICardController cardController;

        private readonly ITimerController timerController;


        public GameHandler(ICardController cardController, IDatabase database, PokerTable pokerTable)
        {
            this.database = database;
            this.cardController = cardController;
            this.dealHandler = new DealHandler(this.Database);
            this.betHandler = new BetHandler(this.Database);
            this.pokerTable = pokerTable;
            this.timerController = new TimerController(this.Database.Players[0]);
        }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }


        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public IBetHandler BetHandler
        {
            get
            {
                return this.betHandler;
            }
        }

        public IDealHandler DealHandler
        {
            get
            {
                return this.dealHandler;
            }
        }

        public ICardController CardController
        {
            get
            {
                return this.cardController;
            }
        }

        public ITimerController TimerController
        {
            get
            {
                return this.timerController;
            }
        }

        /// <summary>
        /// Enables the buttons and timer for taking a turn by the human player. 
        /// </summary>
        private void HumanTakesTurn()
        {

            this.TimerController.TurnTime = 60;
            this.TimerController.HumanTimer.Start();
            this.TimerController.ProgressBarTimer.Visible = true;
            this.TimerController.ProgressBarTimer.Value = 1000;

            this.PokerTable.ButtonCall.Enabled = true;
            this.PokerTable.ButtonRaise.Enabled = true;
            this.PokerTable.ButtonFold.Enabled = true;

            this.PokerTable.ProgressBarTimer.Visible = true;
            this.PokerTable.ProgressBarTimer.Value = 1000;

        }

        /// <summary>
        /// Disables the buttons and timer afeter the human turn has ended.
        /// </summary>
        private void HumanEndsTurn()
        {
            this.PokerTable.ButtonCall.Enabled = false;
            this.PokerTable.ButtonRaise.Enabled = false;
            this.PokerTable.ButtonFold.Enabled = false;
            this.PokerTable.ButtonCheck.Enabled = false;
            this.PokerTable.ProgressBarTimer.Visible = false;
            this.TimerController.HumanTimer.Stop();
        }

        private void BotEndsTurn()
        {
            
        }

        /// <summary>
        /// Calls methods for the bot to make its choice and accomplish its turn.
        /// </summary>
        /// <param name="player">The bot.</param>
        /// <param name="index">Internal index for accessing the player(bot).</param>
        private void BotTakesTurn(IPlayer player, int index)
        {
            IHandChecker handChecker = new HandChecker();
            handChecker.CheckHands(player);

            MessageBox.Show(string.Format("Bot {0}'s Turn", index));
            IBotHandler botHandler = new BotHandler(this.PokerTable, index);
            botHandler.Execute();
        }


        private void AdvanceGame()
        {
            
        }

        /// <summary>
        /// Еnsures the accomplishment of the turns for both human and bot players.
        /// </summary>
        private void PlayersTakeTurns()
        {
            int index = 0;
            while (true)
            {
                IPlayer player = this.Database.PlayersNotFoldedOrAllIn[index];
                player.Active = true;
                if (player != null && player.Active)
                {
                    if (index == 0)
                    {
                        this.HumanTakesTurn();
                                             
                    }
                    else this.BotTakesTurn(player, index);

                    IChipsController chipsController = new ChipsController(this.PokerTable, this.Database);
                    chipsController.SetPlayerChipsImage(player, this.Database.Chips[index]);
                    chipsController.SetPotChipsImage(this.Database.PotChipsAmount, this.Database.Chips[index]);
                }

                if (!player.Active)
                {
                    this.BetHandler.CheckPlayerBet(player, index);
                    this.BetHandler.UseABetHandler();

                    if (index == 0)
                    {
                        this.HumanEndsTurn();
                    }

                    else
                    {
                        BotEndsTurn();
                    }
                }

                if (index == MaxPlayers - 1)
                {
                    index = 0;
                }

                else index++;

                player = this.Database.PlayersNotFoldedOrAllIn[index];
                player.Active = true;
            }
        }

        /// <summary>
        /// Method that initializes the game process running in each round.
        /// </summary>
        public void StartGame()
        {
            this.DealHandler.ShuffleCards();

            this.DealHandler.DealCommunityRound(this.Database.RoundType);

            this.PlayersTakeTurns();
        }

        public void FinishGame()
        {
            
        }
    }
}
