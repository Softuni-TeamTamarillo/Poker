namespace Poker2.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Poker2.Core;
    using Poker2.Core.Controllers;
    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models.Enums;
    using Poker2.Models.Interfaces;

    public partial class PokerTable : Form
    {
        private readonly IList<IPlayer> players;
        private readonly IUpdatesController updater;

        private readonly IEngine engine;
        private readonly IDatabase database;
        private int windowHeight;
        private int windowWidth;
        
        public PokerTable()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.updater = new UpdatesController(this);
            this.Updater.Updates.Start();

            this.InitializeComponent();
            this.windowWidth = this.Width;
            this.windowHeight = this.Height;
            
            this.TextBoxPot.Enabled = false;
            this.TextBoxPlayerChips.Enabled = false;
            this.TextBoxBot1Chips.Enabled = false;
            this.TextBoxBot2Chips.Enabled = false;
            this.TextBoxBot3Chips.Enabled = false;
            this.TextBoxBot4Chips.Enabled = false;
            this.TextBoxBot5Chips.Enabled = false;

            this.TextBoxBigBlind.Visible = true;
            this.TextBoxSmallBlind.Visible = true;
            this.ButtonBigBlind.Visible = true;
            this.ButtonSmallBlind.Visible = true;
            this.TextBoxBigBlind.Visible = true;
            this.TextBoxSmallBlind.Visible = true;
            this.ButtonBigBlind.Visible = true;
            this.ButtonSmallBlind.Visible = true;
            this.TextBoxBigBlind.Visible = false;
            this.TextBoxSmallBlind.Visible = false;
            this.ButtonBigBlind.Visible = false;
            this.ButtonSmallBlind.Visible = false;

            this.database = new Database();
            this.players = this.Database.Players;

            this.TextBoxPlayerChips.Text = "Chips: " + this.Players[0].ChipsAmount.ToString();
            this.TextBoxBot1Chips.Text = "Chips: " + this.Players[1].ChipsAmount.ToString();
            this.TextBoxBot2Chips.Text = "Chips: " + this.Players[2].ChipsAmount.ToString();
            this.TextBoxBot3Chips.Text = "Chips: " + this.Players[3].ChipsAmount.ToString();
            this.TextBoxBot4Chips.Text = "Chips: " + this.Players[4].ChipsAmount.ToString();
            this.TextBoxBot5Chips.Text = "Chips: " + this.Players[5].ChipsAmount.ToString();

            this.TextBoxRaise.Text = (this.Database.BigBlind * 2).ToString();

            this.ButtonCall.Enabled = true;
            this.ButtonRaise.Enabled = true;
            this.ButtonFold.Enabled = true;

            this.engine = new Engine(this, this.Database);
        }

        public IUpdatesController Updater
        {
            get
            {
                return this.updater;
            }
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

        public IList<IPlayer> Players
        {
            get
            {
                return this.players;
            }
        }

        ////Updates status messages for all players
        public void Update_Tick(object sender, object e)
        {
            if (this.Players[0].ChipsAmount <= 0)
            {
                this.TextBoxPlayerChips.Text = "Chips : 0";
            }

            if (this.Players[1].ChipsAmount <= 0)
            {
                this.TextBoxBot1Chips.Text = "Chips : 0";
            }

            if (this.Players[2].ChipsAmount <= 0)
            {
                this.TextBoxBot2Chips.Text = "Chips : 0";
            }

            if (this.Players[3].ChipsAmount <= 0)
            {
                this.TextBoxBot3Chips.Text = "Chips : 0";
            }

            if (this.Players[4].ChipsAmount <= 0)
            {
                this.TextBoxBot4Chips.Text = "Chips : 0";
            }

            if (this.Players[5].ChipsAmount <= 0)
            {
                this.TextBoxBot5Chips.Text = "Chips : 0";
            }

            this.TextBoxPlayerChips.Text = "Chips : " + this.Players[0].ChipsAmount.ToString();
            this.TextBoxBot1Chips.Text = "Chips : " + this.Players[1].ChipsAmount.ToString();
            this.TextBoxBot2Chips.Text = "Chips : " + this.Players[2].ChipsAmount.ToString();
            this.TextBoxBot3Chips.Text = "Chips : " + this.Players[3].ChipsAmount.ToString();
            this.TextBoxBot4Chips.Text = "Chips : " + this.Players[4].ChipsAmount.ToString();
            this.TextBoxBot5Chips.Text = "Chips : " + this.Players[5].ChipsAmount.ToString();

            if (this.Players[0].ChipsAmount == 0)
            {
                this.Players[0].Active = false;
                this.Players[0].Bet = BetOptions.Fold;
                this.ButtonCall.Enabled = false;
                this.ButtonRaise.Enabled = false;
                this.ButtonFold.Enabled = false;
                this.ButtonCheck.Enabled = false;
            }
           
            if (this.updater.UpdateTickCount > 0)
            {
                this.updater.UpdateTickCount--;
            }

            ////Checks if human player can call or all in
            if (this.Players[0].ChipsAmount >= this.Database.CallAmount)
            {
                this.ButtonCall.Text = "Call " + this.Database.CallAmount.ToString();
            }
            else
            {
                this.ButtonCall.Text = "All in";
                this.ButtonRaise.Enabled = false;
            }

            ////Checks if human player can check
            if (this.Database.CallAmount > 0)
            {
                this.ButtonCheck.Enabled = false;
            }

            ////Checks if the human player should call or raise
            if (this.Database.CallAmount <= 0)
            {
                this.ButtonCheck.Enabled = true;
                this.ButtonCall.Text = "Call";
                this.ButtonCall.Enabled = false;
            }

            ////if human player is all in he can not raise
            ////Raise button is disabled
            if (this.Players[0].ChipsAmount <= 0)
            {
                this.ButtonRaise.Enabled = false;
            }

            ////This variable is used to check if human player can raise or all in
            int parsedValue;

            ////Checks if human player can raise or all in 
            if (this.TextBoxRaise.Text != string.Empty && int.TryParse(this.TextBoxRaise.Text, out parsedValue))
            {
                if (this.Players[0].ChipsAmount <= int.Parse(this.TextBoxRaise.Text))
                {
                    this.ButtonRaise.Text = "All in";
                }
                else
                {
                    this.ButtonRaise.Text = "Raise";
                }
            }

            ////If human player can not raise raise button is disabled
            if (this.Players[0].ChipsAmount < this.Database.CallAmount)
            {
                this.ButtonRaise.Enabled = false;
            }
        }

        ////Click Fold button Event 
        ////Describes a series of changes in four variable values, connected to fold status, that happen when  human player clicks Fold button
        private void FoldClick(object sender, EventArgs e)
        {
            this.LabelPlayerStatus.Text = "Fold";
            this.Players[0].Active = false;
            this.Players[0].Bet = BetOptions.Fold;
        }

        ////Click Check button Event 
        ////Describes a series of changes in four variable values, connected to Check status, that happen when human player clicks Check button
        private void CheckClick(object sender, EventArgs e)
        {
            ////Player checks
            if (this.Database.CallAmount <= 0)
            {
                this.Players[0].Active = false;
                this.LabelPlayerStatus.Text = "Check";
            }
            else
            {
                ////Check buton shoud only be enabled when call amount is 0
                this.ButtonCheck.Enabled = false;
            }
        }

        ////Click Call button Event 
        ////Describes a series of changes connected to Call status, that happen when human player clicks Call button
        private void CallClick(object sender, EventArgs e)
        {
            ////Refreshes player hand type status in case he is the last one to call the call amount
            ////and the click is followed by any of the three community cards rounds:Flop, Turn or River
          
            if (this.Players[0].ChipsAmount >= this.Database.CallAmount)
            {
                ////Human player chips value is recalculated and refreshed in TextBoxPlayerChips status box
                this.Players[0].ChipsAmount -= this.Database.CallAmount;
                this.TextBoxPlayerChips.Text = "Chips : " + this.Players[0].ChipsAmount.ToString();

                ////Pot text is refreshed with the new value
                ////If pot was empty before
                if (this.TextBoxPot.Text != string.Empty)
                {
                    this.TextBoxPot.Text = (int.Parse(this.TextBoxPot.Text) + this.Database.CallAmount).ToString();
                }
                else
                {
                    ////If pot was not empty new value is added to old value
                    this.TextBoxPot.Text = this.Database.CallAmount.ToString();
                }

                ////Human player status is refreshed
                ////Right for click is disabled
                ////Players[0].Call is reset with the new value
                this.Players[0].Active = false;
                this.LabelPlayerStatus.Text = "Call " + this.Database.CallAmount;
                this.Players[0].Call = this.Database.CallAmount;
            }
            else if (this.Players[0].ChipsAmount <= this.Database.CallAmount && this.Database.CallAmount > 0)
            {
                ////If human player's chips are less than call amount,
                ////he is all in and corresponding variables are reset with the new values
                this.TextBoxPot.Text = (int.Parse(this.TextBoxPot.Text) + this.Players[0].ChipsAmount).ToString();
                this.LabelPlayerStatus.Text = "All in " + this.Players[0].ChipsAmount;
                this.Players[0].ChipsAmount = 0;
                this.TextBoxPlayerChips.Text = "Chips : " + this.Players[0].ChipsAmount.ToString();
                this.Players[0].Active = false;
                this.ButtonFold.Enabled = false;
                this.Players[0].Call = this.Players[0].ChipsAmount;
            }
        }

        ////Click Raise button Event this.Players[0].ChipsAmount
        ////Describes a series of changes connected to Raise status, that happen when human player clicks Raise button
        private async void RaiseClick(object sender, EventArgs e)
        {
            ////Refreshes player hand type status in case he is the last one to call the call amount
            ////and the click is followed by any of the three community cards rounds:Flop, Turn or River
            ////Raise amount is not 0(empty string) 
            int parsedValue;
            if (this.TextBoxRaise.Text != string.Empty && int.TryParse(this.TextBoxRaise.Text, out parsedValue))
            {
                ////Checks if the player can raise with the selected amount
                if (this.Players[0].ChipsAmount > this.Database.CallAmount)
                {
                    ////if raised sum is not double current raise amount
                    if (this.Database.RaiseAmount * 2 > int.Parse(this.TextBoxRaise.Text))
                    {
                        this.TextBoxRaise.Text = (this.Database.RaiseAmount * 2).ToString();
                        MessageBox.Show("You must Raise at least twice as the currentPlayerCategoryFactor Raise !");
                        return;
                    }

                    ////Checks if human player has this amount of chips to make a raise
                    ////Resets corresponding variables if he can
                    if (this.Players[0].ChipsAmount >= int.Parse(this.TextBoxRaise.Text))
                    {
                        this.Database.CallAmount = int.Parse(this.TextBoxRaise.Text);
                        this.Database.RaiseAmount = int.Parse(this.TextBoxRaise.Text);
                        this.LabelPlayerStatus.Text = "Raise " + this.Database.CallAmount.ToString();
                        this.TextBoxPot.Text = (int.Parse(this.TextBoxPot.Text) + this.Database.CallAmount).ToString();
                        this.ButtonCall.Text = "Call";
                        this.Players[0].ChipsAmount -= int.Parse(this.TextBoxRaise.Text);
                        this.Players[0].Raise = Convert.ToInt32(this.Database.RaiseAmount);
                    }
                    else
                    {
                        ////In this case human player raises with all his chips, 
                        ////is all in
                        this.Database.CallAmount = this.Players[0].ChipsAmount;
                        this.Database.RaiseAmount = this.Players[0].ChipsAmount;
                        this.TextBoxPot.Text = (int.Parse(this.TextBoxPot.Text) + this.Players[0].ChipsAmount).ToString();
                        this.LabelPlayerStatus.Text = "Raise " + this.Database.CallAmount.ToString();
                        this.Players[0].ChipsAmount = 0;
                        this.Players[0].Raise = Convert.ToInt32(this.Database.RaiseAmount);
                    }
                }
            }
            else
            {
                ////if a invalid text for a sum is entered, human player is not allowed to raise
                MessageBox.Show("This is a number only field");
                return;
            }

            this.Players[0].Active = false;
        }

        ////AddChips event
        ////If player enters a number > 0 for the added chips,
        ////this number is added to all players chips amounts
        private void AddClick(object sender, EventArgs e)
        {
            if (this.TextBoxAddChips.Text == string.Empty)
            {
            }
            else
            {
                this.Players[0].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
                this.Players[1].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
                this.Players[2].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
                this.Players[3].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
                this.Players[4].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
                this.Players[5].ChipsAmount += int.Parse(this.TextBoxAddChips.Text);
            }

            this.TextBoxPlayerChips.Text = "Chips : " + this.Players[0].ChipsAmount.ToString();
        }

        ////Blinds button click event
        ////Shows buttons for the two blinds  with text messages for their amounts
        private void OptionsClick(object sender, EventArgs e)
        {
            this.TextBoxBigBlind.Text = this.Database.BigBlind.ToString();
            this.TextBoxSmallBlind.Text = this.Database.SmallBlind.ToString();
            if (this.TextBoxBigBlind.Visible == false)
            {
                this.TextBoxBigBlind.Visible = true;
                this.TextBoxSmallBlind.Visible = true;
                this.ButtonBigBlind.Visible = true;
                this.ButtonSmallBlind.Visible = true;
            }
            else
            {
                this.TextBoxBigBlind.Visible = false;
                this.TextBoxSmallBlind.Visible = false;
                this.ButtonBigBlind.Visible = false;
                this.ButtonSmallBlind.Visible = false;
            }
        }

        ////SmallBlind button click event
        ////Checks the entered text for small blind value
        private void SmallBlindClick(object sender, EventArgs e)
        {
            int parsedValue;

            ////Checks if entered amount is a round number
            if (this.TextBoxSmallBlind.Text.Contains(",") || this.TextBoxSmallBlind.Text.Contains("."))
            {
                MessageBox.Show("The Small Blind can be only round number !");
                this.TextBoxSmallBlind.Text = this.Database.SmallBlind.ToString();
                return;
            }

            ////Checks if entered amount is an integer number
            if (!int.TryParse(this.TextBoxSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                this.TextBoxSmallBlind.Text = this.Database.SmallBlind.ToString();
                return;
            }

            ////Checks the entered amount against upper limit of 100000
            if (int.Parse(this.TextBoxSmallBlind.Text) > 100000)
            {
                MessageBox.Show("The maximum of the Small Blind is 100 000 $");
                this.TextBoxSmallBlind.Text = this.Database.SmallBlind.ToString();
            }

            ////Checks the entered amount against lower limit of 250
            if (int.Parse(this.TextBoxSmallBlind.Text) < 250)
            {
                MessageBox.Show("The minimum of the Small Blind is 250 $");
            }

            ////if entered amount is correct, small blind value is reset with the new number
            if (int.Parse(this.TextBoxSmallBlind.Text) >= 250 && int.Parse(this.TextBoxSmallBlind.Text) <= 100000)
            {
                this.Database.SmallBlind = int.Parse(this.TextBoxSmallBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        ////BigBlind button click event
        ////Checks the entered text for big blind value
        private void BigBlingClick(object sender, EventArgs e)
        {
            int parsedValue;
            ////Checks if entered amount is a round number
            if (this.TextBoxBigBlind.Text.Contains(",") || this.TextBoxBigBlind.Text.Contains("."))
            {
                MessageBox.Show("The Big Blind can be only round number !");
                this.TextBoxBigBlind.Text = this.Database.BigBlind.ToString();
                return;
            }

            ////Checks if entered amount is an integer number
            if (!int.TryParse(this.TextBoxSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                this.TextBoxSmallBlind.Text = this.Database.BigBlind.ToString();
                return;
            }

            ////Checks the entered amount against upper limit of 200000
            if (int.Parse(this.TextBoxBigBlind.Text) > 200000)
            {
                MessageBox.Show("The maximum of the Big Blind is 200 000");
                this.TextBoxBigBlind.Text = this.Database.BigBlind.ToString();
            }

            ////Checks the entered amount against lower limit of 500
            if (int.Parse(this.TextBoxBigBlind.Text) < 500)
            {
                MessageBox.Show("The minimum of the Big Blind is 500 $");
            }

            ////if entered amount is correct big blind value is reset with the new number
            if (int.Parse(this.TextBoxBigBlind.Text) >= 500 && int.Parse(this.TextBoxBigBlind.Text) <= 200000)
            {
                this.Database.BigBlind = int.Parse(this.TextBoxBigBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        ////Layout change event
        ////Describes changes in layout dimensions
        private void Layout_Change(object sender, LayoutEventArgs e)
        {
            this.windowWidth = this.Width;
            this.windowHeight = this.Height;
        }

        ////Form loading event
        private void PokerTable_Load(object sender, EventArgs e)
        {
        }
    }
}