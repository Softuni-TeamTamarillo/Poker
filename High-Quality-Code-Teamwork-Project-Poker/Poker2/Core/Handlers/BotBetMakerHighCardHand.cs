﻿namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public class BotBetMakerHighCardHand:BotBetMaker
    {
        public BotBetMakerHighCardHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerWeakerHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
            var player = this.PokerTable.Database.Players[this.Index];
            this.ChoiceMaker.ExecuteChoice(20, 25, 0);
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {

        }
    }
}
