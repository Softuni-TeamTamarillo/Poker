using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker2.Models.Enums;

namespace Poker2.Core.Interfaces
{
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    public interface IDatabase
    {
        PokerTable PokerTable { get; set; }
        AddChips AddChips { get; set; }

        IList<IPlayer> Players { get; set; }
        IList<IPlayer> PlayersNotFolded { get; set; }

        int CallAmount { get; set; }

        int RaiseAmount { get; set; }

        int BigBlind { get; set; }

        int SmallBlind { get; set; }

        CommunityCardRound RoundType { get; set; }

        bool IsBetRaised { get; set; }

        int LeftPlayers { get; set; }

        int TurnCount { get; set; }

        int Last { get; set; }

        int RaisedTurn { get; set; }

        bool Restart { get; set; }

        IList<IHand> CompetingHands { get; set; }

        IList<string> ListOfWinners { get; set; }
        IHand Hand { get; set; }



    }
}
