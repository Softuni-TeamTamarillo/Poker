namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Forms;

    public interface IBotBetMaker
    {
        IBotChoiceMaker ChoiceMaker { get; }

        int Index { get; }

        PokerTable PokerTable { get; }

        void Execute();
    }
}