using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    public interface IGameHandler
    {
        void Start();

        void Finish();

        void ClearControls();

        void ClearGameStatistics();

        void SetGameStatistics();

    }
}
