﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    public class PairFromTableBotBetMaker : BotBetMaker
    {
        public PairFromTableBotBetMaker()
            : base()
        {
            this.BotChoiceMaker = new BotChoiceMakerWeakHand();
        }
    }
}
