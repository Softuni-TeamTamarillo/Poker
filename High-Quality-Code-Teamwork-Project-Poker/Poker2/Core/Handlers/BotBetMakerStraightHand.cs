using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public class BotBetMakerStraightHand : BotBetMaker
    {
        public BotBetMakerStraightHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerOtherHand(this.PokerTable, this.Index);
        }
        public override void Execute()
        {
            int callParameter = 0;
            int raiseParameter = 0;
            GenerateRandParameters(callParameter, raiseParameter);

            var player = this.PokerTable.Database.Players[this.Index];
            int botName = this.Index - 1;

            if (player.Hand.RankFactor <= 480 && player.Hand.RankFactor >= 410)
            {
                ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }

            if (player.Hand.RankFactor <= 409 && player.Hand.RankFactor >= 407)
            {
                ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }
            if (player.Hand.RankFactor < 407 && player.Hand.RankFactor >= 404)
            {
                ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(3, 6);
            raiseParameter = parameterGenerator.Next(3, 8);
        }
    }
}
