using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    using System.Security.Cryptography.X509Certificates;
    using Poker2.Core.Interfaces;

    public interface IBotChoiceMaker
    {
        public IPlayer Player { get; set; }
    }
}
