using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using System.Windows.Forms;

    using Poker2.Core;
    using Poker2.Core.Controllers;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    public class GameHandler :IGameHandler
    {
        public const int MaxPlayers = 6;

        private readonly IDatabase database;

        private readonly PokerTable pokerTable;

        private readonly IDealHandler dealHandler;

        private readonly IBetHandler betHandler;

        private readonly ICardController cardController;

        private readonly TimerController timerController;

        private readonly BotHandler botHandler;


        public GameHandler(ICardController cardController, IDatabase database, PokerTable pokerTable)
        {
            this.database = database;
            this.cardController = cardController;
            this.dealHandler = new DealHandler(this.Database);
            this.betHandler = new BetHandler(this.Database);
            this.timerController = new TimerController();
            this.botHandler = new BotHandler();
            this.pokerTable = pokerTable;
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

        public BotHandler BotHandler
        {
            get
            {
                return this.botHandler;
            }
        }

        public TimerController TimerController
        {
            get
            {
                return this.timerController;
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

        private void HumanTakesTurn()
        {
            TimerController.TurnTime = 60;
            TimerController.HumanTimer.Start();

            this.PokerTable.buttonCall.Enabled = true;
            this.PokerTable.buttonRaise.Enabled = true;
            this.PokerTable.buttonFold.Enabled = true;

            this.PokerTable.progressbarTimer.Visible = true;
            this.PokerTable.progressbarTimer.Value = 1000;

        }

        private void HumanEndsTurn()
        {
            this.PokerTable.buttonCall.Enabled = false;
            this.PokerTable.buttonRaise.Enabled = false;
            this.PokerTable.buttonFold.Enabled = false;
            this.PokerTable.progressbarTimer.Visible = false;
            TimerController.HumanTimer.Stop();
        }

        private void BotEndsTurn()
        {
            
        }
        private void BotTakesTurn(IPlayer player, int index)
        {
            IHandChecker handChecker = new HandChecker();
            handChecker.CheckHands(player);

            MessageBox.Show(string.Format("Bot {0}'s Turn", index));
            IBotHandler botHandler = new BotHandler();
            botHandler.BotMakesAChoice(player);
        }


        private void AdvanceGame()
        {
            
        }

        private void PlayersTakeTurns()
        {
            int index = 0;
            while (true)
            {
                IPlayer player = this.Database.PlayersNotFoldedOrAllIn[index];
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
