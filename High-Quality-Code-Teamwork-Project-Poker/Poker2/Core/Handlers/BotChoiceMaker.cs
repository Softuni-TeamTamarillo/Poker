namespace Poker2.Core.Handlers
{
    using System;
    using System.Windows.Forms;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    public abstract class BotChoiceMaker : IBotChoiceMaker
    {
        private readonly PokerTable pokerTable;

        protected BotChoiceMaker(PokerTable pokerTable, int index)
        {
            this.pokerTable = pokerTable;
            this.Index = index;
        }

        public int Index { get; protected set; }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }

        public abstract void ExecuteChoice(int factorN, int factorN1, int randParameter);

        protected void Call(Label botStatus, IPlayer bot)
        {
            bot.Active = false;
            bot.ChipsAmount -= this.PokerTable.Database.CallAmount;
            botStatus.Text = "Call " + this.PokerTable.Database.CallAmount;
            this.PokerTable.TextBoxPot.Text = (int.Parse(this.PokerTable.TextBoxPot.Text) + this.PokerTable.Database.CallAmount).ToString();
        }

        protected void Raise(Label botStatus, IPlayer bot)
        {
            bot.Active = false;
            bot.ChipsAmount -= Convert.ToInt32(this.PokerTable.Database.RaiseAmount);
            botStatus.Text = "Raise " + this.PokerTable.Database.RaiseAmount;
            this.PokerTable.TextBoxPot.Text = (int.Parse(this.PokerTable.TextBoxPot.Text) + this.PokerTable.Database.RaiseAmount).ToString();
            this.PokerTable.Database.CallAmount = Convert.ToInt32(this.PokerTable.Database.RaiseAmount);
        }

        protected void Fold(Label botStatus, IPlayer bot)
        {
            botStatus.Text = "Fold";
            bot.Bet = BetOptions.Fold;
            bot.Active = false;
        }

        protected void Check(Label checkStatus, IPlayer bot)
        {
            checkStatus.Text = "Check";
            bot.Active = false;
        }

        protected void AllInCall(Label botStatus, IPlayer bot)
        {
            this.PokerTable.TextBoxPot.Text = (int.Parse(this.PokerTable.TextBoxPot.Text) + bot.ChipsAmount).ToString();
            botStatus.Text = "AllIn Call:" + bot.ChipsAmount;
            bot.Active = false;
            bot.ChipsAmount = 0;
        }

        protected void AllInRaise(Label botStatus, IPlayer bot)
        {
            this.PokerTable.TextBoxPot.Text = (int.Parse(this.PokerTable.TextBoxPot.Text) + bot.ChipsAmount).ToString();
            botStatus.Text = "AllIn Raise:" + bot.ChipsAmount;
            bot.Active = false;
            bot.ChipsAmount = 0;
        }
    }
}
