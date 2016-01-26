using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using Poker2.Core.Controllers.Interfaces;
    using System.Windows.Forms;

    /// <summary>
    /// Class responsible for operations with the timer.
    /// </summary>
    public class TimerController :ITimerController
    {
        public const int DefaultTurnTime = 60;
        private Timer humanTimer;

        private int turnTime;

        /// <summary>
        /// Parameterless Constructor where all timer properties are being set with their default values.
        /// The timer is assigned with the timer_tick event.
        /// </summary>
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
