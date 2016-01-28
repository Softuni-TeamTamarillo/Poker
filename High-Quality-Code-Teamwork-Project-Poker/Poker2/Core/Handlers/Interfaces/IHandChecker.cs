namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Models.Interfaces;

    public interface IHandChecker
    {
        void CheckHands(IPlayer player);
    }
}
