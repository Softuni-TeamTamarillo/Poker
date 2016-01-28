﻿namespace Poker2.Core.Handlers
{
    using System;

    using Poker2.Forms;

    /// <summary>
    /// Class responsible for executing the bot's choice in case of a Two Pairs hand.
    /// </summary>
    public class BotBetMakerTwoPairsHand : BotBetMaker
    {
        public BotBetMakerTwoPairsHand(PokerTable pokerTable, int index)
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

            if (player.Hand.RankFactor <= 290 && player.Hand.RankFactor >= 246)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 3, raiseParameter);
            }

            if (player.Hand.RankFactor <= 244 && player.Hand.RankFactor >= 234)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 4, raiseParameter);
            }

            if (player.Hand.RankFactor < 234 && player.Hand.RankFactor >= 201)
            {
                this.ChoiceMaker.ExecuteChoice(callParameter, 4, raiseParameter);
            }
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
            Random parameterGenerator = new Random();
            callParameter = parameterGenerator.Next(6, 11);
            raiseParameter = parameterGenerator.Next(6, 11);
        }
    }
}
