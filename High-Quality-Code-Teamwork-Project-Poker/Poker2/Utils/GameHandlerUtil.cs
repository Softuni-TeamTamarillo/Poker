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
        /// <summary>
        /// Adds chips to each player no matter wether is he still playing or not.
        /// </summary>
        /// <param name="players">The list of all players on the table</param>
        /// <param name="addedChips">The amount of chips to be added.</param>
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
