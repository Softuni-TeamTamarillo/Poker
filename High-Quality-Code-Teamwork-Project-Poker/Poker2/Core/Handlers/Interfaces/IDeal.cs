using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Models.Interfaces;

    public interface IDeal
    {
        void DealCards();

        void DealPlayers();

        void DealFlop();

        void DealTurn();

        void DealRiver();
    }
}
