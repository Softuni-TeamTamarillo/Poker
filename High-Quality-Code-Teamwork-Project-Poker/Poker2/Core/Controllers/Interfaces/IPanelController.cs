namespace Poker2.Core.Controllers.Interfaces
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Forms;

    public interface IPanelController
    {
        PokerTable PokerTable { get; }

        Panel[] PlayerPanels { get; set; }

        Point[] Locations { get; set; }

        IDatabase Database { get; }

        void SetLocations();

        void SetPanels(PokerTable pokerTable);

        void RevealPlayerPanel(Panel playerPanel);

        void ClearPlayerPanels();
    }
}
