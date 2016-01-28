using System;
namespace Poker2.Utils
{
    using System.Collections.Generic;
    using System.Drawing;

    using Poker2.Models.Interfaces;

    /// <summary>
    /// Contains methods needed for the dealing procedure.
    /// </summary>
    public static class DealHandlerUtil
    {
        /// <summary>
        /// Sets the initial count of the cards used in the game.
        /// </summary>
        /// <param name="count">The amount of cards.</param>
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

        /// <summary>
        /// Gives a random values to a given int array.
        /// </summary>
        /// <param name="numbers">The number array each element of whom is assigned to a card.</param>
        public static void ShuffleNumbers(int [] numbers)
        {
            Random randGenerator = new Random();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int index = randGenerator.Next(i + 1, numbers.Length);
                int storedNumber = numbers[i];
                numbers[i] = numbers[index];
                numbers[index] = storedNumber;
            }
        }

        /// <summary>
        /// Assignes card images to each non-folded player
        /// </summary>
       
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

        /// <summary>
        /// Determines which suits are the random-generated numbers representing.
        /// </summary>
        /// <param name="shuffledNumbers">The shuffled numbers array.</param>
        /// <param name="cards">List of the cards.</param>
        public static void GetSuits(int[] shuffledNumbers, IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].Suit = (Suit)(shuffledNumbers[i] % 4);
            }
        }

        /// <summary>
        /// Determines which ranks are the random-generated numbers representing.
        /// </summary>
        /// <param name="shuffledNumbers">The shuffled numbers array.</param>
        /// <param name="cards">List of the cards.</param>
        public static void GetRanks(int []shuffledNumbers, IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].Rank = (Rank)(shuffledNumbers[i] % 4 + 1);
            }
        }
    }
}