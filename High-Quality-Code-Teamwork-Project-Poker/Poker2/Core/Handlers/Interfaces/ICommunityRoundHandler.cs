namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Core.Interfaces;
    using Poker2.Models.Enums;

    public interface ICommunityRoundHandler
    {
        IDatabase Database { get; }

        CommunityCardRound Round { get; set; }

        void AdvanceRounds();
    }
}
