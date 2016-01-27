namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;
    public abstract class BotBetMaker:IBotBetMaker
    {
        private IBotChoiceMaker choiceMaker;

        private readonly PokerTable pokerTable;

        protected BotBetMaker(PokerTable pokerTable, int index)
        {
            this.pokerTable = pokerTable;
            this.Index = index;
            this.ChoiceMaker = null;
        }

        public int Index { get; protected set; }
        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }
        public IBotChoiceMaker ChoiceMaker { get; set; }

        public abstract void Execute();

        public abstract void GenerateRandParameters(int callParameter, int raiseParameter);
      
    }
}
