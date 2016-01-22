using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    interface IBetter
    {
        void Checks();

        void Calls();

        void Raises();

        void GoesAllIn();

        void Folds();

    }
}
