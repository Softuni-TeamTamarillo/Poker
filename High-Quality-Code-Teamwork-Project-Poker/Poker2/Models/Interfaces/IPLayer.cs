using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    using System.Windows.Forms;

    using Poker2.Core.Controllers;

    public interface IPlayer:IBetter
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
