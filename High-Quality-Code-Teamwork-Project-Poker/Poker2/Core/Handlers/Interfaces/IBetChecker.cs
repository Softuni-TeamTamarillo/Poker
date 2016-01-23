using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using System.Windows.Forms;

    public interface IBetChecker
    {
        void Checkfold();

        void CheckCall();

        void CheckRaise();

        void CheckCheck();

        void CheckAllIn();
    }
}
