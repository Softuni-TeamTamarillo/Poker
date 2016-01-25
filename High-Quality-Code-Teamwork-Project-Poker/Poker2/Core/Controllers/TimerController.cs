using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using Poker2.Core.Controllers.Interfaces;
    using System.Windows.Forms;
    public class TimerController :ITimerController
    {
        public const int DefaultTurnTime = 60;
        private Timer humanTimer;

        private int turnTime;

        public TimerController()
        {
            TurnTime = DefaultTurnTime;
            humanTimer = new Timer();
            this.humanTimer.Interval = (1 * 1 * 1000);
            this.humanTimer.Tick += Events.timer_Tick;
        }

        public Timer HumanTimer { get; set; }

        public int TurnTime { get; set; }
    }
}
