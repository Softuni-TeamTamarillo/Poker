using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    public class FlushBotBetMaker : BotBetMaker
    {
        public FlushBotBetMaker()
            : base()
        {
            this.BotChoiceMaker = new BotChoiceMakerOtherHand();
        }
    }
}
