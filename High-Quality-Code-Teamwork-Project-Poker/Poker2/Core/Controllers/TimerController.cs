namespace Poker2.Core.Controllers
{
    using System.Windows.Forms;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class responsible for operations with the timer.
    /// </summary>
    public class TimerController : ITimerController
    {
        public const int DefaultTurnTime = 60;
        private readonly IPlayer player;

        private Timer humanTimer;
        private int turnTime;
        
        public TimerController(IPlayer player)
        {
            this.TurnTime = DefaultTurnTime;
            this.HumanTimer = new Timer();
            this.HumanTimer.Interval = 1000;
            this.HumanTimer.Tick += this.TimerTick;
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

        private void TimerTick(object sender, object e)
        {
            ////Time is expired
            if (this.ProgressBarTimer.Value <= 0)
            {
                this.Player.Bet = BetOptions.Fold;
            }

            ////Time is not expired and the progressbar is refreshed
            ////Each 6 seconds time bar decreases by 1/10
            if (this.TurnTime > 0)
            {
                this.TurnTime--;
                this.ProgressBarTimer.Value = (this.TurnTime / 6) * 100;
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
