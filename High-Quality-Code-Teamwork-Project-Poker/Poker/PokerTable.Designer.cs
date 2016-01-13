namespace Poker
{
    partial class PokerTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFold = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonCall = new System.Windows.Forms.Button();
            this.buttonRaise = new System.Windows.Forms.Button();
            this.progressbarTimer = new System.Windows.Forms.ProgressBar();
            this.textboxPlayerChips = new System.Windows.Forms.TextBox();
            this.buttonAddChips = new System.Windows.Forms.Button();
            this.textboxAddChips = new System.Windows.Forms.TextBox();
            this.textboxBot5Chips = new System.Windows.Forms.TextBox();
            this.textboxBot4Chips = new System.Windows.Forms.TextBox();
            this.textboxBot3Chips = new System.Windows.Forms.TextBox();
            this.textboxBot2Chips = new System.Windows.Forms.TextBox();
            this.textboxBot1Chips = new System.Windows.Forms.TextBox();
            this.textboxPot = new System.Windows.Forms.TextBox();
            this.buttonBlinds = new System.Windows.Forms.Button();
            this.buttonBigBlind = new System.Windows.Forms.Button();
            this.textboxSmallBlind = new System.Windows.Forms.TextBox();
            this.buttonSmallBlind = new System.Windows.Forms.Button();
            this.textboxBigBlind = new System.Windows.Forms.TextBox();
            this.labelBot5Status = new System.Windows.Forms.Label();
            this.labelBot4Status = new System.Windows.Forms.Label();
            this.labelBot3Status = new System.Windows.Forms.Label();
            this.labelBot1Status = new System.Windows.Forms.Label();
            this.labelPlayerStatus = new System.Windows.Forms.Label();
            this.labelBot2Status = new System.Windows.Forms.Label();
            this.labelPot = new System.Windows.Forms.Label();
            this.textboxRaise = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonFold
            // 
            this.buttonFold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFold.Location = new System.Drawing.Point(335, 660);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(130, 62);
            this.buttonFold.TabIndex = 0;
            this.buttonFold.Text = "Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.bFold_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheck.Location = new System.Drawing.Point(494, 660);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(134, 62);
            this.buttonCheck.TabIndex = 2;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // buttonCall
            // 
            this.buttonCall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCall.Location = new System.Drawing.Point(667, 661);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(126, 62);
            this.buttonCall.TabIndex = 3;
            this.buttonCall.Text = "Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.bCall_Click);
            // 
            // buttonRaise
            // 
            this.buttonRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRaise.Location = new System.Drawing.Point(835, 661);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(124, 62);
            this.buttonRaise.TabIndex = 4;
            this.buttonRaise.Text = "Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // progressbarTimer
            // 
            this.progressbarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressbarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.progressbarTimer.Location = new System.Drawing.Point(335, 631);
            this.progressbarTimer.Maximum = 1000;
            this.progressbarTimer.Name = "progressbarTimer";
            this.progressbarTimer.Size = new System.Drawing.Size(667, 23);
            this.progressbarTimer.TabIndex = 5;
            this.progressbarTimer.Value = 1000;
            // 
            // textboxPlayerChips
            // 
            this.textboxPlayerChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textboxPlayerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPlayerChips.Location = new System.Drawing.Point(755, 553);
            this.textboxPlayerChips.Name = "textboxPlayerChips";
            this.textboxPlayerChips.Size = new System.Drawing.Size(125, 23);
            this.textboxPlayerChips.TabIndex = 6;
            this.textboxPlayerChips.Text = "Chips : 0";
            // 
            // buttonAddChips
            // 
            this.buttonAddChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddChips.Location = new System.Drawing.Point(12, 697);
            this.buttonAddChips.Name = "buttonAddChips";
            this.buttonAddChips.Size = new System.Drawing.Size(75, 25);
            this.buttonAddChips.TabIndex = 7;
            this.buttonAddChips.Text = "AddChips";
            this.buttonAddChips.UseVisualStyleBackColor = true;
            this.buttonAddChips.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // textboxAddChips
            // 
            this.textboxAddChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textboxAddChips.Location = new System.Drawing.Point(93, 700);
            this.textboxAddChips.Name = "textboxAddChips";
            this.textboxAddChips.Size = new System.Drawing.Size(125, 20);
            this.textboxAddChips.TabIndex = 8;
            // 
            // textboxBot5Chips
            // 
            this.textboxBot5Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxBot5Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBot5Chips.Location = new System.Drawing.Point(1012, 553);
            this.textboxBot5Chips.Name = "textboxBot5Chips";
            this.textboxBot5Chips.Size = new System.Drawing.Size(125, 23);
            this.textboxBot5Chips.TabIndex = 9;
            this.textboxBot5Chips.Text = "Chips : 0";
            // 
            // textboxBot4Chips
            // 
            this.textboxBot4Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxBot4Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBot4Chips.Location = new System.Drawing.Point(970, 81);
            this.textboxBot4Chips.Name = "textboxBot4Chips";
            this.textboxBot4Chips.Size = new System.Drawing.Size(125, 23);
            this.textboxBot4Chips.TabIndex = 10;
            this.textboxBot4Chips.Text = "Chips : 0";
            // 
            // textboxBot3Chips
            // 
            this.textboxBot3Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxBot3Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBot3Chips.Location = new System.Drawing.Point(786, 81);
            this.textboxBot3Chips.Name = "textboxBot3Chips";
            this.textboxBot3Chips.Size = new System.Drawing.Size(125, 23);
            this.textboxBot3Chips.TabIndex = 11;
            this.textboxBot3Chips.Text = "Chips : 0";
            // 
            // textboxBot2Chips
            // 
            this.textboxBot2Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBot2Chips.Location = new System.Drawing.Point(276, 81);
            this.textboxBot2Chips.Name = "textboxBot2Chips";
            this.textboxBot2Chips.Size = new System.Drawing.Size(125, 23);
            this.textboxBot2Chips.TabIndex = 12;
            this.textboxBot2Chips.Text = "Chips : 0";
            // 
            // textboxBot1Chips
            // 
            this.textboxBot1Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textboxBot1Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBot1Chips.Location = new System.Drawing.Point(181, 553);
            this.textboxBot1Chips.Name = "textboxBot1Chips";
            this.textboxBot1Chips.Size = new System.Drawing.Size(125, 23);
            this.textboxBot1Chips.TabIndex = 13;
            this.textboxBot1Chips.Text = "Chips : 0";
            // 
            // textboxPot
            // 
            this.textboxPot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textboxPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPot.Location = new System.Drawing.Point(606, 212);
            this.textboxPot.Name = "textboxPot";
            this.textboxPot.Size = new System.Drawing.Size(125, 23);
            this.textboxPot.TabIndex = 14;
            this.textboxPot.Text = "0";
            // 
            // buttonBlinds
            // 
            this.buttonBlinds.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBlinds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlinds.Location = new System.Drawing.Point(1, 198);
            this.buttonBlinds.Name = "buttonBlinds";
            this.buttonBlinds.Size = new System.Drawing.Size(86, 50);
            this.buttonBlinds.TabIndex = 15;
            this.buttonBlinds.Text = "BigBlind/ SmallBlind";
            this.buttonBlinds.UseVisualStyleBackColor = false;
            this.buttonBlinds.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // buttonBigBlind
            // 
            this.buttonBigBlind.Location = new System.Drawing.Point(1, 318);
            this.buttonBigBlind.Name = "buttonBigBlind";
            this.buttonBigBlind.Size = new System.Drawing.Size(75, 23);
            this.buttonBigBlind.TabIndex = 16;
            this.buttonBigBlind.Text = "Big Blind";
            this.buttonBigBlind.UseVisualStyleBackColor = true;
            this.buttonBigBlind.Click += new System.EventHandler(this.bBB_Click);
            // 
            // textboxSmallBlind
            // 
            this.textboxSmallBlind.Location = new System.Drawing.Point(1, 292);
            this.textboxSmallBlind.Name = "textboxSmallBlind";
            this.textboxSmallBlind.Size = new System.Drawing.Size(75, 20);
            this.textboxSmallBlind.TabIndex = 17;
            this.textboxSmallBlind.Text = "250";
            // 
            // buttonSmallBlind
            // 
            this.buttonSmallBlind.Location = new System.Drawing.Point(1, 263);
            this.buttonSmallBlind.Name = "buttonSmallBlind";
            this.buttonSmallBlind.Size = new System.Drawing.Size(75, 23);
            this.buttonSmallBlind.TabIndex = 18;
            this.buttonSmallBlind.Text = "Small Blind";
            this.buttonSmallBlind.UseVisualStyleBackColor = true;
            this.buttonSmallBlind.Click += new System.EventHandler(this.bSB_Click);
            // 
            // textboxBigBlind
            // 
            this.textboxBigBlind.Location = new System.Drawing.Point(1, 347);
            this.textboxBigBlind.Name = "textboxBigBlind";
            this.textboxBigBlind.Size = new System.Drawing.Size(75, 20);
            this.textboxBigBlind.TabIndex = 19;
            this.textboxBigBlind.Text = "500";
            // 
            // labelBot5Status
            // 
            this.labelBot5Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBot5Status.Location = new System.Drawing.Point(1012, 579);
            this.labelBot5Status.Name = "labelBot5Status";
            this.labelBot5Status.Size = new System.Drawing.Size(125, 32);
            this.labelBot5Status.TabIndex = 26;
            // 
            // labelBot4Status
            // 
            this.labelBot4Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBot4Status.Location = new System.Drawing.Point(970, 107);
            this.labelBot4Status.Name = "labelBot4Status";
            this.labelBot4Status.Size = new System.Drawing.Size(125, 32);
            this.labelBot4Status.TabIndex = 27;
            // 
            // labelBot3Status
            // 
            this.labelBot3Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBot3Status.Location = new System.Drawing.Point(786, 107);
            this.labelBot3Status.Name = "labelBot3Status";
            this.labelBot3Status.Size = new System.Drawing.Size(125, 32);
            this.labelBot3Status.TabIndex = 28;
            // 
            // labelBot1Status
            // 
            this.labelBot1Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBot1Status.Location = new System.Drawing.Point(181, 579);
            this.labelBot1Status.Name = "labelBot1Status";
            this.labelBot1Status.Size = new System.Drawing.Size(125, 32);
            this.labelBot1Status.TabIndex = 29;
            // 
            // labelPlayerStatus
            // 
            this.labelPlayerStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPlayerStatus.Location = new System.Drawing.Point(755, 579);
            this.labelPlayerStatus.Name = "labelPlayerStatus";
            this.labelPlayerStatus.Size = new System.Drawing.Size(125, 32);
            this.labelPlayerStatus.TabIndex = 30;
            // 
            // labelBot2Status
            // 
            this.labelBot2Status.Location = new System.Drawing.Point(276, 107);
            this.labelBot2Status.Name = "labelBot2Status";
            this.labelBot2Status.Size = new System.Drawing.Size(125, 32);
            this.labelBot2Status.TabIndex = 31;
            // 
            // labelPot
            // 
            this.labelPot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPot.Location = new System.Drawing.Point(654, 188);
            this.labelPot.Name = "labelPot";
            this.labelPot.Size = new System.Drawing.Size(31, 21);
            this.labelPot.TabIndex = 0;
            this.labelPot.Text = "Pot";
            // 
            // textboxRaise
            // 
            this.textboxRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textboxRaise.Location = new System.Drawing.Point(965, 703);
            this.textboxRaise.Name = "textboxRaise";
            this.textboxRaise.Size = new System.Drawing.Size(108, 20);
            this.textboxRaise.TabIndex = 0;
            // 
            // PokerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.textboxRaise);
            this.Controls.Add(this.labelPot);
            this.Controls.Add(this.labelBot2Status);
            this.Controls.Add(this.labelPlayerStatus);
            this.Controls.Add(this.labelBot1Status);
            this.Controls.Add(this.labelBot3Status);
            this.Controls.Add(this.labelBot4Status);
            this.Controls.Add(this.labelBot5Status);
            this.Controls.Add(this.textboxBigBlind);
            this.Controls.Add(this.buttonSmallBlind);
            this.Controls.Add(this.textboxSmallBlind);
            this.Controls.Add(this.buttonBigBlind);
            this.Controls.Add(this.buttonBlinds);
            this.Controls.Add(this.textboxPot);
            this.Controls.Add(this.textboxBot1Chips);
            this.Controls.Add(this.textboxBot2Chips);
            this.Controls.Add(this.textboxBot3Chips);
            this.Controls.Add(this.textboxBot4Chips);
            this.Controls.Add(this.textboxBot5Chips);
            this.Controls.Add(this.textboxAddChips);
            this.Controls.Add(this.buttonAddChips);
            this.Controls.Add(this.textboxPlayerChips);
            this.Controls.Add(this.progressbarTimer);
            this.Controls.Add(this.buttonRaise);
            this.Controls.Add(this.buttonCall);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonFold);
            this.DoubleBuffered = true;
            this.Name = "PokerTable";
            this.Text = "GLS Texas Poker";
            this.Load += new System.EventHandler(this.PokerTable_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFold;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.Button buttonRaise;
        private System.Windows.Forms.ProgressBar progressbarTimer;
        private System.Windows.Forms.TextBox textboxPlayerChips;
        private System.Windows.Forms.Button buttonAddChips;
        private System.Windows.Forms.TextBox textboxAddChips;
        private System.Windows.Forms.TextBox textboxBot5Chips;
        private System.Windows.Forms.TextBox textboxBot4Chips;
        private System.Windows.Forms.TextBox textboxBot3Chips;
        private System.Windows.Forms.TextBox textboxBot2Chips;
        private System.Windows.Forms.TextBox textboxBot1Chips;
        private System.Windows.Forms.TextBox textboxPot;
        private System.Windows.Forms.Button buttonBlinds;
        private System.Windows.Forms.Button buttonBigBlind;
        private System.Windows.Forms.TextBox textboxSmallBlind;
        private System.Windows.Forms.Button buttonSmallBlind;
        private System.Windows.Forms.TextBox textboxBigBlind;
        private System.Windows.Forms.Label labelBot5Status;
        private System.Windows.Forms.Label labelBot4Status;
        private System.Windows.Forms.Label labelBot3Status;
        private System.Windows.Forms.Label labelBot1Status;
        private System.Windows.Forms.Label labelPlayerStatus;
        private System.Windows.Forms.Label labelBot2Status;
        private System.Windows.Forms.Label labelPot;
        private System.Windows.Forms.TextBox textboxRaise;



    }
}

