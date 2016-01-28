using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Interfaces
{
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Forms;

    public interface IEngine
    {
        PokerTable PokerTable { get; }

        IDatabase Database { get; }

        ICardController CardController { get; }

        IChipsController ChipsController { get; }

        IPanelController PanelController { get; }

        IGameHandler GameHandler { get; set; }

        Task Run();

    }
}
