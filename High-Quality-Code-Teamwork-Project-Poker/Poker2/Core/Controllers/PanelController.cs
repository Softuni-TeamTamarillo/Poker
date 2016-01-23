using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Utils;

    public class PanelController:IPanelController
    {
        public const int DefaultPanelHeight = 150;
        public const int DefaultPanelWidth = 180;
        public const int MaxPlayers = 6;
        public static readonly int[] PanelCoordX = { 570, 5, 65, 580, 1105, 1150 };
        public static readonly int[] PanelCoordY = { 470, 410, 55, 15, 55, 410 };

        private Panel[] playerPanels;

        private Point[] locations;

        private IDatabase database;
        public PanelController(IDatabase database)
        {
            Database = database;
            SetPanels(Database.PokerTable, Locations);
        }

        public Panel[] PlayerPanels { get; set; }
        public Point[] Locations { get; set; }
        public IDatabase Database { get; set; }

        public void SetLocations ()
        {
            ControllerUtil.SetLocations(Locations, PanelCoordX, PanelCoordY);
        }

        public void SetLocations(Point[] otherLocations)
        {
            ControllerUtil.SetLocations(Locations, otherLocations);
        }

        public void SetPanels(PokerTable pokerTable, Point[] locations)
        {
            PlayerPanels = new Panel[MaxPlayers];
            this.SetLocations();
            for (int i = 0; i < MaxPlayers; i++)
            {
                PlayerPanels[i] = new Panel();
                SetPlayerPanel(pokerTable, this.PlayerPanels[i], Locations[i], i);
            }
        }

        private void SetPlayerPanel(PokerTable pokerTable, Panel playerPanel, Point location, int index)
        {
            pokerTable.Controls.Add(playerPanel);
            playerPanel.Location = location;
            playerPanel.BackColor = Color.DarkBlue;
            playerPanel.Height = DefaultPanelHeight;
            playerPanel.Width = DefaultPanelWidth;
            playerPanel.Visible = false;
            playerPanel.Name = "pictureboxChip" + index.ToString();
        }

        public void RevealPlayerPanel(Panel playerPanel)
        {
            playerPanel.Visible = true;
        }

        public void ClearPlayerPanels()
        {
            for (int i = 0; i < MaxPlayers; i++)
            {
                ClearPlayerPanel(this.playerPanels[i]);
            }
        }


        private void ClearPlayerPanel(Panel playerPanel)
        {
            playerPanel.Visible = false;
        }
    }
}
