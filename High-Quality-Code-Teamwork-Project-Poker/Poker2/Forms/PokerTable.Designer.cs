namespace Poker2.Forms
{
    using System.Windows.Forms;

    using Poker2.Core.Interfaces;
    using Poker2.Resources.Assets;

    public partial class PokerTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Button ButtonFold { get; set; }

        public Button ButtonCheck { get; set; }

        public Button ButtonCall { get; set; }

        public Button ButtonRaise { get; set; }

        public ProgressBar ProgressBarTimer { get; set; }

        public TextBox TextBoxPlayerChips { get; set; }

        public Button ButtonAddChips { get; set; }

        public TextBox TextBoxAddChips { get; set; }

        public TextBox TextBoxBot5Chips { get; set; }

        public TextBox TextBoxBot4Chips { get; set; }

        public TextBox TextBoxBot3Chips { get; set; }

        public TextBox TextBoxBot2Chips { get; set; }

        public TextBox TextBoxBot1Chips { get; set; }

        public TextBox TextBoxPot { get; set; }

        public Button ButtonBlinds { get; set; }

        public Button ButtonBigBlind { get; set; }

        public TextBox TextBoxSmallBlind { get; set; }

        public Button ButtonSmallBlind { get; set; }

        public TextBox TextBoxBigBlind { get; set; }

        public Label LabelBot5Status { get; set; }

        public Label LabelBot4Status { get; set; }

        public Label LabelBot3Status { get; set; }

        public Label LabelBot2Status { get; set; }

        public Label LabelBot1Status { get; set; }

        public Label LabelPlayerStatus { get; set; }

        public Label LabelPot { get; set; }

        public TextBox TextBoxRaise { get; set; }

        public PictureBox PictureBox1 { get; set; }

        public PictureBox PictureBox2 { get; set; }

        public PictureBox PictureBox3 { get; set; }

        public PictureBox PictureBox4 { get; set; }

        public PictureBox PictureBox5 { get; set; }

        public PictureBox PictureBox6 { get; set; }

        public PictureBox PictureBox7 { get; set; }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokerTable));
            this.ButtonFold = new Button();
            this.ButtonCheck = new Button();
            this.ButtonCall = new Button();
            this.ButtonRaise = new Button();
            this.ProgressBarTimer = new ProgressBar();
            this.TextBoxPlayerChips = new TextBox();
            this.ButtonAddChips = new Button();
            this.TextBoxAddChips = new TextBox();
            this.TextBoxBot5Chips = new TextBox();
            this.TextBoxBot4Chips = new TextBox();
            this.TextBoxBot3Chips = new TextBox();
            this.TextBoxBot2Chips = new TextBox();
            this.TextBoxBot1Chips = new TextBox();
            this.TextBoxPot = new TextBox();
            this.ButtonBlinds = new Button();
            this.ButtonBigBlind = new Button();
            this.TextBoxSmallBlind = new TextBox();
            this.ButtonSmallBlind = new Button();
            this.TextBoxBigBlind = new TextBox();
            this.LabelBot5Status = new Label();
            this.LabelBot4Status = new Label();
            this.LabelBot3Status = new Label();
            this.LabelBot1Status = new Label();
            this.LabelPlayerStatus = new Label();
            this.LabelBot2Status = new Label();
            this.LabelPot = new Label();
            this.TextBoxRaise = new TextBox();
            this.PictureBox1 = new PictureBox();
            this.PictureBox2 = new PictureBox();
            this.PictureBox3 = new PictureBox();
            this.PictureBox4 = new PictureBox();
            this.PictureBox5 = new PictureBox();
            this.PictureBox6 = new PictureBox();
            this.PictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFold
            // 
            this.ButtonFold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonFold.Location = new System.Drawing.Point(335, 660);
            this.ButtonFold.Name = "buttonFold";
            this.ButtonFold.Size = new System.Drawing.Size(130, 62);
            this.ButtonFold.TabIndex = 0;
            this.ButtonFold.Text = "Fold";
            this.ButtonFold.UseVisualStyleBackColor = true;
            this.ButtonFold.Click += new System.EventHandler(this.FoldClick);
            // 
            // buttonCheck
            // 
            this.ButtonCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCheck.Location = new System.Drawing.Point(494, 660);
            this.ButtonCheck.Name = "buttonCheck";
            this.ButtonCheck.Size = new System.Drawing.Size(134, 62);
            this.ButtonCheck.TabIndex = 2;
            this.ButtonCheck.Text = "Check";
            this.ButtonCheck.UseVisualStyleBackColor = true;
            this.ButtonCheck.Click += new System.EventHandler(this.CheckClick);
            // 
            // buttonCall
            // 
            this.ButtonCall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCall.Location = new System.Drawing.Point(667, 661);
            this.ButtonCall.Name = "buttonCall";
            this.ButtonCall.Size = new System.Drawing.Size(126, 62);
            this.ButtonCall.TabIndex = 3;
            this.ButtonCall.Text = "Call";
            this.ButtonCall.UseVisualStyleBackColor = true;
            this.ButtonCall.Click += new System.EventHandler(this.CallClick);
            // 
            // buttonRaise
            // 
            this.ButtonRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRaise.Location = new System.Drawing.Point(835, 661);
            this.ButtonRaise.Name = "buttonRaise";
            this.ButtonRaise.Size = new System.Drawing.Size(124, 62);
            this.ButtonRaise.TabIndex = 4;
            this.ButtonRaise.Text = "Raise";
            this.ButtonRaise.UseVisualStyleBackColor = true;
            this.ButtonRaise.Click += new System.EventHandler(this.RaiseClick);
            // 
            // progressbarTimer
            // 
            this.ProgressBarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBarTimer.Location = new System.Drawing.Point(335, 631);
            this.ProgressBarTimer.Maximum = 1000;
            this.ProgressBarTimer.Name = "progressbarTimer";
            this.ProgressBarTimer.Size = new System.Drawing.Size(667, 23);
            this.ProgressBarTimer.TabIndex = 5;
            this.ProgressBarTimer.Value = 1000;
            // 
            // textboxPlayerChips
            // 
            this.TextBoxPlayerChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxPlayerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxPlayerChips.Location = new System.Drawing.Point(755, 553);
            this.TextBoxPlayerChips.Name = "textboxPlayerChips";
            this.TextBoxPlayerChips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxPlayerChips.TabIndex = 6;
            this.TextBoxPlayerChips.Text = "Chips : 0";
            // 
            // buttonAddChips
            // 
            this.ButtonAddChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddChips.Location = new System.Drawing.Point(12, 697);
            this.ButtonAddChips.Name = "buttonAddChips";
            this.ButtonAddChips.Size = new System.Drawing.Size(75, 25);
            this.ButtonAddChips.TabIndex = 7;
            this.ButtonAddChips.Text = "AddChips";
            this.ButtonAddChips.UseVisualStyleBackColor = true;
            this.ButtonAddChips.Click += new System.EventHandler(this.AddClick);
            // 
            // textboxAddChips
            // 
            this.TextBoxAddChips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxAddChips.Location = new System.Drawing.Point(93, 700);
            this.TextBoxAddChips.Name = "textboxAddChips";
            this.TextBoxAddChips.Size = new System.Drawing.Size(125, 20);
            this.TextBoxAddChips.TabIndex = 8;
            // 
            // textboxBot5Chips
            // 
            this.TextBoxBot5Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBot5Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxBot5Chips.Location = new System.Drawing.Point(1012, 553);
            this.TextBoxBot5Chips.Name = "textboxBot5Chips";
            this.TextBoxBot5Chips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxBot5Chips.TabIndex = 9;
            this.TextBoxBot5Chips.Text = "Chips : 0";
            // 
            // textboxBot4Chips
            // 
            this.TextBoxBot4Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBot4Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxBot4Chips.Location = new System.Drawing.Point(970, 81);
            this.TextBoxBot4Chips.Name = "textboxBot4Chips";
            this.TextBoxBot4Chips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxBot4Chips.TabIndex = 10;
            this.TextBoxBot4Chips.Text = "Chips : 0";
            // 
            // textboxBot3Chips
            // 
            this.TextBoxBot3Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBot3Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxBot3Chips.Location = new System.Drawing.Point(786, 81);
            this.TextBoxBot3Chips.Name = "textboxBot3Chips";
            this.TextBoxBot3Chips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxBot3Chips.TabIndex = 11;
            this.TextBoxBot3Chips.Text = "Chips : 0";
            // 
            // textboxBot2Chips
            // 
            this.TextBoxBot2Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxBot2Chips.Location = new System.Drawing.Point(276, 81);
            this.TextBoxBot2Chips.Name = "textboxBot2Chips";
            this.TextBoxBot2Chips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxBot2Chips.TabIndex = 12;
            this.TextBoxBot2Chips.Text = "Chips : 0";
            // 
            // textboxBot1Chips
            // 
            this.TextBoxBot1Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxBot1Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxBot1Chips.Location = new System.Drawing.Point(181, 553);
            this.TextBoxBot1Chips.Name = "textboxBot1Chips";
            this.TextBoxBot1Chips.Size = new System.Drawing.Size(125, 23);
            this.TextBoxBot1Chips.TabIndex = 13;
            this.TextBoxBot1Chips.Text = "Chips : 0";
            // 
            // textboxPot
            // 
            this.TextBoxPot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxPot.Location = new System.Drawing.Point(606, 212);
            this.TextBoxPot.Name = "textboxPot";
            this.TextBoxPot.Size = new System.Drawing.Size(125, 23);
            this.TextBoxPot.TabIndex = 14;
            this.TextBoxPot.Text = "0";
            // 
            // buttonBlinds
            // 
            this.ButtonBlinds.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonBlinds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonBlinds.Location = new System.Drawing.Point(1, 198);
            this.ButtonBlinds.Name = "buttonBlinds";
            this.ButtonBlinds.Size = new System.Drawing.Size(86, 50);
            this.ButtonBlinds.TabIndex = 15;
            this.ButtonBlinds.Text = "BigBlind/ SmallBlind";
            this.ButtonBlinds.UseVisualStyleBackColor = false;
            this.ButtonBlinds.Click += new System.EventHandler(this.OptionsClick);
            // 
            // buttonBigBlind
            // 
            this.ButtonBigBlind.Location = new System.Drawing.Point(1, 318);
            this.ButtonBigBlind.Name = "buttonBigBlind";
            this.ButtonBigBlind.Size = new System.Drawing.Size(75, 23);
            this.ButtonBigBlind.TabIndex = 16;
            this.ButtonBigBlind.Text = "Big Blind";
            this.ButtonBigBlind.UseVisualStyleBackColor = true;
            this.ButtonBigBlind.Click += new System.EventHandler(this.BigBlingClick);
            // 
            // textboxSmallBlind
            // 
            this.TextBoxSmallBlind.Location = new System.Drawing.Point(1, 292);
            this.TextBoxSmallBlind.Name = "textboxSmallBlind";
            this.TextBoxSmallBlind.Size = new System.Drawing.Size(75, 20);
            this.TextBoxSmallBlind.TabIndex = 17;
            this.TextBoxSmallBlind.Text = "250";
            // 
            // buttonSmallBlind
            // 
            this.ButtonSmallBlind.Location = new System.Drawing.Point(1, 263);
            this.ButtonSmallBlind.Name = "buttonSmallBlind";
            this.ButtonSmallBlind.Size = new System.Drawing.Size(75, 23);
            this.ButtonSmallBlind.TabIndex = 18;
            this.ButtonSmallBlind.Text = "Small Blind";
            this.ButtonSmallBlind.UseVisualStyleBackColor = true;
            this.ButtonSmallBlind.Click += new System.EventHandler(this.SmallBlindClick);
            // 
            // textboxBigBlind
            // 
            this.TextBoxBigBlind.Location = new System.Drawing.Point(1, 347);
            this.TextBoxBigBlind.Name = "textboxBigBlind";
            this.TextBoxBigBlind.Size = new System.Drawing.Size(75, 20);
            this.TextBoxBigBlind.TabIndex = 19;
            this.TextBoxBigBlind.Text = "500";
            // 
            // labelBot5Status
            // 
            this.LabelBot5Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBot5Status.Location = new System.Drawing.Point(1012, 579);
            this.LabelBot5Status.Name = "labelBot5Status";
            this.LabelBot5Status.Size = new System.Drawing.Size(125, 32);
            this.LabelBot5Status.TabIndex = 26;
            // 
            // labelBot4Status
            // 
            this.LabelBot4Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBot4Status.Location = new System.Drawing.Point(970, 107);
            this.LabelBot4Status.Name = "labelBot4Status";
            this.LabelBot4Status.Size = new System.Drawing.Size(125, 32);
            this.LabelBot4Status.TabIndex = 27;
            // 
            // labelBot3Status
            // 
            this.LabelBot3Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBot3Status.Location = new System.Drawing.Point(786, 107);
            this.LabelBot3Status.Name = "labelBot3Status";
            this.LabelBot3Status.Size = new System.Drawing.Size(125, 32);
            this.LabelBot3Status.TabIndex = 28;
            // 
            // labelBot1Status
            // 
            this.LabelBot1Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelBot1Status.Location = new System.Drawing.Point(181, 579);
            this.LabelBot1Status.Name = "labelBot1Status";
            this.LabelBot1Status.Size = new System.Drawing.Size(125, 32);
            this.LabelBot1Status.TabIndex = 29;
            // 
            // labelPlayerStatus
            // 
            this.LabelPlayerStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LabelPlayerStatus.Location = new System.Drawing.Point(755, 579);
            this.LabelPlayerStatus.Name = "labelPlayerStatus";
            this.LabelPlayerStatus.Size = new System.Drawing.Size(125, 32);
            this.LabelPlayerStatus.TabIndex = 30;
            // 
            // labelBot2Status
            // 
            this.LabelBot2Status.Location = new System.Drawing.Point(276, 107);
            this.LabelBot2Status.Name = "labelBot2Status";
            this.LabelBot2Status.Size = new System.Drawing.Size(125, 32);
            this.LabelBot2Status.TabIndex = 31;
            // 
            // labelPot
            // 
            this.LabelPot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPot.Location = new System.Drawing.Point(654, 188);
            this.LabelPot.Name = "labelPot";
            this.LabelPot.Size = new System.Drawing.Size(31, 21);
            this.LabelPot.TabIndex = 0;
            this.LabelPot.Text = "Pot";
            // 
            // textboxRaise
            // 
            this.TextBoxRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TextBoxRaise.Location = new System.Drawing.Point(965, 703);
            this.TextBoxRaise.Name = "textboxRaise";
            this.TextBoxRaise.Size = new System.Drawing.Size(108, 20);
            this.TextBoxRaise.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(256, 497);
            this.PictureBox1.Name = "pictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(50, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 32;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Tag = "2";
            // 
            // pictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(351, 142);
            this.PictureBox2.Name = "pictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(50, 50);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 33;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Tag = "3";
            // 
            // pictureBox3
            // 
            this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.PictureBox3.Location = new System.Drawing.Point(786, 142);
            this.PictureBox3.Name = "pictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(50, 50);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox3.TabIndex = 34;
            this.PictureBox3.TabStop = false;
            this.PictureBox3.Tag = "4";
            // 
            // pictureBox4
            // 
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.PictureBox4.Location = new System.Drawing.Point(970, 142);
            this.PictureBox4.Name = "pictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(50, 50);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox4.TabIndex = 35;
            this.PictureBox4.TabStop = false;
            this.PictureBox4.Tag = "5";
            // 
            // pictureBox5
            // 
            this.PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.PictureBox5.Location = new System.Drawing.Point(1012, 497);
            this.PictureBox5.Name = "pictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(50, 50);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox5.TabIndex = 36;
            this.PictureBox5.TabStop = false;
            this.PictureBox5.Tag = "6";
            // 
            // pictureBox6
            // 
            this.PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.PictureBox6.Location = new System.Drawing.Point(755, 497);
            this.PictureBox6.Name = "pictureBox6";
            this.PictureBox6.Size = new System.Drawing.Size(50, 50);
            this.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox6.TabIndex = 37;
            this.PictureBox6.TabStop = false;
            this.PictureBox6.Tag = "1";
            // 
            // pictureBox7
            // 
            this.PictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.PictureBox7.Location = new System.Drawing.Point(550, 188);
            this.PictureBox7.Name = "pictureBox7";
            this.PictureBox7.Size = new System.Drawing.Size(50, 50);
            this.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox7.TabIndex = 38;
            this.PictureBox7.TabStop = false;
            this.PictureBox7.Tag = "1";
            // 
            // PokerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Poker2.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.PictureBox7);
            this.Controls.Add(this.PictureBox6);
            this.Controls.Add(this.PictureBox5);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.TextBoxRaise);
            this.Controls.Add(this.LabelPot);
            this.Controls.Add(this.LabelBot2Status);
            this.Controls.Add(this.LabelPlayerStatus);
            this.Controls.Add(this.LabelBot1Status);
            this.Controls.Add(this.LabelBot3Status);
            this.Controls.Add(this.LabelBot4Status);
            this.Controls.Add(this.LabelBot5Status);
            this.Controls.Add(this.TextBoxBigBlind);
            this.Controls.Add(this.ButtonSmallBlind);
            this.Controls.Add(this.TextBoxSmallBlind);
            this.Controls.Add(this.ButtonBigBlind);
            this.Controls.Add(this.ButtonBlinds);
            this.Controls.Add(this.TextBoxPot);
            this.Controls.Add(this.TextBoxBot1Chips);
            this.Controls.Add(this.TextBoxBot2Chips);
            this.Controls.Add(this.TextBoxBot3Chips);
            this.Controls.Add(this.TextBoxBot4Chips);
            this.Controls.Add(this.TextBoxBot5Chips);
            this.Controls.Add(this.TextBoxAddChips);
            this.Controls.Add(this.ButtonAddChips);
            this.Controls.Add(this.TextBoxPlayerChips);
            this.Controls.Add(this.ProgressBarTimer);
            this.Controls.Add(this.ButtonRaise);
            this.Controls.Add(this.ButtonCall);
            this.Controls.Add(this.ButtonCheck);
            this.Controls.Add(this.ButtonFold);
            this.DoubleBuffered = true;
            this.Name = "PokerTable";
            this.Text = "GLS Texas Poker";
            this.Load += new System.EventHandler(this.PokerTable_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}