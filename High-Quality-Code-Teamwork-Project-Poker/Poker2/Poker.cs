namespace Poker2
{
    using System.Windows.Forms;

    using Poker2.Forms;
    
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
