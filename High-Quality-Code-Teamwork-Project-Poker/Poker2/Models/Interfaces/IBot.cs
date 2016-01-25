using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    using Poker2.Core.Handlers.Interfaces;

    public interface IBot
    {
        IHandChecker HandChecker { get; }
    }
}
