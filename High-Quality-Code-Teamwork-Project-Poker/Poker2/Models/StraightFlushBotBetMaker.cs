﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    public class StraightFlushBotBetMaker : BotBetMaker
    {
        public StraightFlushBotBetMaker()
            : base()
        {
            this.BotChoiceMaker = new BotChoiceMakerOtherHand();
        }
    }
}