using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    public class Database : IDatabase
    {
        public const int MaxPlayers = 6;
        public const int BigBlindDefaultValue = 500;

        private CommunityCardRound roundType;
        private int callAmount;//call
        private int raiseAmount;
        //private int windowHeight;//height 
        //private int windowWidth;//width

        private int bigBlind = BigBlindDefaultValue;//callChipsCount
        private int smallBlind = BigBlindDefaultValue / 2;//sb

        private int indexLastRaised;

        private int indexLastChecked;

        private IList<IPlayer> players;

        private IList<IPlayer> playersNotFoldedOrAllIn;

        private IList<string> listOfWinners;

        private IList<ICard> cardsToBeDealt;

        private IList<ICard> communityCards;

        private int leftPlayersCount;

        private Image[] cardImages;

        private PictureBox[] shuffledDeck;

        private PictureBox[] chips;

        private Panel[] playerPanels;



        public Database()
        {
            this.SetPlayers();
            PlayersNotFoldedOrAllIn = new List<IPlayer>(Players);
            BigBlind = BigBlindDefaultValue;
            SmallBlind = BigBlind / 2;
            CallAmount = BigBlind;
            RaiseAmount = 0;
            this.RoundType = CommunityCardRound.PreFlop;
            ListOfWinners = new List<string>();
            this.LeftPlayersCount = MaxPlayers;
            this.CardsToBeDealt = null;
            this.CommunityCards = null;
            this.IndexLastRaised = 0;
            this.IndexLastChecked = -1;

            this.ShuffledDeck = null;
            this.CardImages = null;
            this.Chips = null;
            this.PlayerPanels = null;
            LeftPlayersCount = MaxPlayers;
            AllInPlayersCount = 0;
            FoldedsPlayersCount = 0;
        }


        public IList<IPlayer> Players { get; set; }
        public IList<IPlayer> PlayersNotFoldedOrAllIn { get; set; }

        public int CallAmount { get; set; }

        public int RaiseAmount { get; set; }

        public int BigBlind { get; set; }

        public int SmallBlind { get; set; }

        public CommunityCardRound RoundType { get; set; }

        public IList<string> ListOfWinners { get; set; }

        public IList<ICard> CardsToBeDealt { get; set; }

        public  IList<ICard> CommunityCards { get; set; }

        public int IndexLastRaised { get; set; }

        public int IndexLastChecked { get; set; }

        public Image[] CardImages { get; set; }

        public PictureBox[] ShuffledDeck { get; set; }

        public PictureBox[] Chips { get; set; }

        public Panel[] PlayerPanels { get; set; }

        public int LeftPlayersCount { get; set; }

        public int AllInPlayersCount { get; set; }

        public int FoldedsPlayersCount { get; set; }

        public int PotChipsAmount { get; set; }

        private void SetPlayers()
        {
            Players = new List<IPlayer>(MaxPlayers);
            Players[0] = new Human();
            for (int i = 1; i < MaxPlayers; i++)
            {
                Players.Add(new Bot());
            }
        }
    }
}
