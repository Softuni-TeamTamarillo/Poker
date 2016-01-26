using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using System.Windows.Forms;

    using Poker2.Core.Controllers;
    using Poker2.Models.Interfaces;
    public abstract class Player : IPlayer
    {
        public const int DefaultBankroll = 10000;

        private int chipsAmount;

        private int call;

        private int raise;

        private bool active;

        private ICard firstCard;

        private ICard secondCard;

        private IHand hand;

        private BetOptions bet;

        private IList<ICard>  combinedCards; 

        public Player()
        {
            this.Call = 0;
            this.Raise = 0;
            this.chipsAmount = DefaultBankroll;
            this.Active = false;
            this.FirstCard = null;
            this.SecondCard = null;
            this.CombinedCards = null;
            this.Hand = null;
            this.Bet = BetOptions.None;
        }

        public BetOptions Bet { get; set; }
        public int ChipsAmount { get; set; }

        public int Call { get; set; }

        public int Raise { get; set; }

        public bool Active { get; set; }

        public ICard FirstCard { get; set; }

        public ICard SecondCard { get; set; }
        public IHand Hand { get; set; }
        public IList<ICard> CombinedCards { get; set; }

    }
}
