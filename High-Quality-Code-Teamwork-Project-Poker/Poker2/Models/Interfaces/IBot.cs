namespace Poker2.Models.Interfaces
{
    using Poker2.Core.Handlers.Interfaces;

    public interface IBot
    {
        IHandChecker HandChecker { get; }
    }
}
