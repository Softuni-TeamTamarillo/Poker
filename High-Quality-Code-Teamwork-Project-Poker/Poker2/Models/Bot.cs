using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Models
{
    using Poker2.Core.Handlers;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Models.Interfaces;
    using System.Windows.Forms;
    public class Bot : Player, IBot
    {
        private readonly IHandChecker handChecker;
        private readonly TextBox textbox;
        private readonly Label label;

        public Bot():base()
        {
            this.handChecker = new HandChecker();
            this.textbox = new TextBox();
            this.label = new Label();
        }

        public TextBox TextBox
        {
            get
            {
                return this.textbox;
            }
        }

        public Label Label
        {
            get
            {
                return this.label;
            }
        }
        public IHandChecker HandChecker
        {
            get
            {
                return this.handChecker;
            }
        }
        public void Checks()
        {

        }

        public void Calls(int index)
        {
            botTurn = false;
            this.Call -= callAmount;
            this.Text = "Call " + callAmount;
            textboxPot.Text = (int.Parse(textboxPot.Text) + callAmount).ToString();
        }

        public void Raises()
        {

        }

        public void GoesAllIn()
        {

        }

        public void Folds()
        {

        }
    }
}
