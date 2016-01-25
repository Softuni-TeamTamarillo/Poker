using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2
{
    using System.Windows.Forms;

    public class Events
    {
        private async void timer_Tick(object sender, object e)
        {
            //Time is expired
            if (progressbarTimer.Value <= 0)
            {
                this.playerFoldOrAllIn = true;
                await Turns();
            }

            //Time is not expired and the progressbar is refreshed
            //Each 6 seconds time bar decreases by 1/10
            if (playerTime > 0)
            {
                playerTime--;
                progressbarTimer.Value = (playerTime / 6) * 100;
            }
        }

        //Updates status messages for all players
        private void Update_Tick(object sender, object e)
        {
            if (this.playerChips <= 0)
            {
                textboxPlayerChips.Text = "Chips : 0";
            }
            if (bot1Chips <= 0)
            {
                textboxBot1Chips.Text = "Chips : 0";
            }
            if (bot2Chips <= 0)
            {
                textboxBot2Chips.Text = "Chips : 0";
            }
            if (bot3Chips <= 0)
            {
                textboxBot3Chips.Text = "Chips : 0";
            }
            if (bot4Chips <= 0)
            {
                textboxBot4Chips.Text = "Chips : 0";
            }
            if (bot5Chips <= 0)
            {
                textboxBot5Chips.Text = "Chips : 0";
            }
            textboxPlayerChips.Text = "Chips : " + this.playerChips.ToString();
            textboxBot1Chips.Text = "Chips : " + bot1Chips.ToString();
            textboxBot2Chips.Text = "Chips : " + bot2Chips.ToString();
            textboxBot3Chips.Text = "Chips : " + bot3Chips.ToString();
            textboxBot4Chips.Text = "Chips : " + bot4Chips.ToString();
            textboxBot5Chips.Text = "Chips : " + bot5Chips.ToString();

            //If human player is all in
            //Human player's button controls are disabled
            //and corresponding variables are set accordingly
            if (this.playerChips <= 0)
            {
                this.isPlayerTurn = false;
                this.playerFoldOrAllIn = true;
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                buttonCheck.Enabled = false;
            }

            //???
            if (up > 0)
            {
                up--;
            }

            //Checks if human player can call or all in
            if (this.playerChips >= callAmount)
            {
                buttonCall.Text = "Call " + callAmount.ToString();
            }
            else
            {
                buttonCall.Text = "All in";
                buttonRaise.Enabled = false;
            }

            //Checks if human player can check
            if (callAmount > 0)
            {
                buttonCheck.Enabled = false;
            }

            //Checks if the human player should call or raise
            if (callAmount <= 0)
            {
                buttonCheck.Enabled = true;
                buttonCall.Text = "Call";
                buttonCall.Enabled = false;
            }

            //if human player is all in he can not raise
            //Raise button is disabled
            if (this.playerChips <= 0)
            {
                buttonRaise.Enabled = false;
            }

            //This variable is used to check if human player can raise or all in
            int parsedValue;

            //Checks if human player can raise or all in 
            if (textboxRaise.Text != "" && int.TryParse(textboxRaise.Text, out parsedValue))
            {
                if (this.playerChips <= int.Parse(textboxRaise.Text))
                {
                    buttonRaise.Text = "All in";
                }
                else
                {
                    buttonRaise.Text = "Raise";
                }
            }

            //If human player can not raise raise button is disabled
            if (this.playerChips < callAmount)
            {
                buttonRaise.Enabled = false;
            }
        }

        //Click Fold button Event 
        //Describes a series of changes in four variable values, connected to fold status, that happen when  human player clicks Fold button
        private async void bFold_Click(object sender, EventArgs e)
        {
            labelPlayerStatus.Text = "Fold";
            this.isPlayerTurn = false;
            this.playerFoldOrAllIn = true;
            await Turns();
        }

        //Click Check button Event 
        //Describes a series of changes in four variable values, connected to Check status, that happen when human player clicks Check button
        private async void bCheck_Click(object sender, EventArgs e)
        {
            //Player checks
            if (callAmount <= 0)
            {
                this.isPlayerTurn = false;
                labelPlayerStatus.Text = "Check";
            }
            //Check buton shoud only be enabled when call amount is 0
            else
            {
                //pStatus.Text = "All in " + playerChips;

                buttonCheck.Enabled = false;
            }
            await Turns();
        }

        //Click Call button Event 
        //Describes a series of changes connected to Call status, that happen when human player clicks Call button
        private async void bCall_Click(object sender, EventArgs e)
        {
            //Refreshes player hand type status in case he is the last one to call the call amount
            //and the click is followed by any of the three community cards rounds:Flop, Turn or River
            Rules(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
            if (this.playerChips >= callAmount)
            {
                //Human player chips value is recalculated and refreshed in textboxPlayerChips status box
                this.playerChips -= callAmount;
                textboxPlayerChips.Text = "Chips : " + this.playerChips.ToString();

                //Pot text is refreshed with the new value
                //If pot was empty before
                if (textboxPot.Text != "")
                {
                    textboxPot.Text = (int.Parse(textboxPot.Text) + callAmount).ToString();
                }
                //If pot was not empty new value is added to old value
                else
                {
                    textboxPot.Text = callAmount.ToString();
                }

                //Human player status is refreshed
                //Right for click is disabled
                //playerCall is reset with the new value
                this.isPlayerTurn = false;
                labelPlayerStatus.Text = "Call " + callAmount;
                this.playerCall = callAmount;
            }

                //If human player's chips are less than call amount,
            //he is all in and corresponding variables are reset with the new values
            else if (this.playerChips <= callAmount && callAmount > 0)
            {
                textboxPot.Text = (int.Parse(textboxPot.Text) + this.playerChips).ToString();
                labelPlayerStatus.Text = "All in " + this.playerChips;
                this.playerChips = 0;
                textboxPlayerChips.Text = "Chips : " + this.playerChips.ToString();
                this.isPlayerTurn = false;
                buttonFold.Enabled = false;
                this.playerCall = this.playerChips;
            }
            await Turns();
        }

        //Click Raise button Event 
        //Describes a series of changes connected to Raise status, that happen when human player clicks Raise button
        private async void bRaise_Click(object sender, EventArgs e)
        {
            //Refreshes player hand type status in case he is the last one to call the call amount
            //and the click is followed by any of the three community cards rounds:Flop, Turn or River
            Rules(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
            int parsedValue;

            //Raise amount is not 0(empty string) 
            if (textboxRaise.Text != "" && int.TryParse(textboxRaise.Text, out parsedValue))
            {
                //Checks if the player can raise with the selected amount
                if (this.playerChips > callAmount)
                {
                    //if raised sum is not double current raise amount
                    if (this.raiseAmount * 2 > int.Parse(textboxRaise.Text))
                    {
                        textboxRaise.Text = (this.raiseAmount * 2).ToString();
                        MessageBox.Show("You must Raise at least twice as the currentPlayerCategoryFactor Raise !");
                        return;
                    }

                    //Checks if human player has this amount of chips to make a raise
                    //Resets corresponding variables if he can
                    if (this.playerChips >= int.Parse(textboxRaise.Text))
                    {
                        callAmount = int.Parse(textboxRaise.Text);
                        this.raiseAmount = int.Parse(textboxRaise.Text);
                        labelPlayerStatus.Text = "Raise " + callAmount.ToString();
                        textboxPot.Text = (int.Parse(textboxPot.Text) + callAmount).ToString();
                        buttonCall.Text = "Call";
                        this.playerChips -= int.Parse(textboxRaise.Text);
                        isBetRaised = true;
                        last = 0;
                        this.playerRaise = Convert.ToInt32(this.raiseAmount);
                    }
                    //In this case human player raises with all his chips, 
                    //is all in
                    else
                    {
                        callAmount = this.playerChips;
                        this.raiseAmount = this.playerChips;
                        textboxPot.Text = (int.Parse(textboxPot.Text) + this.playerChips).ToString();
                        labelPlayerStatus.Text = "Raise " + callAmount.ToString();
                        this.playerChips = 0;
                        isBetRaised = true;
                        last = 0;
                        this.playerRaise = Convert.ToInt32(this.raiseAmount);
                    }
                }
            }

                //if a invalid text for a sum is entered, human player is not allowed to raise
            else
            {
                MessageBox.Show("This is a number only field");
                return;
            }

            //
            this.isPlayerTurn = false;
            await Turns();
        }

        //AddChips  event
        //If player enters a number > 0 for the added chips,
        //this number is added to all players chips amounts
        private void bAdd_Click(object sender, EventArgs e)
        {
            if (textboxAddChips.Text == "") { }
            else
            {
                this.playerChips += int.Parse(textboxAddChips.Text);
                bot1Chips += int.Parse(textboxAddChips.Text);
                bot2Chips += int.Parse(textboxAddChips.Text);
                bot3Chips += int.Parse(textboxAddChips.Text);
                bot4Chips += int.Parse(textboxAddChips.Text);
                bot5Chips += int.Parse(textboxAddChips.Text);
            }
            textboxPlayerChips.Text = "Chips : " + this.playerChips.ToString();
        }

        //Blinds button click event
        //Shows buttons for the two blinds  with text messages for their amounts
        private void bOptions_Click(object sender, EventArgs e)
        {
            textboxBigBlind.Text = this.bigBlind.ToString();
            textboxSmallBlind.Text = smallBlind.ToString();
            if (textboxBigBlind.Visible == false)
            {
                textboxBigBlind.Visible = true;
                textboxSmallBlind.Visible = true;
                buttonBigBlind.Visible = true;
                buttonSmallBlind.Visible = true;
            }
            else
            {
                textboxBigBlind.Visible = false;
                textboxSmallBlind.Visible = false;
                buttonBigBlind.Visible = false;
                buttonSmallBlind.Visible = false;
            }
        }

        //SmallBlind button click event
        //Checks the entered text for small blind value
        private void bSB_Click(object sender, EventArgs e)
        {
            int parsedValue;

            //Checks if entered amount is a round number
            if (textboxSmallBlind.Text.Contains(",") || textboxSmallBlind.Text.Contains("."))
            {
                MessageBox.Show("The Small Blind can be only round number !");
                textboxSmallBlind.Text = smallBlind.ToString();
                return;
            }

            //Checks if entered amount is an integer number
            if (!int.TryParse(textboxSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                textboxSmallBlind.Text = smallBlind.ToString();
                return;
            }

            //Checks the entered amount against upper limit of 100000
            if (int.Parse(textboxSmallBlind.Text) > 100000)
            {
                MessageBox.Show("The maximum of the Small Blind is 100 000 $");
                textboxSmallBlind.Text = smallBlind.ToString();
            }

            //Checks the entered amount against lower limit of 250
            if (int.Parse(textboxSmallBlind.Text) < 250)
            {
                MessageBox.Show("The minimum of the Small Blind is 250 $");
            }

            //if entered amount is correct, small blind value is reset with the new number
            if (int.Parse(textboxSmallBlind.Text) >= 250 && int.Parse(textboxSmallBlind.Text) <= 100000)
            {
                smallBlind = int.Parse(textboxSmallBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        //BigBlind button click event
        //Checks the entered text for big blind value
        private void bBB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            //Checks if entered amount is a round number
            if (textboxBigBlind.Text.Contains(",") || textboxBigBlind.Text.Contains("."))
            {
                MessageBox.Show("The Big Blind can be only round number !");
                textboxBigBlind.Text = this.bigBlind.ToString();
                return;
            }

            //Checks if entered amount is an integer number
            if (!int.TryParse(textboxSmallBlind.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                textboxSmallBlind.Text = this.bigBlind.ToString();
                return;
            }

            //Checks the entered amount against upper limit of 200000
            if (int.Parse(textboxBigBlind.Text) > 200000)
            {
                MessageBox.Show("The maximum of the Big Blind is 200 000");
                textboxBigBlind.Text = this.bigBlind.ToString();
            }

            //Checks the entered amount against lower limit of 500
            if (int.Parse(textboxBigBlind.Text) < 500)
            {
                MessageBox.Show("The minimum of the Big Blind is 500 $");
            }

            //if entered amount is correct big blind value is reset with the new number
            if (int.Parse(textboxBigBlind.Text) >= 500 && int.Parse(textboxBigBlind.Text) <= 200000)
            {
                this.bigBlind = int.Parse(textboxBigBlind.Text);
                MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
            }
        }

        //Layout change event
        //Describes changes in layout dimensions
        private void Layout_Change(object sender, LayoutEventArgs e)
        {
            windowWidth = this.Width;
            windowHeight = this.Height;
        }


        //Form loading event
        private void PokerTable_Load(object sender, EventArgs e)
        {

        }
    }
}
