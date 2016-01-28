using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using Poker2.Core.Controllers.Interfaces;
    using System.Windows.Forms;

    using Poker2.Forms;

    /// <summary>
    /// Class responsible for updating the data created with each timer tick.
    /// </summary>
    public class UpdatesController:IUpdatesController
    {
        public const int MaxUpdateCountValue = 10000000;
        private Timer updates;

        private readonly PokerTable pokerTable;
        private int updateTickCount;

        public UpdatesController(PokerTable pokerTable)
        {
            this.pokerTable = pokerTable;
            this.Updates = new Timer();
            this.UpdateTickCount = MaxUpdateCountValue;
            this.Updates.Interval = (1 * 1 * 100);
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
