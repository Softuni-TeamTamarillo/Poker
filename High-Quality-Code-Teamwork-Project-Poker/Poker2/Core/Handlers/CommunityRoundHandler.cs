using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using Poker2.Core.Controllers;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    public class CommunityRoundHandler : ICommunityRoundHandler
    {
        private readonly IDatabase database;

        private readonly PokerTable pokerTable;

        public CommunityRoundHandler()
        {
            Round = CommunityCardRound.PreFlop;
        }

        public PokerTable PokerTable
        {
            get
            {
                return this.PokerTable;
            }
        }
        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
        public CommunityCardRound Round { get; set; }


        public void AdvanceRounds()
        {
            ICardController cardController = new CardController(this.PokerTable, this.Database);
            IDealHandler dealHandler = new DealHandler(this.Database);
            this.Database.RoundType++;
            dealHandler.DealCommunityRound(this.Database.RoundType);
            cardController.SetCommunityRoundCardsImages();
        }
    }
}