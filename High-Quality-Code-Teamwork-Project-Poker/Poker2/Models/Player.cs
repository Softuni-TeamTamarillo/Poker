namespace Poker2.Models
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class holding the properties and functions for both human and bot players.
    /// </summary>
    public abstract class Player : IPlayer
    {
        public const int DefaultBankroll = 10000;
        private readonly Label status;

        private int chipsAmount;

        private int call;

        private int raise;

        private bool active;

        private ICard firstCard;

        private ICard secondCard;

        private IHand hand;

        private BetOptions bet;

        private IList<ICard> combinedCards;

        protected Player()
        {
            this.Call = 0;
            this.Raise = 0;
            this.ChipsAmount = DefaultBankroll;
            this.Active = false;
            this.FirstCard = null;
            this.SecondCard = null;
            this.CombinedCards = null;
            this.Hand = null;
            this.Bet = BetOptions.None;
            this.status = new Label();
        }

        public Label Status
        {
            get
            {
                return this.status;
            }
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
