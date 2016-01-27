using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using Poker2.Forms;

    public interface IBotBetMaker
    {
        IBotChoiceMaker ChoiceMaker { get; }

        int Index { get; }
        PokerTable PokerTable { get; }
        void Execute();

    }
}