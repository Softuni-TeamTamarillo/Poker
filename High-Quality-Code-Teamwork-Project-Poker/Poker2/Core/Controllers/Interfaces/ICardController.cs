namespace Poker2.Core.Controllers.Interfaces
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Forms;

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
