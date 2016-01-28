namespace Poker2.Core.Handlers
{
    using Poker2.Forms;

    /// <summary>
    /// Class responsible for executing the bot's choice in case of a Royal Flush hand.
    /// </summary>
    public class BotBetMakerRoyalFlushHand : BotBetMaker
    {
        public BotBetMakerRoyalFlushHand(PokerTable pokerTable, int index)
            : base(pokerTable, index)
        {
            this.ChoiceMaker = new BotChoiceMakerOtherHand(this.PokerTable, this.Index);
        }

        public override void Execute()
        {
        }

        public override void GenerateRandParameters(int callParameter, int raiseParameter)
        {
        }
    }
}
