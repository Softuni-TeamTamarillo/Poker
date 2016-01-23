using System;
namespace Poker2.Utils
{
    using System.Drawing;

    using Poker2.Models.Interfaces;

    public static class HandlerUtil
    {
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

        public static void GetImages(string[] imgLocation, int[] shuffledNumbers, Image [] images)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Image.FromFile(imgLocation[shuffledNumbers[i]]);
            }
        }

        public static void GetSuits(int[] shuffledNumbers, ICard[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Suit = (Suit)(shuffledNumbers[i] % 4);
            }
        }
        public static void GetRanks(int []shuffledNumbers, ICard [] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Suit = (Suit)(shuffledNumbers[i] % 4);
            }
        }
    }
}