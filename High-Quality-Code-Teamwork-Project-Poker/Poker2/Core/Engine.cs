namespace Poker2.Core
{
    using System.Collections.Generic;
    using Poker2.Core.Controllers;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class Engine :IEngine
    {
        private readonly ICardController cardController;

        private readonly IChipsController chipsController;

        private readonly IPanelController panelController;

        private readonly PokerTable pokerTable;

        private readonly IDatabase database;

        private IGameHandler gameHandler;

        public Engine(PokerTable pokerTable, IDatabase database)
        {
            this.pokerTable = pokerTable;
            this.database = database;
            this.cardController = new CardController(this.PokerTable, this.Database);
            this.chipsController = new ChipsController(this.PokerTable, this.Database);
            this.panelController = new PanelController(this.PokerTable, this.Database);
            this.GameHandler = null;
        }
        public IGameHandler GameHandler { get; set; }  

        public ICardController CardController
        {
            get
            {
                return this.cardController;
            }
        }

        public IChipsController ChipsController
        {
            get
            {
                return this.chipsController;
            }
        }

        public IPanelController PanelController
        {
            get
            {
                return this.panelController;
            }
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

        private void SetControls()
        {
            ChipsController.SetChips(this.PokerTable);
            PanelController.SetPanels(this.PokerTable);
            CardController.SetCards(this.PokerTable);
        }

        private void PlayGame()
        {
            this.gameHandler = new GameHandler();
            this.GameHandler.StartGame();
        }

        private bool CheckIfHumanHasChips()
        {
            bool humanHasChips = this.Database.Players[0].ChipsAmount > 0;
            return humanHasChips;
        }

        private bool CheckIfHumanContinues()
        {
            bool humanContinues = CheckIfHumanHasChips();
            if (humanContinues)
            {
                return true;
            }

            AddChips addChipsOption = new AddChips();

            addChipsOption.ShowDialog();

            int addedAmount = addChipsOption.AddedChips;

            GameHandlerUtil.PlayersAddChips(this.Database.Players, addedAmount);

            humanContinues = addedAmount > 0;

            return humanContinues;
        }

        private bool CheckIfAnyBotHasMoney()
        {
            foreach (var player in this.Database.Players)
            {
                if (player != null &&
                    player != this.Database.Players[0] &&
                    player.ChipsAmount > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckLeftPlayers()
        {
            for (int i = 1; i < Core.Database.MaxPlayers; i++)
            {
                if (this.Database.Players[i].ChipsAmount == 0)
                {
                    this.Database.Players[i] = null;
                }
            }
        }

        private void SetDatabaseStatistics()
        {
            this.CheckLeftPlayers();
            this.Database.PlayersNotFoldedOrAllIn = new List<IPlayer>(this.Database.Players);
            this.Database.CallAmount = this.Database.BigBlind;
            this.Database.RaiseAmount = 0;
            this.Database.SmallBlind = this.Database.BigBlind / 2;
            this.Database.RoundType = CommunityCardRound.PreFlop;
        }

        private void SetGameStatistics(IList<IPlayer> players)
        {
            this.SetDatabaseStatistics();
            SetPlayersStatistics(players);
        }
        private void SetPlayersStatistics(IList<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player != null)
                {
                    player.Active = false;
                    player.Call = 0;
                    player.Raise = 0;
                    player.FirstCard = null;
                    player.SecondCard = null;
                    player.Hand = null;
                    player.CombinedCards = null;
                }
            }

            players[0].Active = true;
        }

        public void Run()
        {
            this.SetControls();
            while (true)
            {
                this.PlayGame();
                bool sessionContinues = CheckIfAnyBotHasMoney();

                if (!sessionContinues)
                {
                    break;
                }

                sessionContinues = CheckIfHumanContinues();

                if (!sessionContinues)
                {
                    break;
                }

                SetGameStatistics(this.Database.Players);
            }
        }
    }
}
