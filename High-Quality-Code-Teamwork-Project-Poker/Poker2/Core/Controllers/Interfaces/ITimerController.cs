using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers.Interfaces
{
    using System.Windows.Forms;

    using Poker2.Models.Interfaces;

    public interface ITimerController
    {
         IPlayer Player { get; }
        
         Timer HumanTimer { get; set; }

         int TurnTime { get; set; }

         ProgressBar ProgressBarTimer { get; set; }
    }
}
