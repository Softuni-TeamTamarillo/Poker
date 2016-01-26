using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models.Interfaces;

    public abstract class CommunityRound:ICommunityRound
    {
        private readonly ICard[] communityCards;

        public CommunityRound()
        {
            this.communityCards = null;
        }
        public ICard[] CommunityCards 
        {
            get
            {
                return this.communityCards;
            }
            
        }
        public void AdvanceRound()
        {
            
        }
    }
}
