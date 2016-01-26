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

    /// <summary>
    /// Class responsible for interacting with user and bot panels.
    /// </summary>
    public class PanelController:IPanelController
    {
        public const int DefaultPanelHeight = 150;
        public const int DefaultPanelWidth = 180;
        public const int MaxPlayers = 6;
        public static readonly int[] PanelCoordX = { 570, 5, 65, 580, 1105, 1150 };
        public static readonly int[] PanelCoordY = { 470, 410, 55, 15, 55, 410 };

        private readonly PokerTable pokerTable;
        private Panel[] playerPanels;

        private Point[] locations;

        private IDatabase database;
        public PanelController(PokerTable pokerTable, IDatabase database)
        {
            this.database = database;
            this.PlayerPanels = this.Database.PlayerPanels;
            this.pokerTable = pokerTable;
            SetPanels(this.PokerTable);
        }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }
        public Panel[] PlayerPanels { get; set; }
        public Point[] Locations { get; set; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public void SetLocations ()
        {
            ControllerUtil.SetLocations(Locations, PanelCoordX, PanelCoordY);
        }

        public void SetLocations(Point[] otherLocations)
        {
            ControllerUtil.SetLocations(Locations, otherLocations);
        }

        public void SetPanels(PokerTable pokerTable)
        {
            PlayerPanels = new Panel[MaxPlayers];
            this.SetLocations();

            for (int i = 0; i < MaxPlayers; i++)
            {
                PlayerPanels[i] = new Panel();
                SetPlayerPanel(pokerTable, this.PlayerPanels[i], Locations[i], i);
            }
        }

        /// <summary>
        /// Sets a specific player panel in a location on the table.
        /// </summary>
        /// <param name="pokerTable">The table.</param>
        /// <param name="playerPanel">The instance of the panel.</param>
        /// <param name="location">The location for the panel to be placed </param>
        /// <param name="index">Internal index for accessing each player's panel.</param>
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

        /// <summary>
        /// Visualizes a player panel by setting its "Visible" property.
        /// </summary>
        /// <param name="playerPanel"></param>
        public void RevealPlayerPanel(Panel playerPanel)
        {
            playerPanel.Visible = true;
        }

        /// <summary>
        /// Devizualizes all player planels. 
        /// </summary>
        public void ClearPlayerPanels()
        {
            for (int i = 0; i < MaxPlayers; i++)
            {
                ClearPlayerPanel(this.playerPanels[i]);
            }
        }

        /// <summary>
        /// Devisualizes player panel by setting its "Visible" property.
        /// </summary>
        /// <param name="playerPanel"></param>
        private void ClearPlayerPanel(Panel playerPanel)
        {
            playerPanel.Visible = false;
        }
    }
}
