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
    using Poker2.Models.Interfaces;

    interface IChipsController
    {
        PictureBox[] Chips { get; set; }
        Point[] Locations { get; set; }
        IDatabase Database { get; set; }

        void SetLocations();

        void SetLocations(Point[] otherLocations);

        void SetChips(PokerTable pokerTable, Point[] locations);

        void SetPlayerChipsImage(IPlayer player, PictureBox chip);

        void SetPotChipsImage(int potAmount, PictureBox chip);
    }
}
