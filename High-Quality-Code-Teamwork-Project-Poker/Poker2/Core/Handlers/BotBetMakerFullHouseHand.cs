namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public class BotBetMakerFullHouseHand : BotBetMaker
    {
        public BotBetMakerFullHouseHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerOtherHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
            int callParameter = 0;
            int raiseParameter = 0;
            GenerateRandParameters(callParameter, raiseParameter);

            int botName = this.Index - 1;
            var player = this.PokerTable.Database.Players[this.Index];

            if (player.Hand.RankFactor <= 626 && player.Hand.RankFactor >= 620)
            {
                ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }

            if (player.Hand.RankFactor <= 620 && player.Hand.RankFactor >= 602)
            {
                ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(1, 5);
            raiseParameter = parameterGenerator.Next(2, 6);
        }
    }
}
