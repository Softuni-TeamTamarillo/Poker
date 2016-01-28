namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Forms;

    /// <summary>
    /// Class responsible for executing the bot's choice in case of a Three of a kind hand.
    /// </summary>
    public class BotBetMakerThreeOfAKindHand : BotBetMaker
    {
        public BotBetMakerThreeOfAKindHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerOtherHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
            int callParameter = 0;
            int raiseParameter = 0;
            this.GenerateRandParameters(callParameter, raiseParameter);

            var player = this.PokerTable.Database.Players[this.Index];
            int botName = this.Index - 1;

            if (player.Hand.RankFactor <= 390 && player.Hand.RankFactor >= 330)
            {
                this.ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }

            if (player.Hand.RankFactor <= 327 && player.Hand.RankFactor >= 321)
            {
                this.ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }

            if (player.Hand.RankFactor < 321 && player.Hand.RankFactor >= 303)
            {
                this.ChoiceMaker.ExecuteChoice(botName, callParameter, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(3, 7);
            raiseParameter = parameterGenerator.Next(4, 8);
        }
    }
}
