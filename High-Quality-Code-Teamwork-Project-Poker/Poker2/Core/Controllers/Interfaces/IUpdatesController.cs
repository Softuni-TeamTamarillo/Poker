using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers.Interfaces
{
    using System.Windows.Forms;

    public interface IUpdatesController
    {
        Timer Updates { get; set; }
        int UpdateTickCount { get; set; }
    }
}
