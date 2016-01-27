namespace Poker2.Core.Handlers
{
    using System;
    using System.Windows.Forms;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class BotChoiceMakerWeakHand : BotChoiceMaker
    {
        public BotChoiceMakerWeakHand(PokerTable pokerTable, int index) : base(pokerTable, index) { }

        public override void ExecuteChoice(int factorN, int factorN1, int randParameter)
        {
            IPlayer bot = this.PokerTable.Database.Players[Index];
            Label botStatus = bot.Status;
            double formulaResultN = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN);
            double formulaResultN1 = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN1);

            Random optionsGenerator = new Random();
            int randChoice = optionsGenerator.Next(1, 3);

            if (this.PokerTable.Database.RoundType < CommunityCardRound.Turn)
            {
                if (this.PokerTable.Database.CallAmount <= 0)
                {
                    Check(botStatus, bot);
                }

                //If he needs to call or raise 
                if (this.PokerTable.Database.CallAmount > 0)
                {
                    if (this.PokerTable.Database.CallAmount >= formulaResultN)
                    {
                        Fold(botStatus, bot);
                    }

                    if (this.PokerTable.Database.RaiseAmount > formulaResultN)
                    {
                        Fold(botStatus, bot);
                    }

                    if (bot.Bet != BetOptions.Fold)
                    {
                        if (this.PokerTable.Database.CallAmount >= formulaResultN && this.PokerTable.Database.CallAmount <= formulaResultN1)
                        {
                            Call(botStatus, bot);
                        }

                        if (this.PokerTable.Database.RaiseAmount <= formulaResultN && this.PokerTable.Database.RaiseAmount >= formulaResultN1 / 2)
                        {
                            Call(botStatus, bot);
                        }

                        if (this.PokerTable.Database.RaiseAmount <= formulaResultN / 2)
                        {
                            if (this.PokerTable.Database.RaiseAmount > 0)
                            {
                                this.PokerTable.Database.RaiseAmount = formulaResultN;
                                Raise(botStatus, bot);
                            }
                            else 
                            {
                                this.PokerTable.Database.RaiseAmount = this.PokerTable.Database.CallAmount * 2;
                                Raise(botStatus, bot);
                            }
                        }

                    }
                }
            }

            if (this.PokerTable.Database.RoundType >= CommunityCardRound.Turn)
            {
                if (this.PokerTable.Database.CallAmount > 0)
                {
                    formulaResultN1 = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN1 - randChoice);
                    if (this.PokerTable.Database.CallAmount >= formulaResultN1)
                    {
                        Fold(botStatus, bot);
                    }

                    formulaResultN = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, factorN - randChoice);
                    if (this.PokerTable.Database.RaiseAmount > formulaResultN)
                    {
                        Fold(botStatus, bot);
                    }

                    if (bot.Bet != BetOptions.Fold)
                    {
                        if (this.PokerTable.Database.CallAmount >= formulaResultN && this.PokerTable.Database.CallAmount <= formulaResultN1)
                        {
                            Call(botStatus, bot);
                        }

                        if (this.PokerTable.Database.RaiseAmount <= formulaResultN && this.PokerTable.Database.RaiseAmount >= formulaResultN)
                        {
                            Call(botStatus, bot);
                        }

                        if (this.PokerTable.Database.RaiseAmount <= formulaResultN / 2)
                        {
                            if (this.PokerTable.Database.RaiseAmount > 0)
                            {
                                this.PokerTable.Database.RaiseAmount = formulaResultN;
                                Raise(botStatus, bot);
                            }
                            else
                            {
                                this.PokerTable.Database.RaiseAmount = this.PokerTable.Database.CallAmount * 2;
                                Raise(botStatus, bot);
                            }
                        }
                    }
                }

                if (this.PokerTable.Database.CallAmount <= 0)
                {
                    formulaResultN = BotHandlerUtil.ChoiceFormula(bot.ChipsAmount, randParameter - randChoice);
                    this.PokerTable.Database.RaiseAmount = formulaResultN;
                    Raise(botStatus, bot);
                }
            }

            if (bot.ChipsAmount <= 0)
            {
                bot.Bet = BetOptions.AllIn;
            }
            
        }
    }
}
