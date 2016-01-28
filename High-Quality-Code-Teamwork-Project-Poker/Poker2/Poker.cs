using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2
{
    using Poker2.Forms;
    using System.Windows.Forms;

    using Poker2.Core;
    using Poker2.Core.Interfaces;

    public class Poker
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new PokerTable());
        }
    }
}
