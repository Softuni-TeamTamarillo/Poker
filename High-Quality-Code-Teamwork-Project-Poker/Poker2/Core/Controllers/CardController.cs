using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class CardController:ICardController
    {
        public const int DefaultCardHeight = 130;
        public const int DefaultCardWidth = 80;
        public const int MaxPlayers = 6;

        private readonly static string backImageLocation = "..\\..\\Resources\\Assets\\Back\\Back.png";
        public static readonly int[] CardCoordX = { 580, 15, 75, 590, 1115, 1160, 410, 520, 630, 740, 850 };
        public static readonly int[] CardCoordY = { 480, 420, 65, 25, 65, 420, 265, 265, 265, 265, 265 };
        private static readonly Image BackImage = ControllerUtil.SetCardBackImage(backImageLocation);

        private int[] shuffledCards;

        private Image[] shuffledDeck;

        private int playersOnTheTable;

        private PictureBox[] cards;

        private Point[] locations;
       
        public CardController(PokerTable pokerTable)
        {
            SetCards(Database.PokerTable, Locations);
        }

        public int[] ShuffledCards { get; set; }

        public Image[] ShuffledDeck { get; set; }

        public int PlayersOnTheTable { get; set; }

        public PictureBox[] Cards { get; set; }

        public Point[] Locations { get; set; }

        public void SetLocations()
        {
            ControllerUtil.SetLocations(Locations, CardCoordX, CardCoordY);
        }

        public void SetLocations(Point[] otherLocations)
        {
            ControllerUtil.SetLocations(Locations, otherLocations);
        }
        public void SetCards(PokerTable pokerTable, Point[] locations)
        {
            Cards = new PictureBox[MaxPlayers * 2 + 5];
            this.SetLocations();
            for (int i = 0; i < MaxPlayers * 2 + 5; i++)
            {
                Cards[i] = new PictureBox();
                SetCard(pokerTable, this.Cards[i], Locations[i], i);
            }
        }

        private void SetCard(PokerTable pokerTable, PictureBox card, Point location, int index)
        {
            pokerTable.Controls.Add(card);
            card.Location = location;
            card.Height = DefaultCardHeight;
            card.Width = DefaultCardWidth;
            card.SizeMode = PictureBoxSizeMode.StretchImage;
            card.Name = "pictureboxCard" + index.ToString();
            card.Visible = false;
            card.Tag = index;
            card.Anchor = (AnchorStyles.Bottom);
            card.Visible = false;
            card.Image = null;
        }

        public void SetCardImagesPreFlop(Image[] images,  IList<IPlayer> players)
        {
            SetHumanCardsImagePreFlop(images);
            SetBotCardsImagePreFlop(players);
            this.SetCommunityCardsImagePreFlop();
        }

        private void SetHumanCardsImagePreFlop(Image[] images)
        {
            for (int i = 0; i < 2; i++)
            {
                this.Cards[0].Image = images[0];
                this.Cards[1].Image = images[1];
            }
        }

        private void SetBotCardsImagePreFlop(IList<IPlayer> players )
        {
            for (int i = 1; i < MaxPlayers; i++)
            {
                if (players[i] != null)
                {
                    this.Cards[i * 2].Image = BackImage;
                    this.Cards[i * 2 + 1].Image = BackImage;
                }
            }
        }

        private void SetCommunityCardsImagePreFlop()
        {
            for (int i = MaxPlayers*2; i < MaxPlayers*2 + 5; i++)
            {
                this.Cards[i].Image = BackImage;
            }
        }

        public void SetFlopCardImages(Image[] images)
        {
            int count = images.Length - 5;
            for (int i = 0; i < 3; i++)
            {
                this.Cards[i + count].Image = images[images.Length - 5 + i];
            }
        }

        public void SetTurnCardImage(Image[] images)
        {
            this.Cards[images.Length - 2].Image = images[images.Length - 2];
        }

        public void SetRiverCardImage(Image[] images)
        {
            this.Cards[images.Length - 1].Image = images[images.Length - 1];
        }
        public void ClearCards()
        {
            for (int i = 0; i < MaxPlayers * 2 + 5; i++)
            {
                ClearCard(this.Cards[i]);
            }
        }

        public void ShowLeftPlayersCards(Image[] images, IList<IPlayer> players)
        {
            int indexCards = 2;
            for (int i = 1; i < MaxPlayers; i++)
            {
                if (players[i] != null)
                {
                    this.Cards[i * 2].Image = images[indexCards];
                    indexCards++;
                    this.Cards[i * 2 + 1].Image = images[indexCards];
                }
            }
        }

        private void ClearCard(PictureBox card)
        {
            card.Image = null;
            card.Visible = false;
        }
    }
}
