using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using System.Drawing;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    interface IDealHandler:IDeal, IShuffle
    {
        int PlayersCount { get; set; }

        IList<IPlayer> Players { get; set; }

        Image[] Images { get; set; }

        ICard[] CardsToBeDealt { get; set; }

        ICardController CardController { get; set; }


    }
}
