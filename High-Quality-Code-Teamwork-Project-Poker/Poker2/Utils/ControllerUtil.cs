namespace Poker2.Utils
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Contains the methods needed for Controller classes
    /// </summary>
    public static class ControllerUtil
    {
        /// <summary>
        /// Method used for setting locations by x and y coordinates for later object placement.
        /// </summary>
        /// <param name="locations">an array holding the points of the locations</param>
        /// <param name="coordinatesX">an array holding the x coordinates of the locations.</param>
        /// <param name="coordinatesY">an array holding the y coordinates of the locations.</param>
        public static void SetLocations(Point[] locations, int[] coordinatesX, int[] coordinatesY)
        {
            for (int i = 0; i < coordinatesX.Length; i++)
            {
                locations[i].X = coordinatesX[i];
                locations[i].Y = coordinatesY[i];
            }
        }

        /// <summary>
        /// Sets locations by given previously initialized other locations.
        /// </summary>
        /// <param name="locations">Locations to be set.</param>
        /// <param name="otherLocations">The given locations.</param>
        public static void SetLocations(Point[] locations, Point[] otherLocations)
        {
            for (int i = 0; i <= 6; i++)
            {
                locations[i] = otherLocations[i];
            }
        }

        /// <summary>
        /// Choses and sets a chips image from a file.
        /// </summary>
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

        /// <summary>
        /// Chooses and sets the card-back image from a file.
        /// </summary>
        /// <param name="pathFile">The given file.</param>
        /// <returns></returns>
        public static Image SetCardBackImage(string pathFile)
        {
            return Image.FromFile(pathFile);
        }
    }
}
