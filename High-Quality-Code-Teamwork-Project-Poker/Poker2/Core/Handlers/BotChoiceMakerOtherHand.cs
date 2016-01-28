namespace Poker2.Core.Handlers
{
    using System;
    using System.Windows.Forms;
    using Poker2.Forms;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class BotChoiceMakerOtherHand : BotChoiceMaker
    {
        public BotChoiceMakerOtherHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
        }

        public override void ExecuteChoice(int factorN, int factorN1, int randParameter)
        {
            IPlayer bot = this.PokerTable.Database.Players[this.Index];
            Label botStatus = bot.Status;
            double formulaResult = 0;

            Random optionsGenerator = new Random();
            double randChoice = optionsGenerator.Next(1, 3);

            if (this.PokerTable.Database.CallAmount <= 0)
            {
                this.Check(botStatus, bot);
            }
            else
            {
                formulaResult = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN);
                if (this.PokerTable.Database.CallAmount >= formulaResult)
                {
                    if (bot.ChipsAmount > this.PokerTable.Database.CallAmount)
                    {
                        this.Call(botStatus, bot);
                    }
                    else if (bot.ChipsAmount <= this.PokerTable.Database.CallAmount)
                    {
                        this.AllInCall(botStatus, bot);
                    }
                }
                else
                {
                    if (this.PokerTable.Database.RaiseAmount > 0)
                    {
                        if (bot.ChipsAmount >= this.PokerTable.Database.RaiseAmount * 2)
                        {
                            this.PokerTable.Database.RaiseAmount *= 2;
                            this.Raise(botStatus, bot);
                        }
                        else
                        {
                            this.Call(botStatus, bot);
                        }
                    }
                    else
                    {
                        this.PokerTable.Database.RaiseAmount = this.PokerTable.Database.CallAmount * 2;
                        this.Raise(botStatus, bot);
                    }
                }
            }

            if (bot.ChipsAmount <= 0)
            {
                bot.Bet = BetOptions.AllIn;
            }
        }
    }
}
