namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Models.Enums;

    public interface IDeal
    {
        void DealCards();

        void DealPlayers();

        void DealCommunityRound(CommunityCardRound round);

        void DealFlop();

        void DealTurn();

        void DealRiver();
    }
}
