namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public class BotBetMakerPairHand : BotBetMaker
    {
        public BotBetMakerPairHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerWeakHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
            int callParameter = 0;
            int raiseParameter = 0;
            GenerateRandParameters(callParameter, raiseParameter);

            var player = this.PokerTable.Database.Players[this.Index];

            if (player.Hand.RankFactor <= 199 && player.Hand.RankFactor >= 140)
            {
                ChoiceMaker.ExecuteChoice(callParameter, 6, raiseParameter);
            }

            if (player.Hand.RankFactor <= 139 && player.Hand.RankFactor >= 128)
            {
                ChoiceMaker.ExecuteChoice(callParameter, 7, raiseParameter);
            }
            if (player.Hand.RankFactor < 128 && player.Hand.RankFactor >= 128)
            {
                ChoiceMaker.ExecuteChoice(callParameter, 9, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(10, 16);
            raiseParameter = parameterGenerator.Next(10, 13);
        }
    }
}
