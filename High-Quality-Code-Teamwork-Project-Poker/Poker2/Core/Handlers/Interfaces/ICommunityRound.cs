using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    using Poker2.Core.Interfaces;
    using Poker2.Models.Interfaces;

    public interface ICommunityRound
    {
        ICard[] CommunityCards { get; }

        IDatabase Database { get; }
        void AdvanceRound();

    }
}
