using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core
{
    using Poker2.Core.Interfaces;
    using Poker2.Forms;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    public class Database : IDatabase
    {
        public const int Flop = 1;
        public const int Turn = 2;
        public const int River = 3;
        public const int End = 4;
        public const int MaxPlayers = 6;

        public const int BigBlindDefaultValue = 500;

        private int callAmount;//call
        private int foldedPlayers = 5;
        private int roundType; 
        private int raiseAmount;
        private int winnersCount = 0;//winners

        private int leftPlayers = MaxPlayers;//6

        private int last = 123;
        private int raisedTurn = 1;
        private bool isBetRaised = false;//raising

        private bool restart = false;

        private int windowHeight;//height 
        private int windowWidth;//width

        private int bigBlind = BigBlindDefaultValue;//callChipsCount
        private int smallBlind = BigBlindDefaultValue / 2;//sb

        private int turnCount = 0;

        private IList<IPlayer> players;

        private IList<IPlayer> playersNotFolded;

        private IList<IHand> competingHands;

        private IList<string> listOfWinners;
        private IHand winningHand;

        private PokerTable pokerTable;

        private AddChips addChips;

        public Database()
        {
            PokerTable = new PokerTable();
            AddChips = null;
            this.SetPlayers();
            PlayersNotFolded = Players;
            BigBlind = BigBlindDefaultValue;
            SmallBlind = BigBlind / 2;
            CallAmount = BigBlind;
            RaiseAmount = 0;
            RoundType = CommunityCardRound.PreFlop;
            LeftPlayers = MaxPlayers;
            IsBetRaised = false;
            this.turnCount = 0;
            Restart = false;
            this.Last = 123;
            RaisedTurn = 1;
            CompetingHands = new List<IHand>();
            ListOfWinners = new List<string>();
            Hand = null;
        }

        public PokerTable PokerTable { get; set; }
        public AddChips AddChips { get; set; }

        public IList<IPlayer> Players { get; set; }
        public IList<IPlayer> PlayersNotFolded { get; set; }

        public int CallAmount { get; set; }

        public int RaiseAmount { get; set; }

        public int BigBlind { get; set; }

        public int SmallBlind { get; set; }

        public CommunityCardRound RoundType { get; set; }

        public bool IsBetRaised { get; set; }

        public int LeftPlayers { get; set; }

        public int TurnCount { get; set; }

        public int Last { get; set; }

        public int RaisedTurn { get; set; }

        public bool Restart { get; set; }

        public IList<IHand> CompetingHands { get; set; }

        public IList<string> ListOfWinners { get; set; }



        public IHand Hand { get; set; }
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
