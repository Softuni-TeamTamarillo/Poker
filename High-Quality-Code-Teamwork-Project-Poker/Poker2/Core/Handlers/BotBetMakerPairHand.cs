﻿namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Forms;

    /// <summary>
    /// Class responsible for executing the bot's choice in case of a Pair hand.
    /// </summary>
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
            this.GenerateRandParameters(callParameter, raiseParameter);

            var player = this.PokerTable.Database.Players[this.Index];

            if (player.Hand.RankFactor <= 199 && player.Hand.RankFactor >= 140)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 6, raiseParameter);
            }

            if (player.Hand.RankFactor <= 139 && player.Hand.RankFactor >= 128)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 7, raiseParameter);
            }

            if (player.Hand.RankFactor < 128 && player.Hand.RankFactor >= 128)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 9, raiseParameter);
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
