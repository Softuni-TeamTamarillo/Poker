namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Interfaces;

    public interface IGameHandler
    {
        IDatabase Database { get; }

        IBetHandler BetHandler { get; }

        IDealHandler DealHandler { get; }

        ITimerController TimerController { get; }

        void StartGame();

        void FinishGame();
    }
}
