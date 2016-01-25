using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using Poker2.Core.Interfaces;
    public abstract class BotChoiceMaker :IBotChoiceMaker
    {
        private CommunityCardRound communityCardRound;
        public  virtual void Chooses()
        {
            
        }

        public CommunityCardRound CommunityCardRound { get; set; }
    }
}
