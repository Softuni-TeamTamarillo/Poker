using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using Poker2.Core.Controllers.Interfaces;
    using System.Windows.Forms;

    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class responsible for operations with the timer.
    /// </summary>
    public class TimerController :ITimerController
    {
        public const int DefaultTurnTime = 60;
        private Timer humanTimer;

        private int turnTime;

        private readonly IPlayer player;
        public TimerController(IPlayer player)
        {
            TurnTime = DefaultTurnTime;
            humanTimer = new Timer();
            this.humanTimer.Interval = (1 * 1 * 1000);
            this.humanTimer.Tick += timer_Tick;
            this.ProgressBarTimer = new ProgressBar();
            this.SetProgressBar();
            this.player = player;
        }

        public IPlayer Player
        {
            get
            {
                return this.player;
            }
        }
        public Timer HumanTimer { get; set; }

        public int TurnTime { get; set; }

        public ProgressBar ProgressBarTimer { get; set; }

        private void timer_Tick(object sender, object e)
        {
            //Time is expired
            if (ProgressBarTimer.Value <= 0)
            {
                Player.Bet = BetOptions.Fold;
            }

            //Time is not expired and the progressbar is refreshed
            //Each 6 seconds time bar decreases by 1/10
            if (this.TurnTime > 0)
            {
                this.TurnTime--;
                ProgressBarTimer.Value = (this.TurnTime / 6) * 100;
            }
        }

        private void SetProgressBar()
        {
            this.ProgressBarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBarTimer.Location = new System.Drawing.Point(335, 631);
            this.ProgressBarTimer.Maximum = 1000;
            this.ProgressBarTimer.Name = "progressbarTimer";
            this.ProgressBarTimer.Size = new System.Drawing.Size(667, 23);
            this.ProgressBarTimer.TabIndex = 5;
            this.ProgressBarTimer.Value = 1000;
        }
    }
}
