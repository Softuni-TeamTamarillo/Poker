namespace Poker2.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Poker2.Core;
    using Poker2.Core.Handlers;
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;

    public partial class PokerTable : Form
    {
        private readonly IEngine engine;
        private readonly IDatabase database;
        public PokerTable()
        {
            this.database = new Database();
            this.engine = new Engine(this, this.Database);

            this.callAmount = this.bigBlind;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.updates.Start();
            this.InitializeComponent();
            this.windowWidth = this.Width;
            this.windowHeight = this.Height;
            this.ShuffleCards();
            this.textboxPot.Enabled = false;
            this.textboxPlayerChips.Enabled = false;
            this.textboxBot1Chips.Enabled = false;
            this.textboxBot2Chips.Enabled = false;
            this.textboxBot3Chips.Enabled = false;
            this.textboxBot4Chips.Enabled = false;
            this.textboxBot5Chips.Enabled = false;

            this.textboxPlayerChips.Text = "Chips: " + this.playerChips.ToString();
            this.textboxBot1Chips.Text = "Chips: " + this.bot1Chips.ToString();
            this.textboxBot2Chips.Text = "Chips: " + this.bot2Chips.ToString();
            this.textboxBot3Chips.Text = "Chips: " + this.bot3Chips.ToString();
            this.textboxBot4Chips.Text = "Chips: " + this.bot4Chips.ToString();
            this.textboxBot5Chips.Text = "Chips: " + this.bot5Chips.ToString();

            this.timer.Interval = (1 * 1 * 1000);
            this.timer.Tick += timer_Tick;
            this.updates.Interval = (1 * 1 * 100);
            this.updates.Tick += Update_Tick;////updates.Tick is timer event
            this.textboxBigBlind.Visible = true;
            this.textboxSmallBlind.Visible = true;
            this.buttonBigBlind.Visible = true;
            this.buttonSmallBlind.Visible = true;
            this.textboxBigBlind.Visible = true;
            this.textboxSmallBlind.Visible = true;
            this.buttonBigBlind.Visible = true;
            this.buttonSmallBlind.Visible = true;
            this.textboxBigBlind.Visible = false;
            this.textboxSmallBlind.Visible = false;
            this.buttonBigBlind.Visible = false;
            this.buttonSmallBlind.Visible = false;
            this.textboxRaise.Text = (this.bigBlind * 2).ToString();
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        private void SetForm()
        {
            
        }
    }
}