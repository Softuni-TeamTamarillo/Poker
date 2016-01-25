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
    using Poker2.Models;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class ChipsController : IChipsController
    {
        public const int DefaultChipsHeight = 50;
        public const int DefaultChipsWidth = 50; 
        public const int MaxPlayers = 6;

        private static readonly string PathChipsFolder = "..\\..\\Resources\\Assets\\Cards\\";

        private static readonly string[] ChipsFileNames =
            {
                "250.1999", "2000.4999", "5000.9999", "10000.24999",
                "25000.+"
            };

        public static readonly int[] ChipsCoordX = { 750, 255, 350, 785, 970, 110, 550 };
        public static readonly int[] ChipsCoordY = { 500, 500, 140, 140, 140, 500, 190 };
        private readonly PokerTable pokerTable;

        private PictureBox [] chips;

        private Point[] locations;

        private IDatabase database;
        public ChipsController(PokerTable pokerTable, IDatabase database)
        {
            this.database = database;
            this.pokerTable = pokerTable;
            this.Chips = this.Database.Chips;
            SetChips(this.PokerTable);
        }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }
        public PictureBox[] Chips { get; set; }
        public Point[] Locations { get; set; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public void SetLocations()
        {
            ControllerUtil.SetLocations(Locations, ChipsCoordX, ChipsCoordY);
        }

        public void SetLocations(Point[] otherLocations)
        {
            ControllerUtil.SetLocations(Locations, otherLocations);
        }
        public void SetChips(PokerTable pokerTable)
        {
            Chips = new PictureBox[MaxPlayers + 1];
            this.SetLocations();
            for (int i = 0; i < MaxPlayers + 1; i++)
            {
                Chips[i] = new PictureBox();
                SetChip(pokerTable, this.Chips[i], Locations[i], i);
            }
        }

        private void SetChip(PokerTable pokerTable, PictureBox chip, Point location, int index)
        {
            pokerTable.Controls.Add(chip);
            chip.Location = location;
            chip.Height = DefaultChipsHeight;
            chip.Width = DefaultChipsWidth;
            chip.SizeMode = PictureBoxSizeMode.StretchImage;
            chip.Name = "pictureboxChip" + index.ToString();
            chip.Visible = false;
            chip.Tag = index;
            chip.Anchor = (AnchorStyles.Bottom);
            chip.BackColor = Color.Transparent;
            chip.Visible = false;
            chip.Image = null;
        }

        public void SetPlayerChipsImage(IPlayer player, PictureBox chip)
        {
            ControllerUtil.SetChipsImage(player.ChipsAmount, chip, PathChipsFolder, ChipsFileNames, MaxPlayers + 1);
        }

        public void SetPotChipsImage(int potAmount, PictureBox chip)
        {
            ControllerUtil.SetChipsImage(potAmount, chip, PathChipsFolder, ChipsFileNames, MaxPlayers + 1);
        }

        public void ClearChips()
        {
            for (int i = 0; i < MaxPlayers + 1; i++)
            {
                ClearChip(this.Chips[i]);
            }
        }

        public void ClearChip(PictureBox chip)
        {
            chip.Visible = false;
            chip.Image = null;
        }
    }
}