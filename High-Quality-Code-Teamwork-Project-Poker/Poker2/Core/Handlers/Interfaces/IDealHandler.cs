namespace Poker2.Core.Handlers.Interfaces
{
    using System.Drawing;

    public interface IDealHandler : IDeal, IShuffle
    {
        int LeftPlayersCount { get; set; }

        Image[] Images { get; set; }

        void SetCommunityCards();
    }
}
