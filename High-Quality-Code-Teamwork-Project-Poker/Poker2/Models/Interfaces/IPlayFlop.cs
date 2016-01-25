using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models.Interfaces
{
    public interface IPlayFlop
    {
        void AddFlopCards(ICard thirdCard, ICard forthCard, ICard fifthCard);
    }
}
