namespace Poker2.Core.Controllers
{

    /// <summary>
    /// Class that holds all the constants needed for the Controllers other classes and methods.
    /// </summary>
    public static class ControlConstants
    {
        public static readonly int[] PanelCoordX = { 570, 5, 65, 580, 1105, 1150 };
        public static readonly int[] PanelCoordY = { 470, 410, 55, 15, 55, 410 };

        public static readonly int[] CardCoordX = { 580, 15, 75, 590, 1115, 1160, 410, 520, 630, 740, 850};
        public static readonly int[] CardCoordY = { 480, 420, 65, 25, 65, 420, 265, 265, 265, 265, 265 };

        public static readonly int[] ChipsCoordX = { 750, 255, 350, 785, 970, 110, 550 };
        public static readonly int[] ChipsCoordY = { 500, 500, 140, 140, 140, 500, 190 };

        public const int DefaultPanelHeight = 150;
        public const int DefaultPanelWidth = 180;

        public const int MaximumCardsToBeDealt = 17;
        public const int CardsInADeck = 52;

        public const int CardImageHeight = 130;
        public const int CardImageWidth = 80;

        private static readonly string[] chipsFileNames = { "250.1999", "2000.4999", "5000.9999", "10000.24999", "25000.+"};
        private static readonly string pathChipsFolder = "..\\..\\Resources\\Assets\\Cards\\";
    }
}
