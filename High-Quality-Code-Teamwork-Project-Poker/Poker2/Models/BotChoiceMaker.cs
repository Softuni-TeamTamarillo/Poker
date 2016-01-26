using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

    public abstract class BotChoiceMaker :IBotChoiceMaker
    {
        private readonly IDatabase database;

        public BotChoiceMaker(IDatabase database)
        {
            this.database = database;
        }

        public IPlayer Player { get; set; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
    }
}
