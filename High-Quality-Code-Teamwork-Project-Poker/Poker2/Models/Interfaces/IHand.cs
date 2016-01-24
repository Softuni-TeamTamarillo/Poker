namespace Poker2.Models.Interfaces
{
    using Poker2.Models.Enums;

    public interface IHand
    {
        HandType Type { get; set; }

        double RankFactor { get; set; }
    }
}
