using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers.Interfaces
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Forms;

    interface IPanelController
    {
        Panel[] PlayerPanels { get; set; }
        Point[] Locations { get; set; }
        IDatabase Database { get; set; }

        void SetLocations();

        void SetPanels(PokerTable pokerTable, Point[] locations);

        void RevealPlayerPanel(Panel playerPanel);

        void ClearPlayerPanels();
    }
}
