using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    public interface IBotChoiceMaker
    {
        void Chooses();
    }
}
