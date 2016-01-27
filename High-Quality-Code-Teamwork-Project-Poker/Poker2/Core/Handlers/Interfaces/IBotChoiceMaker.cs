using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Forms;

    public interface IBotChoiceMaker
    {
        PokerTable PokerTable { get; }
        int Index { get; }

        void ExecuteChoice(int factorN, int factorN1, int randParameter);
    }
}
