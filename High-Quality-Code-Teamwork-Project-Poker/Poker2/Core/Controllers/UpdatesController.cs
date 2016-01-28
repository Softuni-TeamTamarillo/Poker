namespace Poker2.Core.Controllers
{
    using System.Windows.Forms;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Forms;

    /// <summary>
    /// Class responsible for updating the data created with each timer tick.
    /// </summary>
    public class UpdatesController : IUpdatesController
    {
        public const int MaxUpdateCountValue = 10000000;
        private readonly PokerTable pokerTable;

        private Timer updates;
        private int updateTickCount;

        public UpdatesController(PokerTable pokerTable)
        {
            this.pokerTable = pokerTable;
            this.Updates = new Timer();
            this.UpdateTickCount = MaxUpdateCountValue;
            this.Updates.Interval = 100;
            this.Updates.Tick += this.PokerTable.Update_Tick;
        }

        public Timer Updates { get; set; }

        public int UpdateTickCount { get; set; }

        private PokerTable PokerTable
        {
            get
            {
                return this.pokerTable;
            }
        }
    }
}
