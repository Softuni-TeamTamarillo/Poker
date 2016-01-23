using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Controllers
{
    using Poker2.Core.Controllers.Interfaces;
    using System.Windows.Forms;
    public class UpdatesController:IUpdatesController
    {
        public const int MaxUpdateCountValue = 10000000;
        private Timer updates;

        private int updateTickCount;

        public UpdatesController()
        {
            this.updateTickCount = MaxUpdateCountValue;
        }

        public Timer Updates { get; set; }
        public int UpdateTickCount { get; set; }
    }
}
