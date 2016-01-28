namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Forms;

    /// <summary>
    /// Class responsible for executing the bot's choice in case of a Straight Flush hand.
    /// </summary>
    public class BotBetMakerStraightFlushHand : BotBetMaker
    {
        public BotBetMakerStraightFlushHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerOtherHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
            int callParameter = 0;
            int raiseParameter = 0;
            this.GenerateRandParameters(callParameter, raiseParameter);

            int botName = this.Index - 1;
            var player = this.PokerTable.Database.Players[this.Index];

            if (player.Hand.RankFactor <= 913 && player.Hand.RankFactor >= 804)
            {
                this.ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(1, 3);
            raiseParameter = parameterGenerator.Next(1, 3);
        }
    }
}
