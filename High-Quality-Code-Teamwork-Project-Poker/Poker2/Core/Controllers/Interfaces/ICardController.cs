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
    using Poker2.Models.Interfaces;

    public interface ICardController
    {
        int[] ShuffledCards { get; set; }

        Image[] ShuffledDeck { get; set; }

        int PlayersOnTheTable { get; set; }

        PictureBox[] Cards { get; set; }

        Point[] Locations { get; set; }

        void SetCardImagesPreFlop(Image[] images, IList<IPlayer> players);

        void SetFlopCardImages(Image[] images);

        void SetTurnCardImage(Image[] images);

        void SetRiverCardImage(Image[] images);

        void ShowLeftPlayersCards(Image[] images, IList<IPlayer> players);

        void ClearCards();
    }
}
