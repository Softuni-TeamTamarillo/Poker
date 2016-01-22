using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    public interface IPlayer
    {
        int ChipsAmount { get; set; }

        int Call { get; set; }

        int Raise { get; set; }

        bool Active { get; set; }

        bool IsFolded { get; set; }

        bool HasCalled { get; set; }

        bool HasChecked { get; set; }

        bool HasRaised { get; set; }

        bool IsAllIn { get; set; }

        ICard FirstCard { get; set; }

        ICard SecondCard { get; set; }
    }
}
