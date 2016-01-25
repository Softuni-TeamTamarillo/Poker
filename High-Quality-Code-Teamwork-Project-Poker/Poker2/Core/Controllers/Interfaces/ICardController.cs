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

    public interface ICardController
    {
        PokerTable PokerTable { get; }
        int[] ShuffledCards { get; set; }

        Image[] CardImages { get; set; }

        PictureBox[] ShuffledDeck { get; set; }

        Point[] Locations { get; set; }

        void ShowLeftPlayersCards();

        void ClearCards();

        void SetCards(PokerTable pokerTable);

        void SetCommunityRoundCardsImages();
    }
}
