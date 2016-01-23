using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using System.Drawing;
    using System.IO;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models.Interfaces;
    using Poker2.Utils;

    public class DealHandler:IDealHandler
    {
        public const int CardsInADeck = 52;
        private readonly static string[] imgCardsLocation = Directory.GetFiles("..\\..\\Resources\\Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);

        private int playersCount;

        private IList<IPlayer> players;

        private Image[] images;

        private ICard[] cardsToBeDealt;
        public DealHandler(IList<IPlayer> players, ICardController cardController)
        {
            this.Players = players;
            this.PlayersCount = players.Where(x => x != null).ToList().Count;
            this.images = new Image[this.PlayersCount * 2 + 5];
            this.CardsToBeDealt = null;
            CardController = cardController;
        }

        public int PlayersCount { get; set; }

        public IList<IPlayer> Players { get; set; }

        public Image[] Images { get; set; }

        public ICard[] CardsToBeDealt { get; set; }

        public ICardController CardController { get; set; }
        public void ShuffleCards()
        {
            int[] numbers = new int[CardsInADeck];
            HandlerUtil.InitializeNumbersArray(numbers);
            HandlerUtil.ShuffleNumbers(numbers);
            HandlerUtil.GetImages(imgCardsLocation, numbers, this.Images);
            CardsToBeDealt = new ICard[PlayersCount * 2 + 5];
            HandlerUtil.GetSuits(numbers, CardsToBeDealt);
            HandlerUtil.GetRanks(numbers, CardsToBeDealt);

        }

        public void DealCards()
        {
            DealPlayers();
            CardController.SetCardImagesPreFlop(Images, Players);
        }

        public void DealPlayers()
        {
            int indexCards = 0;
            for (int i = 0; i < PlayersCount * 2; i++)
            {
                if (Players[i] != null)
                {
                    DealPlayer(Players[i], indexCards);
                    indexCards += 2;
                }
            }

        }

        private void DealPlayer(IPlayer player, int indexCards)
        {
            player.FirstCard = CardsToBeDealt[indexCards];
            indexCards++;
            player.SecondCard = CardsToBeDealt[indexCards];
            indexCards++;
        }

        public void DealFlop()
        {
            CardController.SetFlopCardImages(Images);            
        }

        public void DealTurn()
        {
            CardController.SetTurnCardImage(Images);
        }

        public void DealRiver()
        {
            CardController.SetRiverCardImage(Images);
        }
    }
}
