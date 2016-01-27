using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Handlers;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models.Interfaces;
    using System.Windows.Forms;

    /// <summary>
    /// Class responsible for the Artificial Intelligence participating in the game.
    /// </summary>
    public class Bot : Player, IBot
    {
        private readonly IHandChecker handChecker;

        public Bot():base()
        {
            this.handChecker = new HandChecker();
        }     
        public IHandChecker HandChecker
        {
            get
            {
                return this.handChecker;
            }
        }
    }
}
