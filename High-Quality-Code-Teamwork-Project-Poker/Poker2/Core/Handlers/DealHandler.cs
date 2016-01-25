using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using System.Collections;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Core;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class DealHandler:IDealHandler
    {
        public const int CardsInADeck = 52;
        private readonly static string[] imgCardsLocation = Directory.GetFiles("..\\..\\Resources\\Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
        private readonly IDatabase database;

        private int leftPlayersCount;
      
        private Image[] images;


        public DealHandler(IDatabase database)
        {
            this.database = database;
            this.LeftPlayersCount = this.Database.Players.Where(x => x != null).ToList().Count;
            this.images = new Image[this.LeftPlayersCount * 2 + 5];       
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public int LeftPlayersCount { get; set; }


        public Image[] Images { get; set; }

        public void ShuffleCards()
        {
            int[] numbersToBeShuffled = new int[CardsInADeck];
            DealHandlerUtil.InitializeNumbersArray(numbersToBeShuffled);
            DealHandlerUtil.ShuffleNumbers(numbersToBeShuffled);

            var cards = this.Database.CardsToBeDealt;
            cards = new List<ICard>(LeftPlayersCount * 2 + 5);

            for (int i = 0; i < LeftPlayersCount * 2 + 5; i++)
            {
                cards[i] = new Card();
            }
            DealHandlerUtil.GetImages(imgCardsLocation, numbersToBeShuffled, this.Database.CardImages, this.Database.Players);
            DealHandlerUtil.GetSuits(numbersToBeShuffled, this.Database.CardsToBeDealt);
            DealHandlerUtil.GetRanks(numbersToBeShuffled, this.Database.CardsToBeDealt);
        }

        public void DealCards()
        {
            DealPlayers();
            this.SetCommunityCards();
        }

        public void DealPlayers()
        {
            var players = this.Database.Players;
            int indexCards = 0;
            for (int i = 0; i < players.Count * 2; i++)
            {
                if (players[i] != null)
                {
                    DealPlayer(players[i], indexCards);
                    indexCards += 2;
                }
            }
        }

        public void SetCommunityCards()
        {
            this.Database.CommunityCards = new List<ICard>(this.Database.CardsToBeDealt);
            this.Database.CommunityCards.Skip(this.Database.CommunityCards.Count - 6);
        }

        private void DealPlayer(IPlayer player, int indexCards)
        {
            player.FirstCard = this.Database.CardsToBeDealt[indexCards];
            player.SecondCard = this.Database.CardsToBeDealt[indexCards + 1];
        }

        public void DealCommunityRound(CommunityCardRound round)
        {
            switch(this.Database.RoundType)
            {
                case CommunityCardRound.PreFlop:
                    this.DealCards();
                    break;
                case CommunityCardRound.Flop:
                    this.DealFlop();
                    break;
                case CommunityCardRound.Turn:
                    this.DealTurn();
                    break;
                case CommunityCardRound.River:
                    this.DealRiver();
                    break;
                default:
                    throw new ArgumentException("Not a poker community round.");
            }
        }

        public void DealFlop()
        {
            var players = this.Database.PlayersNotFoldedOrAllIn;
            foreach (var player in players)
            {
                if (player != null)
                {
                      player.CombinedCards.Add(
                          this.Database.CommunityCards[0]);
                    player.CombinedCards.Add(
                          this.Database.CommunityCards[1]);
                    player.CombinedCards.Add(
                          this.Database.CommunityCards[2]);  
                }
            }                 
        }

        public void DealTurn()
        {
            var players = this.Database.PlayersNotFoldedOrAllIn;

            foreach (var player in players)
            {
                if (player != null)
                {
                    player.CombinedCards.Add(
                          this.Database.CommunityCards[3]);  
                }
            }                 
        }

        public void DealRiver()
        {
            var players = this.Database.PlayersNotFoldedOrAllIn;
            foreach (var player in players)
            {
                if (player != null)
                {
                    player.CombinedCards.Add(this.Database.CommunityCards[4]);   
                }
            }                
        }
    }
}
