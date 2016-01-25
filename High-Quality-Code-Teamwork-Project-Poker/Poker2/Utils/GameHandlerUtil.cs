using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Utils
{
    using Poker2.Forms;
    using Poker2.Models.Interfaces;

    public static class GameHandlerUtil
    {
        public static void PlayersAddChips(IList<IPlayer> players, int addedChips)
        {
            if (addedChips > 0)
            {
                foreach (var player in players)
                {
                    player.ChipsAmount += addedChips;
                }
            }
        }
    }
}
