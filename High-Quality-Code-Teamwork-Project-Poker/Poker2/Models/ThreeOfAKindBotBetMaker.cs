using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    public class ThreeOfAKindBotBetMaker : BotBetMaker
    {
        public ThreeOfAKindBotBetMaker()
            : base()
        {
            this.BotChoiceMaker = new BotChoiceMakerOtherHand();
        }
    }
}
