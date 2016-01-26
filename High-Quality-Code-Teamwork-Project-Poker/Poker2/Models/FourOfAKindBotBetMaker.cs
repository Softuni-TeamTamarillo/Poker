using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    public class FourOfAKindBotBetMaker : BotBetMaker
    {
        public FourOfAKindBotBetMaker()
            : base()
        {
            this.BotChoiceMaker = new BotChoiceMakerOtherHand();
        }
    }
}
