using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Interfaces;

    public class FullHouseBotBetMaker : BotBetMaker
    {
        public FullHouseBotBetMaker(IDatabase database)
            : base(database)
        {
            this.BotChoiceMaker = new BotChoiceMakerOtherHand(database);
        }
    }
}
