namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Models.Interfaces;

    public interface IBetHandler
    {
        void CheckPlayerBet(IPlayer player, int index);

        void UseABetHandler();
    }
}
