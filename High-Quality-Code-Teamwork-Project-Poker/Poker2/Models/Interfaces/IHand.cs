namespace Poker2.Models.Interfaces
{
    public interface IHand
    {
        HandType Type { get; set; }

        double RankFactor { get; set; }
    }
}
