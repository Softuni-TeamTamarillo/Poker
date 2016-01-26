using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;
    public abstract class BotBetMaker:IBotBetMaker
    {
        private readonly IDatabase database;
        public BotBetMaker(IDatabase database)
        {
            this.database = database;
            this.BotChoiceMaker = null;
        }
        public IBotChoiceMaker BotChoiceMaker { get; set; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
        public void Chooses()
        {
            
        }
    }
}
