namespace Poker2.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IBot
    {
        IList<ICard> CombinedCards { get; set; }

        void AddFlopCards();

        void AddTurnCard();

        void AddRiverCard();
    }
}
