namespace Poker2.Core
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Models;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public class Database : IDatabase
    {
        public const int MaxPlayers = 6;
        public const int BigBlindDefaultValue = 500;

        private CommunityCardRound roundType;
        private int callAmount;
        private int raiseAmount;

        private int bigBlind = BigBlindDefaultValue;
        private int smallBlind = BigBlindDefaultValue / 2;
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
            this.PlayersNotFoldedOrAllIn = new List<IPlayer>(this.Players);
            this.BigBlind = BigBlindDefaultValue;
            this.SmallBlind = this.BigBlind / 2;
            this.CallAmount = this.BigBlind;
            this.RaiseAmount = 0;
            this.RoundType = CommunityCardRound.PreFlop;
            this.ListOfWinners = new List<string>();
            this.LeftPlayersCount = MaxPlayers;
            this.CardsToBeDealt = null;
            this.CommunityCards = null;
            this.IndexLastRaised = 0;
            this.IndexLastChecked = -1;

            this.ShuffledDeck = null;
            this.CardImages = new Image[(MaxPlayers * 2) + 5];
            this.Chips = null;
            this.PlayerPanels = null;
            this.AllInPlayersCount = 0;
            this.FoldedPlayersCount = 0;
        }

        public IList<IPlayer> Players { get; set; }

        public IList<IPlayer> PlayersNotFoldedOrAllIn { get; set; }

        public int CallAmount { get; set; }

        public double RaiseAmount { get; set; }

        public int BigBlind { get; set; }

        public int SmallBlind { get; set; }

        public CommunityCardRound RoundType { get; set; }

        public IList<string> ListOfWinners { get; set; }

        public IList<ICard> CardsToBeDealt { get; set; }

        public IList<ICard> CommunityCards { get; set; }

        public int IndexLastRaised { get; set; }

        public int IndexLastChecked { get; set; }

        public Image[] CardImages { get; set; }

        public PictureBox[] ShuffledDeck { get; set; }

        public PictureBox[] Chips { get; set; }

        public Panel[] PlayerPanels { get; set; }

        public int LeftPlayersCount { get; set; }

        public int AllInPlayersCount { get; set; }

        public int FoldedPlayersCount { get; set; }

        public int PotChipsAmount { get; set; }

        private void SetPlayers()
        {
            this.Players = new List<IPlayer>(MaxPlayers);
            this.Players.Add(new Human());
            for (int i = 1; i < MaxPlayers; i++)
            {
                this.Players.Add(new Bot());
            }
        }
    }
}
