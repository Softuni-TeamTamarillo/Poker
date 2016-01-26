using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

    public class BotChoiceMakerOtherHand : BotChoiceMaker
    {
        public BotChoiceMakerOtherHand(IDatabase database) : base(database) { }
    }
}
