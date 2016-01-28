namespace Poker2.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public interface IDatabase
    {
        IList<IPlayer> Players { get; set; }

        IList<IPlayer> PlayersNotFoldedOrAllIn { get; set; }

        int CallAmount { get; set; }

        double RaiseAmount { get; set; }

        int BigBlind { get; set; }

        int SmallBlind { get; set; }

        CommunityCardRound RoundType { get; set; }

        IList<string> ListOfWinners { get; set; }

        IList<ICard> CardsToBeDealt { get; set; }

        IList<ICard> CommunityCards { get; set; }

        Image[] CardImages { get; }

        PictureBox[] ShuffledDeck { get; }

        PictureBox[] Chips { get; }

        Panel[] PlayerPanels { get; set; }

        int IndexLastRaised { get; set; }

        int IndexLastChecked { get; set; }

        int LeftPlayersCount { get; set; }

        int AllInPlayersCount { get; set; }

        int FoldedPlayersCount { get; set; }

        int PotChipsAmount { get; set; }
    }
}
