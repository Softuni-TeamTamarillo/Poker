namespace Poker2.Models.Interfaces
{
    using Poker2.Models.Enums;

    public interface ICard
    {
        Suit Suit { get; set; }

        Rank Rank { get; set; }
    }
}
