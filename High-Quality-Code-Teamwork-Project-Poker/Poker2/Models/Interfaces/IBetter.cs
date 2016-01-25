using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    public interface IBetter
    {
        BetOptions Bet { get; set; }
        void Checks();

        void Calls();

        void Raises();

        void GoesAllIn();

        void Folds();

    }
}
