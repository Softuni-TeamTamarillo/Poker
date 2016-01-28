namespace Poker2.Models.Interfaces
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IPlayer : IBetter
    {
        int ChipsAmount { get; set; }

        int Call { get; set; }

        int Raise { get; set; }

        bool Active { get; set; }

        IHand Hand { get; set; }

        ICard FirstCard { get; set; }

        ICard SecondCard { get; set; }
        
        IList<ICard> CombinedCards { get; set; }

        Label Status { get; }
    }
}
