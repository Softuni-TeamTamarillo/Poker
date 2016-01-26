using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;

    public abstract class BotChoiceMaker :IBotChoiceMaker
    {
        private readonly IPlayer player;

        public BotChoiceMaker(IPlayer player)
        {
            this.Player = player;
        }

        public IPlayer Player { get; set; }
    }
}
