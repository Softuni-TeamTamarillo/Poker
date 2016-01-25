using System;
namespace Poker2.Utils
{
    using System.Collections.Generic;
    using System.Drawing;

    using Poker2.Models.Interfaces;

    public static class DealHandlerUtil
    {

        public static void SetCards(int count)
        {
            int[] arr = new int[count];
            InitializeNumbersArray(arr);

        }

        public static void InitializeNumbersArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }
        public static void ShuffleNumbers(int [] numbers)
        {
            Random randGenerator = new Random();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = randGenerator.Next(i, numbers.Length);
                int storedNumber = numbers[i];
                numbers[i] = numbers[numbers[i]];
                numbers[numbers[i]] = storedNumber;
            }
        }

        public static void GetImages(string[] imgLocation, int[] shuffledNumbers, Image [] images, IList<IPlayer> players)
        {
            int imageIndex = 0;
            int index = 0;
            foreach (var player in players)
            {
                if (player != null)
                {
                    images[index * 2] = Image.FromFile(imgLocation[shuffledNumbers[imageIndex]]);
                    imageIndex++;
                    images[index * 2 + 1] = Image.FromFile(imgLocation[shuffledNumbers[imageIndex]]);
                    imageIndex++;
                }
            }
        }

        public static void GetSuits(int[] shuffledNumbers, IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].Suit = (Suit)(shuffledNumbers[i] % 4);
            }
        }
        public static void GetRanks(int []shuffledNumbers, IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].Rank = (Rank)(shuffledNumbers[i] % 4 + 1);
            }
        }
    }
}