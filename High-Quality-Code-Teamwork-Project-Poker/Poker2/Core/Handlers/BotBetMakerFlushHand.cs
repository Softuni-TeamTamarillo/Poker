namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public class BotBetMakerFlushHand : BotBetMaker
    {
        public BotBetMakerFlushHand(PokerTable pokerTable, int index)
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

            ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(2, 6);
            raiseParameter = parameterGenerator.Next(3, 7);
        }
    }
}
