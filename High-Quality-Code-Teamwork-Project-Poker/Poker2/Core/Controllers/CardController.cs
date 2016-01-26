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

    /// <summary>
    /// Class responsible for cards visualisation on every segment of the hand
    /// </summary>
    public class CardController:ICardController
    {
        public const int DefaultCardHeight = 130;
        public const int DefaultCardWidth = 80;
        public const int MaxPlayers = 6;

        private static readonly string backImageLocation = "..\\..\\Resources\\Assets\\Back\\Back.png";
        public static readonly int[] CardCoordX = { 580, 15, 75, 590, 1115, 1160, 410, 520, 630, 740, 850 };
        public static readonly int[] CardCoordY = { 480, 420, 65, 25, 65, 420, 265, 265, 265, 265, 265 };
        private static readonly Image BackImage = ControllerUtil.SetCardBackImage(backImageLocation);

        private readonly IDatabase database;
        private readonly PokerTable pokerTable;

        private int[] shuffledCards;

        private int playersOnTheTable;

        private PictureBox[] shuffledDeck;

        private Point[] locations;
       
        public CardController(PokerTable pokerTable, IDatabase database)
        {
            this.database = database;

            this.pokerTable = pokerTable;

            this.ShuffledDeck = this.Database.ShuffledDeck;

            this.CardImages = this.Database.CardImages;
        }

        public PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
        public int[] ShuffledCards { get; set; }

        public Image[] CardImages { get; set; }

        public int PlayersOnTheTable { get; set; }

        public PictureBox[] ShuffledDeck { get; set; }

        public Point[] Locations { get; set; }

        public void SetLocations()
        {
            ControllerUtil.SetLocations(Locations, CardCoordX, CardCoordY);
        }

        public void SetLocations(Point[] otherLocations)
        {
            ControllerUtil.SetLocations(Locations, otherLocations);
        }
        public void SetCards(PokerTable pokerTable)
        {
            ShuffledDeck = new PictureBox[MaxPlayers * 2 + 5];
            this.SetLocations();
            for (int i = 0; i < MaxPlayers * 2 + 5; i++)
            {
                ShuffledDeck[i] = new PictureBox();
                SetCard(pokerTable, this.ShuffledDeck[i], Locations[i], i);
            }
        }

        /// <summary>
        /// Void method that places a card in a specific position on the table.
        /// </summary>
        /// <param name="pokerTable">Refers to the table </param>
        /// <param name="card">The card taken from the card database.</param>
        /// <param name="location">Location of the visualisation of the card.</param>
        /// <param name="index">Internal numbering for accessing the card.</param>
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
        /// <summary>
        /// Combines setting cards for both human player and bot players on the pre-flop stage.
        /// </summary>
        public void SetCardImagesPreFlop()
        {
            SetHumanCardsImagePreFlop();
            SetBotCardsImagePreFlop();
            this.SetCommunityCardsImagePreFlop();
        }

        private void SetHumanCardsImagePreFlop()
        {
            for (int i = 0; i < 2; i++)
            {
                this.ShuffledDeck[0].Image = this.Database.CardImages[0];
                this.ShuffledDeck[1].Image = this.Database.CardImages[1];
            }
        }

        private void SetBotCardsImagePreFlop()
        {
            var players = this.Database.Players;
            for (int i = 1; i < MaxPlayers; i++)
            {
                if (players[i] != null)
                {
                    this.ShuffledDeck[i * 2].Image = BackImage;
                    this.ShuffledDeck[i * 2 + 1].Image = BackImage;
                }
            }
        }

        /// <summary>
        /// Calls a specific method for visualization of the cards each round.
        /// </summary>
        public void SetCommunityRoundCardsImages()
        {
            switch (this.Database.RoundType)
            {
                case CommunityCardRound.PreFlop:
                    this.SetCardImagesPreFlop();
                    break;
                case CommunityCardRound.Flop:
                    this.SetFlopCardImages();
                    break;
                case CommunityCardRound.Turn:
                    this.SetTurnCardImage();
                    break;
                case CommunityCardRound.End:
                    this.SetRiverCardImage();
                    break;
                default:
                    throw new ArgumentException("Not a Community Round");
            }
        }
        private void SetCommunityCardsImagePreFlop()
        {
            for (int i = MaxPlayers*2; i < MaxPlayers*2 + 5; i++)
            {
                this.ShuffledDeck[i].Image = BackImage;
            }
        }
        private void SetFlopCardImages()
        {
            int count = this.Database.CardImages.Length - 5;
            for (int i = 0; i < 3; i++)
            {
                this.ShuffledDeck[i + count].Image = this.Database.CardImages[this.Database.CardImages.Length - 5 + i];
            }
        }

        private void SetTurnCardImage()
        {
            this.ShuffledDeck[this.Database.CardImages.Length - 2].Image = this.Database.CardImages[this.Database.CardImages.Length - 2];
        }

        private void SetRiverCardImage()
        {
            this.ShuffledDeck[this.Database.CardImages.Length - 1].Image = this.Database.CardImages[this.Database.CardImages.Length - 1];
        }
        public void ClearCards()
        {
            for (int i = 0; i < MaxPlayers * 2 + 5; i++)
            {
                ClearCard(this.ShuffledDeck[i]);
            }
        }

        /// <summary>
        /// Method responsible for visualization of the non-folded players' cards.
        /// </summary>
        public void ShowLeftPlayersCards()
        {
            var images = this.Database.CardImages;
            var players = this.Database.Players;
            int indexCards = 2;
            for (int i = 1; i < MaxPlayers; i++)
            {
                if (players[i] != null && !players[i].Bet.Equals(BetOptions.Fold))
                {
                    this.ShuffledDeck[i * 2].Image = images[indexCards];
                    indexCards++;
                    this.ShuffledDeck[i * 2 + 1].Image = images[indexCards];
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
