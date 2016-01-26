using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Models.Interfaces;
    public abstract class BotBetMaker:IBotBetMaker
    {
        public BotBetMaker()
        {
            this.BotChoiceMaker = null;
        }
        public IBotChoiceMaker BotChoiceMaker { get; set; }

        public void Chooses()
        {
            
        }
    }
}
