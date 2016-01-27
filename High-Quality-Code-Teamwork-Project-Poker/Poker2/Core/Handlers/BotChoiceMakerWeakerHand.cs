namespace Poker2.Core.Handlers
{
    using System;
    using System.Windows.Forms;

    using Poker2.Forms;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class BotChoiceMakerWeakerHand : BotChoiceMaker
    {
        public BotChoiceMakerWeakerHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
        }

        public override void ExecuteChoice(int factorN, int factorN1, int randParameter)
        {
            IPlayer bot = this.PokerTable.Database.Players[Index];
            Label botStatus = bot.Status;
            double formulaResult = 0;

            Random optionsGenerator = new Random();
            int randChoice = optionsGenerator.Next(1, 4);

            if (this.PokerTable.Database.CallAmount <= 0)
            {
                Check(botStatus, bot);
            }

            if (this.PokerTable.Database.CallAmount > 0)
            {
                if (randChoice == 1)
                {
                    formulaResult = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN);

                    if (this.PokerTable.Database.CallAmount <= formulaResult)
                    {
                        Call(botStatus, bot);
                    }
                    else
                    {
                        Fold(botStatus, bot);
                    }
                }

                if (randChoice == 2)
                {
                    formulaResult = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN1);
                    if (this.PokerTable.Database.CallAmount <= formulaResult)
                    {
                        Call(botStatus, bot);
                    }
                    else
                    {
                        Fold(botStatus, bot);
                    }
                }
            }

            if (randChoice == 3)
            {
                if (this.PokerTable.Database.RaiseAmount == 0)
                {
                    this.PokerTable.Database.RaiseAmount = this.PokerTable.Database.CallAmount * 2;
                    Raise(botStatus, bot);
                }
                else
                {
                    formulaResult = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN);
                    if (this.PokerTable.Database.RaiseAmount <= formulaResult)
                    {
                        this.PokerTable.Database.RaiseAmount = this.PokerTable.Database.CallAmount * 2;
                        Raise(botStatus, bot);
                    }
                    else
                    {
                        Fold(botStatus, bot);
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
