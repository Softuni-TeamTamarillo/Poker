namespace Poker2.Models.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; set; }

        Rank Rank { get; set; }
    }
}
