using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Handlers;
    using Poker2.Models.Interfaces;
    public class BotChoiceMakerWeakHand : BotChoiceMaker
    {
        public BotChoiceMakerWeakHand(IPlayer player) : base(player) { }
    }
}
