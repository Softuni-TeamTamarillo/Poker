using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Handlers;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

    public class BotChoiceMakerWeakerHand : BotChoiceMaker
    {
        public BotChoiceMakerWeakerHand(IDatabase database)
            : base(database)
        {
        }

        private void ChooseOnCallAmount(IPlayer player)
        {
            if (player.Call >= 0)
            {

            }
        }

        private void ChooseOnNoChips(IPlayer player)
        {
            if (callAmount <= 0)
            {

            }
        }

        public void Choose(int factorN, int factorN1)
        {

            //Creates a 4 choices generator
            Random optionsGenerator = new Random();

            //Generates a random choice
            int randChoice = optionsGenerator.Next(1, 4);

            //If bot needs not to call, he checks
            if (callAmount <= 0)
            {
                Check(ref botTurn, botStatus);
            }

            //If bot needs to call or raise
            //Uses randChoice to pick up implementation of the formula to use for making his choice
            if (callAmount > 0)
            {
                //With this randChoice formula uses number factorN for choosing between call and fold
                if (randChoice == 1)
                {
                    //Calls
                    if (callAmount <= RoundN(botChips, factorN))
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }
                    //Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }

                //With this randChoice formula uses number factorN1 for choosing between call and fold
                if (randChoice == 2)
                {
                    //Calls
                    if (callAmount <= RoundN(botChips, factorN1))
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }
                    //Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }
            }

            //With this randChoice,RoundN formula uses number factorN for choosing between raise and fold
            if (randChoice == 3)
            {
                //If he needs not to call a raise or raise
                if (this.raiseAmount == 0)
                {
                    this.raiseAmount = callAmount * 2;
                    Raised(ref botChips, ref botTurn, botStatus);
                }
                //if he needs to call a raise or raise
                //uses formula with number factorN to make his choice
                else
                {
                    //Raises
                    if (this.raiseAmount <= RoundN(botChips, factorN))
                    {
                        this.raiseAmount = callAmount * 2;
                        Raised(ref botChips, ref botTurn, botStatus);
                    }
                    //Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }
            }

            //If bot is out of chips he folds turn(he has made an all in)
            if (botChips <= 0)
            {
                botFoldsTurn = true;
            }
        }
    }
}
