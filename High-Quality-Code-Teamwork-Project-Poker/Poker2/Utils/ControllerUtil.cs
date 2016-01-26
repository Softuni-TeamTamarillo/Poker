namespace Poker2.Utils
{
    using System.Drawing;
    using System.Windows.Forms;

    using Poker2.Core.Controllers;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    public static class ControllerUtil
    {
        public static void SetLocations(Point[] locations, int[] xCoordinates, int[] yCoordinates)
        {
            for (int i = 0; i <= 6; i++)
            {
                locations[i].X = xCoordinates[i];
                locations[i].Y = yCoordinates[i];
            }
        }

        public static void SetLocations(Point[] locations, Point[] otherLocations)
        {
            for (int i = 0; i <= 6; i++)
            {
                locations[i] = otherLocations[i];
            }
        }

        public static void SetChipsImage(int chipAmount, PictureBox chip, string pathFolder, string[] pathFile, int count)
        {
            if (chipAmount == 0)
            {
                chip.Image = null;
            }
            if (chipAmount > 0 && chipAmount < 2000)
            {
                chip.Image = Image.FromFile(pathFolder + pathFile[0]);
            }
            else if (chipAmount < 5000)
            {
                chip.Image = Image.FromFile(pathFolder + pathFile[1]);
            }
            else if (chipAmount < 10000)
            {
                chip.Image = Image.FromFile(pathFolder + pathFile[2]);
            }
            else if (chipAmount < 25000)
            {
                chip.Image = Image.FromFile(pathFolder + pathFile[3]);
            }
            else
            {
                chip.Image = Image.FromFile(pathFolder + pathFile[4]);
            }
        }

        public static Image SetCardBackImage(string pathFile)
        {
            return Image.FromFile(pathFile);
        }

    }
}
