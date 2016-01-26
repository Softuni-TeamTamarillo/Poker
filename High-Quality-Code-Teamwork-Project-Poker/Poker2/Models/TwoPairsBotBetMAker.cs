using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Interfaces;

    public class TwoPairsBotBetMaker : BotBetMaker
    {
        public TwoPairsBotBetMaker(IDatabase database)
            : base(database)
        {
            this.BotChoiceMaker = new BotChoiceMakerWeakHand(database);
        }
    }
}
