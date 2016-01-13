//-----------------------------------------------------------------------
// <copyright file="PokerTable.cs" company="MyCompanyName">
//     Copyright (c) MyCompanyName. All rights reserved.
// </copyright>
// <summary>
// This file contains PokerTable class.
// </summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// PokerTable Form Class
    /// </summary>
    public partial class PokerTable : Form
    {
        /// <summary>
        /// The default amount of chips for all players.
        /// </summary>        
        public const int DefaultBankroll = 10000;
        
        /// <summary>
        /// This is the first rounds of community cards rounds(table cards).
        /// First three community cards are dealt.
        /// </summary>        
        public const int Flop = 1;
        
        /// <summary>
        /// This is the second round of community cards rounds(table cards).
        /// Fourth community card is dealt.
        /// </summary>        
        public const int Turn = 2;
        
        /// <summary>
        ///This is the third round of community cards rounds(table cards).
        /// Fifth community card is dealt.
        /// </summary>        
        public const int River = 3;
        
        /// <summary>
        /// This is the fourth round of community cards rounds(table cards).
        /// No cards are dealt.
        /// </summary>        
        public const int End = 4;
        
        /// <summary>
        /// The number of players that start a poker session.
        /// </summary>        
        public const int MaxPlayers = 6;
        
        /// <summary>
        /// The height of a card control in pixels.
        /// </summary>        
        public const int CardImageHeight = 130;
        
        /// <summary>
        /// The width of a card control in pixels.
        /// </summary>        
        public const int CardImageWidth = 80;

        /// <summary>
        /// The default upper left x coordinate for the player's panel.
        /// </summary>        
        public const int PlayerPanelDefaultHorizontalCoordinate = 580;
        
        /// <summary>
        /// The default upper left y coordinate for the player's panel.
        /// </summary>        
        public const int PlayerPanelDefaultVerticalCoordinate = 480;
        
        /// <summary>
        /// The default upper left x coordinate for bot1's panel.
        /// </summary>        
        public const int Bot1PanelDefaultHorizontalCoordinate = 15;
        
        /// <summary>
        /// The default upper left y coordinate for bot1's panel.
        /// </summary>        
        public const int Bot1PanelDefaultVerticalCoordinate = 420;
        
        /// <summary>
        /// The default upper left x coordinate for bot2's panel.
        /// </summary>        
        public const int Bot2PanelDefaultHorizontalCoordinate = 75;
        
        /// <summary>
        /// The default upper left y coordinate for bot2's panel.
        /// </summary>        
        public const int Bot2PanelDefaultVerticalCoordinate = 65;
        
        /// <summary>
        /// The default upper left x coordinate for bot3's panel.
        /// </summary>        
        public const int Bot3PanelDefaultHorizontalCoordinate = 590;
        
        /// <summary>
        /// The default upper left y coordinate for bot3's panel.
        /// </summary>        
        public const int Bot3PanelDefaultVerticalCoordinate = 25;
        
        /// <summary>
        /// The default upper left x coordinate for bot4's panel.
        /// </summary>        
        public const int Bot4PanelDefaultHorizontalCoordinate = 1115;
        
        /// <summary>
        /// The default upper left y coordinate for bot4's panel.
        /// </summary>        
        public const int Bot4PanelDefaultVerticalCoordinate = 65;
        
        /// <summary>
        /// The default upper left x coordinate for bot5's panel.
        /// </summary>        
        public const int Bot5PanelDefaultHorizontalCoordinate = 1160;
        
        /// <summary>
        /// The default upper left x coordinate for bot5's panel.
        /// </summary>        
        public const int Bot5PanelDefaultVerticalCoordinate = 420;

        /// <summary>
        /// The number of cards that are dealt each turn
        /// including community cards.
        /// </summary>        
        public const int MaximumCardsToBeDealt = 17;
        
        /// <summary>
        /// The number of cards in a deck.
        /// </summary>        
        public const int CardsInADeck = 52;

        /// <summary>
        /// The default value of the Big Blind.
        /// </summary>        
        public const int BigBlindDefaultValue = 500;

        /// <summary>
        /// The panel control for the human player.
        /// </summary>        
        public Panel playerPanel = new Panel();
        
        /// <summary>
        /// The panel control for bot1.
        /// </summary>        
        public Panel bot1Panel = new Panel();
        
        /// <summary>
        /// The panel control for bot2.
        /// </summary>        
        public Panel bot2Panel = new Panel();
        
        /// <summary>
        /// The panel control for bot3.
        /// </summary>        
        public Panel bot3Panel = new Panel();
        
        /// <summary>
        /// The panel control for bot4.
        /// </summary>        
        public Panel bot4Panel = new Panel();
        
        /// <summary>
        /// The panel control for bot5.
        /// </summary>        
        public Panel bot5Panel = new Panel();

        /// <summary>
        /// The current call amount.
        /// </summary>        
        public int callAmount;////call
        
        /// <summary>
        /// The number of maximum folded players.
        /// </summary>        
        public int foldedPlayers = MaxPlayers - 1;

        /// <summary>
        /// The current amount of human player chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int playerChips = DefaultBankroll;//10000
        
        /// <summary>
        /// The current amount of bot1 chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int bot1Chips = DefaultBankroll;
        
        /// <summary>
        /// The current amount of bot2 chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int bot2Chips = DefaultBankroll;
        
        /// <summary>
        /// The current amount of bot3 chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int bot3Chips = DefaultBankroll;
        
        /// <summary>
        /// The current amount of bot4 chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int bot4Chips = DefaultBankroll;
        
        /// <summary>
        /// The current amount of bot5 chips.
        /// At the beginning of each poker session is 
        /// initialized with the default bankroll.
        /// </summary>        
        public int bot5Chips = DefaultBankroll;

        /// <summary>
        /// This variable is used in The FullHouse rule method.
        /// </summary>        
        public double secondaryFactor;//type
        
        /// <summary>
        /// The current round of community cards rounds.
        /// </summary>        
        public double communityCardsRound;

        /// <summary>
        /// Current human player's hand rank factor.
        /// </summary>        
        public double playerHandRankFactor;//playerPower
        
        /// <summary>
        /// Current bot1's hand rank factor.
        /// </summary>        
        public double bot1HandRankFactor;
        
        /// <summary>
        /// Current bot2's hand rank factor.
        /// </summary>        
        public double bot2HandRankFactor;
        
        /// <summary>
        /// Current bot3's hand rank factor.
        /// </summary>        
        public double bot3HandRankFactor;
        
        /// <summary>
        /// Current bot4's hand rank factor.
        /// </summary>        
        public double bot4HandRankFactor;
        
        /// <summary>
        /// Current bot5's hand rank factor.
        /// </summary>        
        public double bot5HandRankFactor;

        /// <summary>
        /// Current raise amount.
        /// </summary>        
        public double raiseAmount; // raiseAmount Amount

        /// <summary>
        /// Current human player's hand category factor.
        /// </summary>        
        public double playerHandCategoryFactor = -1;////playerType
        
        /// <summary>
        /// Current bot1's hand category factor.
        /// </summary>        
        public double bot1HandCategoryFactor = -1;
        
        /// <summary>
        /// Current bot2's hand category factor.
        /// </summary>        
        public double bot2HandCategoryFactor = -1;
        
        /// <summary>
        /// Current bot3's hand category factor.
        /// </summary>        
        public double bot3HandCategoryFactor = -1;
        
        /// <summary>
        /// Current bot4's hand category factor.
        /// </summary>        
        public double bot4HandCategoryFactor = -1;
        
        /// <summary>
        /// Current bot5's hand category factor.
        /// </summary>        
        public double bot5HandCategoryFactor = -1;

        /// <summary>
        /// Field that indicates if it's human player's turn.
        /// </summary>        
        public bool isPlayerTurn = true;
        
        /// <summary>
        /// Field that indicates if it's bot1's turn.
        /// </summary>        
        public bool isBot1Turn = false;
        
        /// <summary>
        /// Field that indicates if it's bot2's turn.
        /// </summary>        
        public bool isBot2Turn = false;
        
        /// <summary>
        /// Field that indicates if it's bot3's turn.
        /// </summary>        
        public bool isBot3Turn = false;
        
        /// <summary>
        /// Field that indicates if it's bot4's turn.
        /// </summary>        
        public bool isBot4Turn = false;
        
        /// <summary>
        /// Field that indicates if it's bot5's turn.
        /// </summary>        
        public bool isBot5Turn = false;

        /// <summary>
        /// Field that indicates if human player has folded or is all in.
        /// </summary>        
        public bool playerFoldOrAllIn = false;//pFturn
        
        /// <summary>
        /// Field that indicates if bot1 has folded or is all in.
        /// </summary>        
        public bool bot1FoldOrAllIn = false;//bot1Fturn
        
        /// <summary>
        /// Field that indicates if bot2 has folded or is all in.
        /// </summary>        
        public bool bot2FoldOrAllIn = false;
        
        /// <summary>
        /// Field that indicates if bot3 has folded or is all in.
        /// </summary>        
        public bool bot3FoldOrAllIn = false;
        
        /// <summary>
        /// Field that indicates if bot4 has folded or is all in.
        /// </summary>        
        public bool bot4FoldOrAllIn = false;
        
        /// <summary>
        /// Field that indicates if bot5 has folded or is all in.
        /// </summary>        
        public bool bot5FoldOrAllIn = false;

        /// <summary>
        /// Field that indicates if human player has folded.
        /// </summary>        
        public bool isPlayerFolded = false;
        
        /// <summary>
        /// Field that indicates if bot1 has folded.
        /// </summary>        
        public bool isBot1Folded = false;
        
        /// <summary>
        /// Field that indicates if bot2 has folded.
        /// </summary>        
        public bool isBot2Folded = false;
        
        /// <summary>
        /// Field that indicates if bot3 has folded.
        /// </summary>        
        public bool isBot3Folded = false;
        
        /// <summary>
        /// Field that indicates if bot4 has folded.
        /// </summary>        
        public bool isBot4Folded = false;
        
        /// <summary>
        /// Field that indicates if bot5 has folded.
        /// </summary>        
        public bool isBot5Folded = false;

        /// <summary>
        /// Field that indicates if current player is added to the list 
        /// of players who are all in.
        /// </summary>        
        public bool addedToAllInPlayers = false;
        
        /// <summary>
        /// The changed field
        /// </summary>        
        public bool changed = false;

        /// <summary>
        /// Human player's call amount.
        /// </summary>        
        public int playerCall;
        
        /// <summary>
        /// Bot1's call amount.
        /// </summary>        
        public int bot1Call;
        
        /// <summary>
        /// Bot2's call amount.
        /// </summary>        
        public int bot2Call;
        
        /// <summary>
        /// Bot3's call amount.
        /// </summary>        
        public int bot3Call;
        
        /// <summary>
        /// Bot4's call amount.
        /// </summary>        
        public int bot4Call;
        
        /// <summary>
        /// Bot5's call amount.
        /// </summary>        
        public int bot5Call;

        /// <summary>
        /// Human player's raise amount.
        /// </summary>        
        public int playerRaise;
        
        /// <summary>
        /// Bot1's raise amount.
        /// </summary>        
        public int bot1Raise;
        
        /// <summary>
        /// Bot2's raise amount.
        /// </summary>        
        public int bot2Raise;
        
        /// <summary>
        /// Bot3's raise amount.
        /// </summary>        
        public int bot3Raise;
        
        /// <summary>
        /// Bot4's raise amount.
        /// </summary>        
        public int bot4Raise;
        
        /// <summary>
        /// Bot5's raise amount.
        /// </summary>        
        public int bot5Raise;

        /// <summary>
        /// Current height of the application window
        /// </summary>        
        public int windowHeight;//height 
        
        /// <summary>
        /// Current width of the application window
        /// </summary>        
        public int windowWidth;//width

        /// <summary>
        /// The count of the winners in the current game.
        /// </summary>        
        public int winnersCount = 0;//winners
        
        /// <summary>
        /// The count of the players left in the game.
        /// </summary>        
        public int maxLeft = MaxPlayers;//6
        
        /// <summary>
        /// The last field.
        /// </summary>        
        public int last = 123;
        
        /// <summary>
        /// The number of the turn last raise is made.
        /// </summary>        
        public int raisedTurn = 1;

        /// <summary>
        /// Register of all players that shows who has folded game.
        /// </summary>        
        public List<bool?> foldRegister = new List<bool?>();//bools
        
        /// <summary>
        /// List of all players hands.
        /// </summary>        
        public List<PokerHand> competingHands = new List<PokerHand>();//win
        
        /// <summary>
        /// List of the winners in current game.
        /// </summary>        
        public List<string> listOfWinners = new List<string>();//winners
        
        /// <summary>
        /// List of all players who are all in.
        /// </summary>        
        public List<int> allInPlayers = new List<int>();//ints

        /// <summary>
        /// Field that shows if current game is finished 
        /// and a new game is prepared.
        /// </summary>        
        public bool restart = false;
        
        /// <summary>
        /// Field that indicates if bet is raised.
        /// </summary>        
        public bool isBetRaised = false;//raising

        /// <summary>
        /// The best hand in list of competing hands.
        /// </summary>        
        public PokerHand winningHand;//sorted

        /// <summary>
        /// Locations of card pictures in the source directory.
        /// </summary>        
        public string[] imgCardsLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);

        /// <summary>
        /// Indexes of the dealt cards in the source directory.
        /// </summary>        
        public int[] deckCard = new int[MaximumCardsToBeDealt];//reserve
        
        /// <summary>
        /// The shuffled deck cards.
        /// </summary>        
        public Image[] shuffledDeck = new Image[CardsInADeck];//Deck
        
        /// <summary>
        /// The controls for the dealt shuffled deck cards.
        /// </summary>        
        public PictureBox[] cardToBeDealt = new PictureBox[MaximumCardsToBeDealt];//Holder
        
        /// <summary>
        /// The timer for the human player's turn.
        /// </summary>        
        public Timer timer = new Timer();
        
        /// <summary>
        /// The updates timer.
        /// </summary>        
        public Timer updates = new Timer();//Updates

        /// <summary>
        /// Countdown in seconds for the player's timer.
        /// </summary>        
        public int playerTime = 60;
        
        /// <summary>
        /// The i field
        /// </summary>        
        public int i;
        
        /// <summary>
        /// Big Blind amount.
        /// </summary>        
        public int bigBlind = BigBlindDefaultValue;//callChipsCount
        
        /// <summary>
        /// Small blind amount.
        /// </summary>        
        public int smallBlind = BigBlindDefaultValue / 2;//sb
        
        /// <summary>
        /// The up field.
        /// </summary>        
        public int up = 10000000;
        
        /// <summary>
        /// Count of the turns since last raise.
        /// </summary>        
        public int turnCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokerTable" /> class.
        /// </summary>        
        public PokerTable()
        {
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

        /// <summary>
        /// Formula which Calculates a number to
        /// be used by the bot for comparison
        /// when the bot chooses if he should call,raise, or fold.
        /// This formula is used with parameters:bot chips 
        /// and special number (n or n1).
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="n">The n parameter</param>
        /// <returns>Double number which is used for compare</returns>        
        public static double BotChoiceFormula(int botChips, int n)
        {
            double a = Math.Round((botChips / n) / 100d, 0) * 100;
            return a;
        }

        /// <summary>
        /// ShuffleCards cards.
        /// Initializes human player's controls.
        /// Deals cards to all remaining players and also the community cards.
        /// Enables card controls and panel controls for the remaining players.
        /// </summary>
        /// <returns>Does not return anything</returns>        
        public async Task ShuffleCards()
        {
            this.foldRegister.Add(this.playerFoldOrAllIn);
            this.foldRegister.Add(this.bot1FoldOrAllIn);
            this.foldRegister.Add(this.bot2FoldOrAllIn);
            this.foldRegister.Add(this.bot3FoldOrAllIn);
            this.foldRegister.Add(this.bot4FoldOrAllIn);
            this.foldRegister.Add(this.bot5FoldOrAllIn);

            this.buttonCall.Enabled = false;
            this.buttonRaise.Enabled = false;
            this.buttonFold.Enabled = false;
            this.buttonCheck.Enabled = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //// <summary>
            //// Boolean value that is used to indicate if current player's
            //// card controls should be enabled.
            //// </summary>
            bool check = false;

            //// <summary>
            //// The back image for the face down cards.
            //// </summary>
            Bitmap backImage = new Bitmap("Assets\\Back\\Back.png");

            //// <summary>
            //// The horizontal coordinate of the upper left
            //// point of human player's panel.
            //// </summary>
            int horizontal = PlayerPanelDefaultHorizontalCoordinate;

            //// <summary>
            //// The vertical coordinate of the upper left
            //// point of human player's panel.
            //// </summary>
            int vertical = PlayerPanelDefaultVerticalCoordinate;

            //// <summary>
            //// The shuffle generator.
            //// </summary>
            Random randGenerator = new Random();

            for (int card = this.imgCardsLocation.Length; card > 0; card--)
            {
                int j = randGenerator.Next(card);
                var k = this.imgCardsLocation[j];
                this.imgCardsLocation[j] = this.imgCardsLocation[card - 1];
                this.imgCardsLocation[card - 1] = k;
            }

            //Initialize card controls and players panels 
            //Deal bots who still have chips and the player
            for (i = 0; i < MaximumCardsToBeDealt; i++)
            {
                shuffledDeck[i] = Image.FromFile(this.imgCardsLocation[i]);
                var charsToRemove = new string[] { "Assets\\Cards\\", ".png" };
                foreach (var c in charsToRemove)
                {
                    this.imgCardsLocation[i] = this.imgCardsLocation[i].Replace(c, string.Empty);
                }

                this.deckCard[i] = int.Parse(this.imgCardsLocation[i]) - 1;
                cardToBeDealt[i] = new PictureBox();
                cardToBeDealt[i].SizeMode = PictureBoxSizeMode.StretchImage;
                cardToBeDealt[i].Height = CardImageHeight;
                cardToBeDealt[i].Width = CardImageWidth;
                this.Controls.Add(cardToBeDealt[i]);
                cardToBeDealt[i].Name = "picturebox" + i.ToString();
                await Task.Delay(200);

                //Deal human player
                //Initialize player panel and player card controls
                //Player cards are face up
                if (i < 2)
                {
                    if (cardToBeDealt[0].Tag != null)
                    {
                        cardToBeDealt[1].Tag = this.deckCard[1];
                    }

                    cardToBeDealt[0].Tag = this.deckCard[0];
                    cardToBeDealt[i].Image = shuffledDeck[i];
                    cardToBeDealt[i].Anchor = (AnchorStyles.Bottom);
                    ////cardToBeDealt[i].Dock = DockStyle.Top;
                    cardToBeDealt[i].Location = new Point(horizontal, vertical);
                    horizontal += cardToBeDealt[i].Width;
                    this.Controls.Add(this.playerPanel);
                    this.playerPanel.Location = new Point(cardToBeDealt[0].Left - 10, cardToBeDealt[0].Top - 10);
                    this.playerPanel.BackColor = Color.DarkBlue;
                    this.playerPanel.Height = 150;
                    this.playerPanel.Width = 180;
                    this.playerPanel.Visible = false;
                }

                //If bot1 has chips,receives shuffledDeck[2] i shuffledDeck[3] cards(cards 3 and 4)
                //Also bot1 panel and card controls are initialized
                //Bot1 cards are covered
                if (bot1Chips > 0)
                {
                    foldedPlayers--;
                    if (i >= 2 && i < 4)
                    {
                        if (cardToBeDealt[2].Tag != null)
                        {
                            cardToBeDealt[3].Tag = this.deckCard[3];
                        }

                        cardToBeDealt[2].Tag = this.deckCard[2];
                        if (!check)
                        {
                            horizontal = Bot1PanelDefaultHorizontalCoordinate;
                            vertical = Bot1PanelDefaultVerticalCoordinate;
                        }

                        check = true;
                        cardToBeDealt[i].Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += cardToBeDealt[i].Width;
                        cardToBeDealt[i].Visible = true;
                        this.Controls.Add(this.bot1Panel);
                        this.bot1Panel.Location = new Point(cardToBeDealt[2].Left - 10, cardToBeDealt[2].Top - 10);
                        this.bot1Panel.BackColor = Color.DarkBlue;
                        this.bot1Panel.Height = 150;
                        this.bot1Panel.Width = 180;
                        this.bot1Panel.Visible = false;
                        if (i == 3)
                        {
                            check = false;
                        }
                    }
                }

                //If bot2 has chips,receives shuffledDeck[4] i shuffledDeck[5] cards(cards 5 and 6)
                //Also bot2 panel and card controls are initialized
                //Bot2 cards are covered
                if (bot2Chips > 0)
                {
                    foldedPlayers--;
                    if (i >= 4 && i < 6)
                    {
                        if (cardToBeDealt[4].Tag != null)
                        {
                            cardToBeDealt[5].Tag = this.deckCard[5];
                        }

                        cardToBeDealt[4].Tag = this.deckCard[4];
                        if (!check)
                        {
                            horizontal = Bot2PanelDefaultHorizontalCoordinate;
                            vertical = Bot2PanelDefaultVerticalCoordinate;
                        }

                        check = true;
                        cardToBeDealt[i].Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += cardToBeDealt[i].Width;
                        cardToBeDealt[i].Visible = true;
                        this.Controls.Add(this.bot2Panel);
                        this.bot2Panel.Location = new Point(cardToBeDealt[4].Left - 10, cardToBeDealt[4].Top - 10);
                        this.bot2Panel.BackColor = Color.DarkBlue;
                        this.bot2Panel.Height = 150;
                        this.bot2Panel.Width = 180;
                        this.bot2Panel.Visible = false;
                        if (i == 5)
                        {
                            check = false;
                        }
                    }
                }

                //If bot3 has chips,receives shuffledDeck[6] i shuffledDeck[7] cards(cards 7 and 8)
                //Also bot3 panel and card controls are initialized
                //Bot3 cards are covered
                if (bot3Chips > 0)
                {
                    foldedPlayers--;
                    if (i >= 6 && i < 8)
                    {
                        if (cardToBeDealt[6].Tag != null)
                        {
                            cardToBeDealt[7].Tag = this.deckCard[7];
                        }

                        cardToBeDealt[6].Tag = this.deckCard[6];
                        if (!check)
                        {
                            horizontal = Bot3PanelDefaultHorizontalCoordinate;
                            vertical = Bot3PanelDefaultVerticalCoordinate;
                        }

                        check = true;
                        cardToBeDealt[i].Anchor = (AnchorStyles.Top);
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += cardToBeDealt[i].Width;
                        cardToBeDealt[i].Visible = true;
                        this.Controls.Add(this.bot3Panel);
                        this.bot3Panel.Location = new Point(cardToBeDealt[6].Left - 10, cardToBeDealt[6].Top - 10);
                        this.bot3Panel.BackColor = Color.DarkBlue;
                        this.bot3Panel.Height = 150;
                        this.bot3Panel.Width = 180;
                        this.bot3Panel.Visible = false;
                        if (i == 7)
                        {
                            check = false;
                        }
                    }
                }

                //If bot4 has chips,receives shuffledDeck[8] i shuffledDeck[9] cards(cards 9 and 10)
                //Also bot4 panel and card controls are initialized
                //Bot4 cards are covered
                if (bot4Chips > 0)
                {
                    foldedPlayers--;
                    if (i >= 8 && i < 10)
                    {
                        if (cardToBeDealt[8].Tag != null)
                        {
                            cardToBeDealt[9].Tag = this.deckCard[9];
                        }

                        cardToBeDealt[8].Tag = this.deckCard[8];
                        if (!check)
                        {
                            horizontal = Bot4PanelDefaultHorizontalCoordinate;
                            vertical = Bot4PanelDefaultVerticalCoordinate;
                        }

                        check = true;
                        cardToBeDealt[i].Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += cardToBeDealt[i].Width;
                        cardToBeDealt[i].Visible = true;
                        this.Controls.Add(this.bot4Panel);
                        this.bot4Panel.Location = new Point(cardToBeDealt[8].Left - 10, cardToBeDealt[8].Top - 10);
                        this.bot4Panel.BackColor = Color.DarkBlue;
                        this.bot4Panel.Height = 150;
                        this.bot4Panel.Width = 180;
                        this.bot4Panel.Visible = false;
                        if (i == 9)
                        {
                            check = false;
                        }
                    }
                }

                //If bot5 has chips,receives shuffledDeck[10] i shuffledDeck[11] cards(cards 11 and 12)
                //Also bot5 panel and card controls are initialized
                //Bot5 cards are covered
                if (bot5Chips > 0)
                {
                    foldedPlayers--;
                    if (i >= 10 && i < 12)
                    {
                        if (cardToBeDealt[10].Tag != null)
                        {
                            cardToBeDealt[11].Tag = this.deckCard[11];
                        }

                        cardToBeDealt[10].Tag = this.deckCard[10];
                        if (!check)
                        {
                            horizontal = Bot5PanelDefaultHorizontalCoordinate;
                            vertical = Bot5PanelDefaultVerticalCoordinate;
                        }

                        check = true;
                        cardToBeDealt[i].Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += cardToBeDealt[i].Width;
                        cardToBeDealt[i].Visible = true;
                        this.Controls.Add(this.bot5Panel);
                        this.bot5Panel.Location = new Point(cardToBeDealt[10].Left - 10, cardToBeDealt[10].Top - 10);
                        this.bot5Panel.BackColor = Color.DarkBlue;
                        this.bot5Panel.Height = 150;
                        this.bot5Panel.Width = 180;
                        this.bot5Panel.Visible = false;
                        if (i == 11)
                        {
                            check = false;
                        }
                    }
                }

                //Deal table cards face down
                ////Initialize table card controls 

                if (i >= 12)
                {
                    cardToBeDealt[12].Tag = this.deckCard[12];
                    if (i > 12)
                    {
                        {
                            cardToBeDealt[13].Tag = this.deckCard[13];
                        }
                    }

                    if (i > 13)
                    {
                        cardToBeDealt[14].Tag = this.deckCard[14];
                    }

                    if (i > 14)
                    {
                        cardToBeDealt[15].Tag = this.deckCard[15];
                    }

                    if (i > 15)
                    {
                        cardToBeDealt[16].Tag = this.deckCard[16];
                    }

                    if (!check)
                    {
                        horizontal = 410;
                        vertical = 265;
                    }

                    check = true;
                    if (cardToBeDealt[i] != null)
                    {
                        cardToBeDealt[i].Anchor = AnchorStyles.None;
                        cardToBeDealt[i].Image = backImage;
                        ////cardToBeDealt[i].Image = shuffledDeck[i];
                        cardToBeDealt[i].Location = new Point(horizontal, vertical);
                        horizontal += 110;
                    }
                }

                //Check if bot1 has chips to play 
                //and if so makes its card controls visible
                if (bot1Chips <= 0)
                {
                    this.bot1FoldOrAllIn = true;
                    cardToBeDealt[2].Visible = false;
                    cardToBeDealt[3].Visible = false;
                }
                else
                {
                    this.bot1FoldOrAllIn = false;
                    if (i == 3)
                    {
                        if (cardToBeDealt[3] != null)
                        {
                            cardToBeDealt[2].Visible = true;
                            cardToBeDealt[3].Visible = true;
                        }
                    }
                }

                //Check if bot2 has chips to play 
                //and if so makes its card controls visible
                if (bot2Chips <= 0)
                {
                    this.bot2FoldOrAllIn = true;
                    cardToBeDealt[4].Visible = false;
                    cardToBeDealt[5].Visible = false;
                }
                else
                {
                    this.bot2FoldOrAllIn = false;
                    if (i == 5)
                    {
                        if (cardToBeDealt[5] != null)
                        {
                            cardToBeDealt[4].Visible = true;
                            cardToBeDealt[5].Visible = true;
                        }
                    }
                }

                //Check if bot3 has chips to play 
                //and if so makes its card controls visible
                if (bot3Chips <= 0)
                {
                    this.bot3FoldOrAllIn = true;
                    cardToBeDealt[6].Visible = false;
                    cardToBeDealt[7].Visible = false;
                }
                else
                {
                    this.bot3FoldOrAllIn = false;
                    if (i == 7)
                    {
                        if (cardToBeDealt[7] != null)
                        {
                            cardToBeDealt[6].Visible = true;
                            cardToBeDealt[7].Visible = true;
                        }
                    }
                }

                //Check if bot4 has chips to play 
                //and if so makes its card controls visible
                if (bot4Chips <= 0)
                {
                    this.bot4FoldOrAllIn = true;
                    cardToBeDealt[8].Visible = false;
                    cardToBeDealt[9].Visible = false;
                }
                else
                {
                    this.bot4FoldOrAllIn = false;
                    if (i == 9)
                    {
                        if (cardToBeDealt[9] != null)
                        {
                            cardToBeDealt[8].Visible = true;
                            cardToBeDealt[9].Visible = true;
                        }
                    }
                }

                //Check if bot5 has chips to play 
                //and if so makes its card controls visible
                if (bot5Chips <= 0)
                {
                    this.bot5FoldOrAllIn = true;
                    cardToBeDealt[10].Visible = false;
                    cardToBeDealt[11].Visible = false;
                }
                else
                {
                    this.bot5FoldOrAllIn = false;
                    if (i == 11)
                    {
                        if (cardToBeDealt[11] != null)
                        {
                            cardToBeDealt[10].Visible = true;
                            cardToBeDealt[11].Visible = true;
                        }
                    }
                }

                //If all cards are dealt starts timer for player
                if (i == 16)
                {
                    if (!restart)
                    {
                        MaximizeBox = true;
                        MinimizeBox = true;
                    }

                    timer.Start();
                }
            }

            //After dealing checks if all bots are out of chips
            //If so asks to restart poker session 
            //If yes, restarts session
            //If no, exits game
            if (foldedPlayers == 5)
            {
                DialogResult dialogResult = MessageBox.Show("Would You Like To Play Again ?", "You Won , Congratulations ! ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            //If there are bot with chips accepts that all bots
            //have chips before the next game
            else
            {
                foldedPlayers = 5;
            }

            //After dealing enables Raise, Call and Fold buttons for
            //player
            if (i == MaximumCardsToBeDealt)
            {
                buttonRaise.Enabled = true;
                buttonCall.Enabled = true;
                buttonRaise.Enabled = true;
                buttonRaise.Enabled = true;
                buttonFold.Enabled = true;
            }
        }

        /// <summary>
        /// Goes through all players until the game is finished
        /// (restart variable = false).
        /// Refreshes all current player's statistics for call,
        /// raise, fold and check.
        /// Each player makes a choice depending on his current best hand.
        /// </summary>
        /// <returns>The System.Threading.Tasks.Task type object</returns>        
        public async Task Turns()
        {
            //Checks if human player folds this turn
            if (!this.playerFoldOrAllIn)
            {
                //If it's human player's turn adjusts call and raise amounts
                //enables button controls and starts timer
                if (this.isPlayerTurn)
                {
                    FixCall(labelPlayerStatus, ref this.playerCall, ref this.playerRaise, 1);
                    ////MessageBox.Show("Player's Turn");
                    progressbarTimer.Visible = true;
                    progressbarTimer.Value = 1000;
                    playerTime = 60;
                    up = 10000000;
                    timer.Start();
                    buttonRaise.Enabled = true;
                    buttonCall.Enabled = true;
                    buttonRaise.Enabled = true;
                    buttonRaise.Enabled = true;
                    buttonFold.Enabled = true;
                    turnCount++;
                    FixCall(labelPlayerStatus, ref this.playerCall, ref this.playerRaise, 2);
                }
            }

            //Checks if the game should continue
            //If human player folds turn removes him from fold register
            if (this.playerFoldOrAllIn || !this.isPlayerTurn)
            {
                await AllIn();
                if (this.playerFoldOrAllIn && !this.isPlayerFolded)
                {
                    if (buttonCall.Text.Contains("All in") == false || buttonRaise.Text.Contains("All in") == false)
                    {
                        foldRegister.RemoveAt(0);
                        foldRegister.Insert(0, null);
                        maxLeft--;
                        this.isPlayerFolded = true;
                    }
                }
                ////
                await CheckRaise(0, 0);

                //Disables human player's button controls
                //Stops timer 
                progressbarTimer.Visible = false;
                buttonRaise.Enabled = false;
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                timer.Stop();

                //Enables bot1               
                this.isBot1Turn = true;

                //Bot1 turn
                //Checks if bot1 has not folded or made an all in
                //If not adjusts call and raise amount for bot1 
                //Bot1 makes a choice using the AIEngine
                //disables bot1 
                //enables bot2
                if (!this.bot1FoldOrAllIn)
                {
                    if (this.isBot1Turn)
                    {
                        FixCall(labelBot1Status, ref this.bot1Call, ref this.bot1Raise, 1);
                        FixCall(labelBot1Status, ref this.bot1Call, ref this.bot1Raise, 2);
                        DeterminePlayerCurrentBestHand(2, 3, "Bot 1", ref this.bot1HandCategoryFactor, ref this.bot1HandRankFactor, this.bot1FoldOrAllIn);
                        MessageBox.Show("Bot 1's Turn");
                        AIEngine(2, 3, ref bot1Chips, ref this.isBot1Turn, ref  this.bot1FoldOrAllIn, labelBot1Status, 0, this.bot1HandRankFactor, this.bot1HandCategoryFactor);
                        turnCount++;
                        last = 1;
                        this.isBot1Turn = false;
                        this.isBot2Turn = true;
                    }
                }

                //Checks if bot1 has folded this turn
                //If so removes him from the fold register
                if (this.bot1FoldOrAllIn && !this.isBot1Folded)
                {
                    foldRegister.RemoveAt(1);
                    foldRegister.Insert(1, null);
                    maxLeft--;
                    this.isBot1Folded = true;
                }

                //Refreshes game raise status
                //Enables bot2 //again?
                if (this.bot1FoldOrAllIn || !this.isBot1Turn)
                {
                    await CheckRaise(1, 1);
                    this.isBot2Turn = true;
                }

                //Bot2 turn
                //Checks if bot2 has not folded or made an all in
                //If not adjusts call and raise amount for bot2 
                //Bot2 makes a choice using the AIEngine
                //Disables bot2 
                //Enables bot3
                if (!this.bot2FoldOrAllIn)
                {
                    if (this.isBot2Turn)
                    {
                        FixCall(labelBot2Status, ref this.bot2Call, ref this.bot2Raise, 1);
                        FixCall(labelBot2Status, ref this.bot2Call, ref this.bot2Raise, 2);
                        DeterminePlayerCurrentBestHand(4, 5, "Bot 2", ref this.bot2HandCategoryFactor, ref this.bot2HandRankFactor, this.bot2FoldOrAllIn);
                        MessageBox.Show("Bot 2's Turn");
                        AIEngine(4, 5, ref bot2Chips, ref this.isBot2Turn, ref  this.bot2FoldOrAllIn, labelBot2Status, 1, this.bot2HandRankFactor, this.bot2HandCategoryFactor);
                        turnCount++;
                        last = 2;
                        this.isBot2Turn = false;
                        this.isBot3Turn = true;
                    }
                }

                //Checks if bot2 has folded this turn
                //If so removes him from the fold register
                if (this.bot2FoldOrAllIn && !this.isBot2Folded)
                {
                    foldRegister.RemoveAt(2);
                    foldRegister.Insert(2, null);
                    maxLeft--;
                    this.isBot2Folded = true;
                }

                //Refreshes game raise status
                //Enables bot3 //again?
                if (this.bot2FoldOrAllIn || !this.isBot2Turn)
                {
                    await CheckRaise(2, 2);
                    this.isBot3Turn = true;
                }

                //Bot3 turn
                //Checks if bot3 has not folded or made an all in
                //If not adjusts call and raise amount for bot3 
                //Bot3 makes a choice using the AIEngine
                //Disables bot3 
                //Enables bot4
                if (!this.bot3FoldOrAllIn)
                {
                    if (this.isBot3Turn)
                    {
                        FixCall(labelBot3Status, ref this.bot3Call, ref this.bot3Raise, 1);
                        FixCall(labelBot3Status, ref this.bot3Call, ref this.bot3Raise, 2);
                        DeterminePlayerCurrentBestHand(6, 7, "Bot 3", ref this.bot3HandCategoryFactor, ref this.bot3HandRankFactor, this.bot3FoldOrAllIn);
                        MessageBox.Show("Bot 3's Turn");
                        AIEngine(6, 7, ref bot3Chips, ref this.isBot3Turn, ref  this.bot3FoldOrAllIn, labelBot3Status, 2, this.bot3HandRankFactor, this.bot3HandCategoryFactor);
                        turnCount++;
                        last = 3;
                        this.isBot3Turn = false;
                        this.isBot4Turn = true;
                    }
                }

                //Checks if bot3 has folded this turn
                //If so removes him from the fold register
                if (this.bot3FoldOrAllIn && !this.isBot3Folded)
                {
                    foldRegister.RemoveAt(3);
                    foldRegister.Insert(3, null);
                    maxLeft--;
                    this.isBot3Folded = true;
                }

                //Refreshes game raise status
                //Enables bot4 //again?
                if (this.bot3FoldOrAllIn || !this.isBot3Turn)
                {
                    await CheckRaise(3, 3);
                    this.isBot4Turn = true;
                }

                //Bot4 turn
                //Checks if bot4 has not folded or made an all in
                //If not adjusts call and raise amount for bot4 
                //Bot4 makes a choice using the AIEngine
                //Disables bot4 
                //Enables bot5
                if (!this.bot4FoldOrAllIn)
                {
                    if (this.isBot4Turn)
                    {
                        FixCall(labelBot4Status, ref this.bot4Call, ref this.bot4Raise, 1);
                        FixCall(labelBot4Status, ref this.bot4Call, ref this.bot4Raise, 2);
                        DeterminePlayerCurrentBestHand(8, 9, "Bot 4", ref this.bot4HandCategoryFactor, ref this.bot4HandRankFactor, this.bot4FoldOrAllIn);
                        MessageBox.Show("Bot 4's Turn");
                        AIEngine(8, 9, ref bot4Chips, ref this.isBot4Turn, ref  this.bot4FoldOrAllIn, labelBot4Status, 3, this.bot4HandRankFactor, this.bot4HandCategoryFactor);
                        turnCount++;
                        last = 4;
                        this.isBot4Turn = false;
                        this.isBot5Turn = true;
                    }
                }

                //Checks if bot4 has folded this turn
                //If so removes him from the fold register
                if (this.bot4FoldOrAllIn && !this.isBot4Folded)
                {
                    foldRegister.RemoveAt(4);
                    foldRegister.Insert(4, null);
                    maxLeft--;
                    this.isBot4Folded = true;
                }

                //Refreshes game raise status
                //Enables bot5 //again?
                if (this.bot4FoldOrAllIn || !this.isBot4Turn)
                {
                    await CheckRaise(4, 4);
                    this.isBot5Turn = true;
                }

                //Bot5 turn
                //Checks if bot5 has not folded or made an all in
                //If not adjusts call and raise amount for bot5 
                //Bot5 makes a choice using the AIEngine
                //Disables bot5 
                if (!this.bot5FoldOrAllIn)
                {
                    if (this.isBot5Turn)
                    {
                        FixCall(labelBot5Status, ref this.bot5Call, ref this.bot5Raise, 1);
                        FixCall(labelBot5Status, ref this.bot5Call, ref this.bot5Raise, 2);
                        DeterminePlayerCurrentBestHand(10, 11, "Bot 5", ref this.bot5HandCategoryFactor, ref this.bot5HandRankFactor, this.bot5FoldOrAllIn);
                        MessageBox.Show("Bot 5's Turn");
                        AIEngine(10, 11, ref bot5Chips, ref this.isBot5Turn, ref  this.bot5FoldOrAllIn, labelBot5Status, 4, this.bot5HandRankFactor, this.bot5HandCategoryFactor);
                        turnCount++;
                        last = 5;
                        this.isBot5Turn = false;
                    }
                }

                //Checks if bot5 has folded this turn
                //If so removes him from the fold register
                if (this.bot5FoldOrAllIn && !this.isBot5Folded)
                {
                    foldRegister.RemoveAt(5);
                    foldRegister.Insert(5, null);
                    maxLeft--;
                    this.isBot5Folded = true;
                }

                //Refreshes game raise status
                //Enables human player turn
                if (this.bot5FoldOrAllIn || !this.isBot5Turn)
                {
                    await CheckRaise(5, 5);
                    this.isPlayerTurn = true;
                }

                //If human player folds turn removes him from fold register
                if (this.playerFoldOrAllIn && !this.isPlayerFolded)
                {
                    if (buttonCall.Text.Contains("All in") == false || buttonRaise.Text.Contains("All in") == false)
                    {
                        foldRegister.RemoveAt(0);
                        foldRegister.Insert(0, null);
                        maxLeft--;
                        this.isPlayerFolded = true;
                    }
                }

                //checks if the game should continue
                await AllIn();

                //If not, starts next round of turns
                if (!restart)
                {
                    await Turns();
                }

                restart = false;
            }
        }
        
        /// <summary>
        /// Checks if a player has a certain hand starting from a pair hand.
        /// For bots this check is made every turn to help
        /// them make their choice.
        /// Each confirmed hand is added as a competing hand
        /// to a list of competing hands.
        /// The winning hand is determined at the end of each addition.
        /// Check starts with lowest not default hand and continues
        /// to each next rank with category factor +1.
        /// Ends with HighCard hand check which
        /// is the default hand for the player.
        /// </summary>
        /// <param name="card1">Current player's first dealt card</param>
        /// <param name="card2">Current player's second dealt card</param>
        /// <param name="currentText">the name of the current player</param>
        /// <param name="currentPlayerCategoryFactor">The current player's category factor parameter, determined from his best hand</param>
        /// <param name="currentPlayerRankFactor">The current player's rank factor parameter determined from his best hand</param>
        /// <param name="foldedTurn">current player's FoldorAllin Boolean index</param>        
        public void DeterminePlayerCurrentBestHand(int card1, int card2, string currentText, ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, bool foldedTurn)
        {
            //Checks if current player is the human player
            //If so does nothing
            if (card1 == 0 && card2 == 1)
            {
            }

            //Checks if current player is the human player and if he folded turn
            if (!foldedTurn || card1 == 0 && card2 == 1 && labelPlayerStatus.Text.Contains("Fold") == false)
            {
                ////<summary>
                ////Used in CheckHasFullHouse
                ////</summary>
                bool done = false;

                ////<summary>
                ////Used in CheckHasFlush
                ////</summary>
                bool hasFlush = false;

                ////<summary>
                ////Table cards
                ////</summary>
                int[] tableCards = new int[5];//table cards (board cards)

                ////<summary>
                ////Combined player and table cards
                ////</summary>
                int[] combinedCards = new int[7];//player cards plus table cards
                combinedCards[0] = this.deckCard[card1];
                combinedCards[1] = this.deckCard[card2];
                tableCards[0] = combinedCards[2] = this.deckCard[12];
                tableCards[1] = combinedCards[3] = this.deckCard[13];
                tableCards[2] = combinedCards[4] = this.deckCard[14];
                tableCards[3] = combinedCards[5] = this.deckCard[15];
                tableCards[4] = combinedCards[6] = this.deckCard[16];

                ////Divides combined cards in 4 arrays for each different suit

                ////<summary>
                ////The clubs suit cards in the array of combined cards
                ////</summary>
                var clubs = combinedCards.Where(o => o % 4 == 0).ToArray();

                ////<summary>
                ////The diamonds suit cards in the array of combined cards
                ////</summary>
                var diamonds = combinedCards.Where(o => o % 4 == 1).ToArray();

                ////<summary>
                ////The hearts suit cards in the array of combined cards
                ////</summary>
                var hearts = combinedCards.Where(o => o % 4 == 2).ToArray();

                ////<summary>
                ////The spades suit cards in the array of combined cards
                ////</summary>
                var spades = combinedCards.Where(o => o % 4 == 3).ToArray();

                ////Creates a new array for each suit with only distinct cards

                ////<summary>
                ////The distinct clubs suit cards in the array of combined cards
                ////</summary>
                var distinctClubs = clubs.Select(o => o / 4).Distinct().ToArray();

                ////<summary>
                ////The distinct diamonds suit cards in the array of combined cards
                ////</summary>
                var distinctDiamonds = diamonds.Select(o => o / 4).Distinct().ToArray();

                ////<summary>
                ////The distinct diamonds suit cards in the array of combined cards
                ////</summary>
                var distinctHearts = hearts.Select(o => o / 4).Distinct().ToArray();

                ////<summary>
                ////The distinct spades suit cards in the array of combined cards
                ////</summary>
                var distinctSpades = spades.Select(o => o / 4).Distinct().ToArray();

                Array.Sort(combinedCards);//Sorts combined cards array
                Array.Sort(distinctClubs);//sorts clubs array with only the distinct cards
                Array.Sort(distinctDiamonds);//sorts diamonds array with only the distinct cards
                Array.Sort(distinctHearts);//sorts hearts array with only the distinct cards
                Array.Sort(distinctSpades);//sorts spades array with only the distinct cards

                for (i = 0; i < 16; i++)
                {
                    //Checks if player cards is dealt the cards he should be dealt
                    //etc., there is no problem with the shuffle engine
                    if (this.deckCard[i] == int.Parse(cardToBeDealt[card1].Tag.ToString()) && this.deckCard[i + 1] == int.Parse(cardToBeDealt[card2].Tag.ToString()))
                    {
                        //Checks if the current player has Pair from Hand
                        //currentPlayerCategoryFactor = 1
                        CheckPairFromHand(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor);

                        //Checks if the current player has pair Two Pair
                        //currentPlayerCategoryFactor = 2 if current player has one combined and one table pair
                        //currentPlayerCategoryFactor = 0 if current player has only table hand
                        CheckPairTwoPair(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor);

                        //Checks if the current player has two combined pairs(each from a table and a player card)
                        //currentPlayerCategoryFactor = 2
                        CheckTwoPair(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor);

                        //Checks if the current player has three of a kind hand
                        //currentPlayerCategoryFactor = 3
                        CheckThreeOfAKind(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, combinedCards);

                        //Checks if the current player has a Straight
                        //currentPlayerCategoryFactor = 4
                        CheckStraight(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, combinedCards);

                        //Checks if the current player has a Flush
                        //currentPlayerCategoryFactor = 5 || 5.5
                        CheckFlush(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, ref hasFlush, tableCards);

                        //Checks if the current player has a FullHouse
                        //currentPlayerCategoryFactor = 6
                        CheckFullHouse(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, ref done, combinedCards);
                        
                        //Checks if the current player has four of a kind hand
                        //currentPlayerCategoryFactor = 7
                        CheckFourOfAKind(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, combinedCards);                       

                        //Checks if the current player has a StraightFlush
                        //currentPlayerCategoryFactor = 8
                        //currentPlayerCategoryFactor = 9 if its RoyalFlush
                        CheckStraightFlush(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor, distinctClubs, distinctDiamonds, distinctHearts, distinctSpades);

                        //Checks the highest card for the current player
                        CheckHighCard(ref currentPlayerCategoryFactor, ref currentPlayerRankFactor);
                        ////currentPlayerCategoryFactor = -1,if this is his best hand
                    }
                }
            }
        }
        
        /// <summary>
        /// Checks if the player has a straight flush hand.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="distinctClubs">The array of distinct clubs cards</param>
        /// <param name="distinctDiamonds">The array of distinct diamonds cards</param>
        /// <param name="distinctHearts">The array of distinct hearts cards</param>
        /// <param name="distinctSpades">The array of spades cards</param>        
        public void CheckStraightFlush(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, int[] distinctClubs, int[] distinctDiamonds, int[] distinctHearts, int[] distinctSpades)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                //Starts with clubs

                //Checks if its a Flush of clubs
                if (distinctClubs.Length >= 5)
                {
                    //This check is for a straight
                    if (distinctClubs[0] + 4 == distinctClubs[4])
                    {
                        currentPlayerCategoryFactor = 8;
                        currentPlayerRankFactor = (distinctClubs.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 8 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    //This check is for royal flush(category factor = 9)
                    if (distinctClubs[0] == 0 && distinctClubs[1] == 9 && distinctClubs[2] == 10 && distinctClubs[3] == 11 && distinctClubs[0] + 12 == distinctClubs[4])
                    {
                        currentPlayerCategoryFactor = 9;
                        currentPlayerRankFactor = (distinctClubs.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 9 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                ////Checks the diamonds

                if (distinctDiamonds.Length >= 5)
                {
                    if (distinctDiamonds[0] + 4 == distinctDiamonds[4])
                    {
                        currentPlayerCategoryFactor = 8;
                        currentPlayerRankFactor = (distinctDiamonds.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 8 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (distinctDiamonds[0] == 0 && distinctDiamonds[1] == 9 && distinctDiamonds[2] == 10 && distinctDiamonds[3] == 11 && distinctDiamonds[0] + 12 == distinctDiamonds[4])
                    {
                        currentPlayerCategoryFactor = 9;
                        currentPlayerRankFactor = (distinctDiamonds.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 9 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                //Checks the hearts
                if (distinctHearts.Length >= 5)
                {
                    if (distinctHearts[0] + 4 == distinctHearts[4])
                    {
                        currentPlayerCategoryFactor = 8;
                        currentPlayerRankFactor = (distinctHearts.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 8 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (distinctHearts[0] == 0 && distinctHearts[1] == 9 && distinctHearts[2] == 10 && distinctHearts[3] == 11 && distinctHearts[0] + 12 == distinctHearts[4])
                    {
                        currentPlayerCategoryFactor = 9;
                        currentPlayerRankFactor = (distinctHearts.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 9 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                //Checks the spades
                if (distinctSpades.Length >= 5)
                {
                    if (distinctSpades[0] + 4 == distinctSpades[4])
                    {
                        currentPlayerCategoryFactor = 8;
                        currentPlayerRankFactor = (distinctSpades.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 8 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (distinctSpades[0] == 0 && distinctSpades[1] == 9 && distinctSpades[2] == 10 && distinctSpades[3] == 11 && distinctSpades[0] + 12 == distinctSpades[4])
                    {
                        currentPlayerCategoryFactor = 9;
                        currentPlayerRankFactor = (distinctSpades.Max() / 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 9 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the current player has four of a kind hand.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player hand rank factor</param>
        /// <param name="combinedCards">The combined cards of current player</param>        
        public void CheckFourOfAKind(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, int[] combinedCards)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                //Makes four consecutive checks
                for (int j = 0; j <= 3; j++)
                {
                    if (combinedCards[j] / 4 == combinedCards[j + 1] / 4 && combinedCards[j] / 4 == combinedCards[j + 2] / 4 &&
                        combinedCards[j] / 4 == combinedCards[j + 3] / 4)
                    {
                        currentPlayerCategoryFactor = 7;
                        currentPlayerRankFactor = ((combinedCards[j] / 4) * 4) + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 7 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    //Case when four same rank cards are aces
                    if (combinedCards[j] / 4 == 0 && combinedCards[j + 1] / 4 == 0 && combinedCards[j + 2] / 4 == 0 && combinedCards[j + 3] / 4 == 0)
                    {
                        currentPlayerCategoryFactor = 7;
                        currentPlayerRankFactor = 13 * 4 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 7 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if player has a FullHouse.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="done">The done parameter</param>
        /// <param name="combinedCards">The combined cards of the current player</param>        
        public void CheckFullHouse(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, ref bool done, int[] combinedCards)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                //Stores current player's Rank Factor in variable
                //If the check for a three of a kind is successful 
                //currentPlayerRankFactor is set with a new value 
                //but if the hand is not FullHouse then new currentPlayerRankFactor value is invalid.
                //As a whole the operation described here is incorrect
                secondaryFactor = currentPlayerRankFactor;

                //For each rank
                for (int j = 0; j <= 12; j++)
                {
                    //Creates an array
                    var rankGroup = combinedCards.Where(o => o / 4 == j).ToArray();

                    //Checks if an array has a length of 3 or the check is already performed and one of the arrays has a length of 3
                    if (rankGroup.Length == 3 || done)
                    {
                        //If one of the previous arrays has a length of 3,
                        //checks if this one has a length of 2
                        if (rankGroup.Length == 2)
                        {
                            //If player holds an ace this is special case for calculating rank factor
                            if (rankGroup.Max() / 4 == 0)
                            {
                                currentPlayerCategoryFactor = 6;
                                currentPlayerRankFactor = 13 * 2 + currentPlayerCategoryFactor * 100;
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 6 });
                                winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                                break;
                            }

                            //Current player holds no ace
                            //This is usual situation for calculating rank factor
                            if (rankGroup.Max() / 4 > 0)
                            {
                                currentPlayerCategoryFactor = 6;
                                currentPlayerRankFactor = ((rankGroup.Max() / 4) * 2) + (currentPlayerCategoryFactor * 100);
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 6 });
                                winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                                break;
                            }
                        }

                        //Checks if currentPlayerRankFactor is set to a new value after positive check for a three of a kind
                        //though this new value is not used, thus the reset of the value is pointless
                        if (!done)
                        {
                            //If the three same rank cards are aces
                            if (rankGroup.Max() / 4 == 0)
                            {
                                currentPlayerRankFactor = 13;
                                done = true;
                                j = -1;
                            }
                            ////If they're not aces
                            else
                            {
                                currentPlayerRankFactor = rankGroup.Max() / 4;
                                done = true;
                                j = -1;
                            }
                        }
                    }
                }

                //If the hand is not FullHouse. previous currentPlayerRankFactor is restored
                if (currentPlayerCategoryFactor != 6)
                {
                    currentPlayerRankFactor = secondaryFactor;
                }
            }
        }

        /// <summary>
        /// Checks if current player has a Flush.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="hasFlush">The hasFlush Boolean parameter</param>
        /// <param name="tableCards">The table cards</param>        
        public void CheckFlush(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, ref bool hasFlush, int[] tableCards)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                //Divides table cards in four arrays for each suit
                var clubs = tableCards.Where(o => o % 4 == 0).ToArray();
                var diamonds = tableCards.Where(o => o % 4 == 1).ToArray();
                var hearts = tableCards.Where(o => o % 4 == 2).ToArray();
                var spades = tableCards.Where(o => o % 4 == 3).ToArray();

                //Starts with clubs

                //Makes a check for a flush only when three or 4 cards are the same suit
                if (clubs.Length == 3 || clubs.Length == 4)
                {
                    //Checks if current player's cards are clubs suit
                    if (this.deckCard[i] % 4 == this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == clubs[0] % 4)
                    {
                        //Checks if current player first card is higher than the highest clubs from the table
                        //If so sets Rank Factor accordingly
                        if (this.deckCard[i] / 4 > clubs.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        //Checks if current player second card is higher than the highest clubs card from the table
                        //If so sets Rank Factor accordingly
                        if (this.deckCard[i + 1] / 4 > clubs.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        //If not Rank Factor is set using table clubs card with the maximum rank
                        else if (this.deckCard[i] / 4 < clubs.Max() / 4 && this.deckCard[i + 1] / 4 < clubs.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = clubs.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                //Makes a check for a flush when 4 of the table cards are the same suit 
                if (clubs.Length == 4)//different cards in hand
                {
                    //Checks if current player first card is clubs
                    if (this.deckCard[i] % 4 != this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == clubs[0] % 4)
                    {
                        //Checks if current player first card is higher than the highest clubs from the table
                        //If so sets Rank Factor accordingly
                        if (this.deckCard[i] / 4 > clubs.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        ////If not Rank Factor is set using table clubs card with the maximum rank
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = clubs.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }

                    //Checks if current player's second card is clubs
                    if (this.deckCard[i + 1] % 4 != this.deckCard[i] % 4 && this.deckCard[i + 1] % 4 == clubs[0] % 4)
                    {
                        //Checks if current player second card is higher than the highest clubs card from the table
                        //If so sets Rank Factor accordingly
                        if (this.deckCard[i + 1] / 4 > clubs.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        //If not Rank Factor is set using table clubs card with the maximum rank
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = clubs.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                //Makes a check for a flush when all 5 table cards are clubs 
                if (clubs.Length == 5)//playing the board
                {
                    //Checks if player's first card is clubs and is bigger than table lowest card
                    //If so, the player does not play the board
                    //If so, sets competing hand rank factor using player first card
                    if (this.deckCard[i] % 4 == clubs[0] % 4 && this.deckCard[i] / 4 > clubs.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                    ////Checks if player second card is clubs and is bigger than table lowest card
                    //If so the player does not play the board
                    //If so sets competing hard ad rank factor using player second card
                    if (this.deckCard[i + 1] % 4 == clubs[0] % 4 && this.deckCard[i + 1] / 4 > clubs.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }

                    //if current player's two cards are smaller than the table lowest
                    //Rank Factor is set using table lowest card
                    else if (this.deckCard[i] / 4 < clubs.Min() / 4 && this.deckCard[i + 1] / 4 < clubs.Min())
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = clubs.Max() + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                }

                //Makes the same check for diamonds suit
                if (diamonds.Length == 3 || diamonds.Length == 4)
                {
                    if (this.deckCard[i] % 4 == this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == diamonds[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > diamonds.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        if (this.deckCard[i + 1] / 4 > diamonds.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else if (this.deckCard[i] / 4 < diamonds.Max() / 4 && this.deckCard[i + 1] / 4 < diamonds.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = diamonds.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (diamonds.Length == 4)//different cards in hand
                {
                    if (this.deckCard[i] % 4 != this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == diamonds[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > diamonds.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = diamonds.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }

                    if (this.deckCard[i + 1] % 4 != this.deckCard[i] % 4 && this.deckCard[i + 1] % 4 == diamonds[0] % 4)
                    {
                        if (this.deckCard[i + 1] / 4 > diamonds.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = diamonds.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (diamonds.Length == 5)
                {
                    if (this.deckCard[i] % 4 == diamonds[0] % 4 && this.deckCard[i] / 4 > diamonds.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }

                    if (this.deckCard[i + 1] % 4 == diamonds[0] % 4 && this.deckCard[i + 1] / 4 > diamonds.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                    else if (this.deckCard[i] / 4 < diamonds.Min() / 4 && this.deckCard[i + 1] / 4 < diamonds.Min())
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = diamonds.Max() + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                }

                //Makes the same check for hearts suit
                if (hearts.Length == 3 || hearts.Length == 4)
                {
                    if (this.deckCard[i] % 4 == this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == hearts[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > hearts.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        if (this.deckCard[i + 1] / 4 > hearts.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else if (this.deckCard[i] / 4 < hearts.Max() / 4 && this.deckCard[i + 1] / 4 < hearts.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = hearts.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (hearts.Length == 4)//different cards in hand
                {
                    if (this.deckCard[i] % 4 != this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == hearts[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > hearts.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = hearts.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }

                    if (this.deckCard[i + 1] % 4 != this.deckCard[i] % 4 && this.deckCard[i + 1] % 4 == hearts[0] % 4)
                    {
                        if (this.deckCard[i + 1] / 4 > hearts.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = hearts.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (hearts.Length == 5)
                {
                    if (this.deckCard[i] % 4 == hearts[0] % 4 && this.deckCard[i] / 4 > hearts.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }

                    if (this.deckCard[i + 1] % 4 == hearts[0] % 4 && this.deckCard[i + 1] / 4 > hearts.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                    else if (this.deckCard[i] / 4 < hearts.Min() / 4 && this.deckCard[i + 1] / 4 < hearts.Min())
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = hearts.Max() + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                }

                //Makes the same check for spades suit
                if (spades.Length == 3 || spades.Length == 4)
                {
                    if (this.deckCard[i] % 4 == this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == spades[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > spades.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }

                        if (this.deckCard[i + 1] / 4 > spades.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else if (this.deckCard[i] / 4 < spades.Max() / 4 && this.deckCard[i + 1] / 4 < spades.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = spades.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (spades.Length == 4)//different cards in hand
                {
                    if (this.deckCard[i] % 4 != this.deckCard[i + 1] % 4 && this.deckCard[i] % 4 == spades[0] % 4)
                    {
                        if (this.deckCard[i] / 4 > spades.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = spades.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }

                    if (this.deckCard[i + 1] % 4 != this.deckCard[i] % 4 && this.deckCard[i + 1] % 4 == spades[0] % 4)
                    {
                        if (this.deckCard[i + 1] / 4 > spades.Max() / 4)
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                        else
                        {
                            currentPlayerCategoryFactor = 5;
                            currentPlayerRankFactor = spades.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                            hasFlush = true;
                        }
                    }
                }

                if (spades.Length == 5)
                {
                    if (this.deckCard[i] % 4 == spades[0] % 4 && this.deckCard[i] / 4 > spades.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }

                    if (this.deckCard[i + 1] % 4 == spades[0] % 4 && this.deckCard[i + 1] / 4 > spades.Min() / 4)
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                    else if (this.deckCard[i] / 4 < spades.Min() / 4 && this.deckCard[i + 1] / 4 < spades.Min())
                    {
                        currentPlayerCategoryFactor = 5;
                        currentPlayerRankFactor = spades.Max() + (currentPlayerCategoryFactor * 100);
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        hasFlush = true;
                    }
                }
                ////ace

                //Checks if player's Flush contains an ace
                //If so, sets competing hand's category Factor to 5.5 and Rank Factor using ace Rank(=13)

                //First check clubs
                if (clubs.Length > 0)//Improper compare
                {
                    //Checks the first of player's two cards
                    if (this.deckCard[i] / 4 == 0 && this.deckCard[i] % 4 == clubs[0] % 4 && hasFlush && clubs.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    //Checks the second of player's two cards
                    if (this.deckCard[i + 1] / 4 == 0 && this.deckCard[i + 1] % 4 == clubs[0] % 4 && hasFlush && clubs.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                //Then checks diamonds
                if (diamonds.Length > 0)
                {
                    if (this.deckCard[i] / 4 == 0 && this.deckCard[i] % 4 == diamonds[0] % 4 && hasFlush && diamonds.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (this.deckCard[i + 1] / 4 == 0 && this.deckCard[i + 1] % 4 == diamonds[0] % 4 && hasFlush && diamonds.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                //Then checks hearts
                if (hearts.Length > 0)
                {
                    if (this.deckCard[i] / 4 == 0 && this.deckCard[i] % 4 == hearts[0] % 4 && hasFlush && hearts.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (this.deckCard[i + 1] / 4 == 0 && this.deckCard[i + 1] % 4 == hearts[0] % 4 && hasFlush && hearts.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }

                //Then checks spades
                if (spades.Length > 0)
                {
                    if (this.deckCard[i] / 4 == 0 && this.deckCard[i] % 4 == spades[0] % 4 && hasFlush && spades.Length > 0)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }

                    if (this.deckCard[i + 1] / 4 == 0 && this.deckCard[i + 1] % 4 == spades[0] % 4 && hasFlush)
                    {
                        currentPlayerCategoryFactor = 5.5;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 5.5 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if current player has a Straight.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="combinedCards">The combined cards of the current player</param>        
        public void CheckStraight(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, int[] combinedCards)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                //Sorts card by rank
                //Puts all distinct cards in array
                var op = combinedCards.Select(o => o / 4).Distinct().ToArray();

                //If op.Length is at least 5, checks if a certain condition is met five times
                //Makes 1 ,2 or 3 checks for a combinedCards starting from the lowest five cards
                for (int j = 0; j < op.Length - 4; j++)
                {
                    //This line checks for a combinedCards
                    if (op[j] + 4 == op[j + 4])
                    {
                        //Checks if max card rank in op is the last from the five cards///Unnecessary
                        //Case when yes
                        if (op.Max() - 4 == op[j])
                        {
                            currentPlayerCategoryFactor = 4;
                            currentPlayerRankFactor = op.Max() + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 4 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        }
                            ////Case when not
                        else
                        {
                            currentPlayerCategoryFactor = 4;
                            currentPlayerRankFactor = op[j + 4] + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 4 });
                            winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                        }
                    }

                    //Checks if it there is an ace in the combinedCards
                    //Special case in setting competing hand ranks
                    if (op[j] == 0 && op[j + 1] == 9 && op[j + 2] == 10 && op[j + 3] == 11 && op[j + 4] == 12)
                    {
                        currentPlayerCategoryFactor = 4;
                        currentPlayerRankFactor = 13 + currentPlayerCategoryFactor * 100;
                        this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 4 });
                        winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if current player holds three cards of the same rank.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="combinedCards">The combined cards of the current player</param>        
        public void CheckThreeOfAKind(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor, int[] combinedCards)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                for (int j = 0; j <= 12; j++)
                {
                    //Creates an array for each rank
                    var rankGroup = combinedCards.Where(o => o / 4 == j).ToArray();

                    //If any array has a size 3 adds a threeOfAKind hand to competing hands
                    if (rankGroup.Length == 3)
                    {
                        //Sets category and rank factor
                        
                        //Case when the three cards are aces
                        if (rankGroup.Max() / 4 == 0)
                        {
                            currentPlayerCategoryFactor = 3;
                            currentPlayerRankFactor = 13 * 3 + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 3 });
                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                        }

                        //Case when the three cards are not aces
                        else
                        {
                            currentPlayerCategoryFactor = 3;
                            currentPlayerRankFactor = rankGroup[0] / 4 + rankGroup[1] / 4 + rankGroup[2] / 4 + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 3 });
                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if current player has two pairs formed from player's cards and table cards.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>        
        public void CheckTwoPair(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor)
        {
            if (currentPlayerCategoryFactor >= -1)//always true
            {
                bool msgbox = false;
                for (int tableCard = 16; tableCard >= 12; tableCard--)
                {
                    int max = tableCard - 12;

                    //Checks if current player's two cards form a pair
                    //If yes does nothing, if not continues
                    if (this.deckCard[i] / 4 != this.deckCard[i + 1] / 4)
                    {
                        for (int k = 1; k <= max; k++)
                        {
                            if (tableCard - k < 12)
                            {
                                max--;
                            }

                            if (tableCard - k >= 12)
                            {
                                //Checks if there are is a pair from player card1(i) and table card
                                //and a pair from player card2(i + 1) and table card - k
                                //or the opposite 
                                //If yes adds a two pair hand to competing hands
                                if (this.deckCard[i] / 4 == this.deckCard[tableCard] / 4 && this.deckCard[i + 1] / 4 == this.deckCard[tableCard - k] / 4 ||
                                    this.deckCard[i + 1] / 4 == this.deckCard[tableCard] / 4 && this.deckCard[i] / 4 == this.deckCard[tableCard - k] / 4)
                                {
                                    if (!msgbox)
                                    {
                                        //Case when player first card is an ace
                                        if (this.deckCard[i] / 4 == 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = ((13 * 4) + ((this.deckCard[i + 1] / 4) * 2)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }

                                        //Case when player second hand is an ace
                                        if (this.deckCard[i + 1] / 4 == 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = ((13 * 4) + ((this.deckCard[i] / 4) * 2)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }

                                        //Case when player cards are not aces
                                        if (this.deckCard[i + 1] / 4 != 0 && this.deckCard[i] / 4 != 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = (((this.deckCard[i] / 4) * 2) + ((this.deckCard[i + 1] / 4) * 2)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }
                                    }

                                    msgbox = true;
                                }
                            }
                        }
                    }
                }
            }
        }
  
        /// <summary>
        /// Checks if the current player has two pairs, 
        /// one of which is from table cards,
        /// or only one hand which is from table.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>        
        public void CheckPairTwoPair(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor)
        {
            if (currentPlayerCategoryFactor >= -1)//always true
            {
                bool msgbox = false;
                bool msgbox1 = false;
                for (int tableCard = 16; tableCard >= 12; tableCard--)
                {
                    int max = tableCard - 12;
                    for (int k = 1; k <= max; k++)
                    {
                        if (tableCard - k < 12)
                        {
                            max--;
                        }

                        if (tableCard - k >= 12)//always true
                        {
                            //Checks if two cards from the table form a pair
                            if (this.deckCard[tableCard] / 4 == this.deckCard[tableCard - k] / 4)
                            {
                                //Checks if any of current player's two cards form a three with the pair
                                //If not and if current player has a pair hand confirmed from CheckPairFromHand(currentPlayerCategoryFactor == 1)
                                //determines Hand Category and Rank Factor
                                if (this.deckCard[tableCard] / 4 != this.deckCard[i] / 4 && this.deckCard[tableCard] / 4 != this.deckCard[i + 1] / 4 && currentPlayerCategoryFactor == 1)
                                {
                                    if (!msgbox)
                                    {
                                        //Checks if current player has an ace as first card
                                        //Special case in setting rank factor
                                        if (this.deckCard[i + 1] / 4 == 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = (((this.deckCard[i] / 4) * 2) + (13 * 4)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }

                                        //Same check for second card
                                        if (this.deckCard[i] / 4 == 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = (((this.deckCard[i + 1] / 4) * 2) + (13 * 4)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }

                                        //Player first card is not an ace
                                        //Usual case in setting rank factor
                                        if (this.deckCard[i + 1] / 4 != 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = (((this.deckCard[tableCard] / 4) * 2) + ((this.deckCard[i + 1] / 4) * 2)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }

                                        //Player second card is not an ace
                                        //Usual case in setting rank factor
                                        if (this.deckCard[i] / 4 != 0)
                                        {
                                            currentPlayerCategoryFactor = 2;
                                            currentPlayerRankFactor = (((this.deckCard[tableCard] / 4) * 2) + ((this.deckCard[i] / 4) * 2)) + (currentPlayerCategoryFactor * 100);
                                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 2 });
                                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                        }
                                    }

                                    //sets bool variable msgbox as true
                                    msgbox = true;
                                }

                                //Case when current player does not have a pair formed from player's card and a table card
                                if (currentPlayerCategoryFactor == -1)
                                {
                                    if (!msgbox1)
                                    {
                                        //Checks which of player's two cards is higher and adds competing hand
                                        //In this case first card is higher
                                        if (this.deckCard[i] / 4 > this.deckCard[i + 1] / 4)
                                        {
                                            //Case when the higher card is an ace 
                                            //Different rank factor
                                            if (this.deckCard[tableCard] / 4 == 0)
                                            {
                                                currentPlayerCategoryFactor = 0;
                                                currentPlayerRankFactor = 13 + this.deckCard[i] / 4 + currentPlayerCategoryFactor * 100;
                                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                            }

                                            //Case when the first card is not an ace
                                            else
                                            {
                                                currentPlayerCategoryFactor = 0;
                                                currentPlayerRankFactor = this.deckCard[tableCard] / 4 + this.deckCard[i] / 4 + currentPlayerCategoryFactor * 100;
                                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                            }
                                        }

                                        //In this case second hand is higher
                                        else
                                        {
                                            //Second hand is an ace
                                            if (this.deckCard[tableCard] / 4 == 0)
                                            {
                                                currentPlayerCategoryFactor = 0;
                                                currentPlayerRankFactor = 13 + this.deckCard[i + 1] + currentPlayerCategoryFactor * 100;
                                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                            }

                                            //Second hand is not an ace
                                            else
                                            {
                                                currentPlayerCategoryFactor = 0;
                                                currentPlayerRankFactor = this.deckCard[tableCard] / 4 + this.deckCard[i + 1] / 4 + currentPlayerCategoryFactor * 100;
                                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                                            }
                                        }
                                    }

                                    msgbox1 = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if current player has one pair, which is formed from a player's card and a table card.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>        
        public void CheckPairFromHand(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor)
        {
            if (currentPlayerCategoryFactor >= -1)
            {
                bool msgbox = false;

                //Checks if player's two cards form a pair
                //If so adds competing pair hand
                if (this.deckCard[i] / 4 == this.deckCard[i + 1] / 4)
                {
                    if (!msgbox)
                    {
                        //Checks if the player has an ace 
                        //If so adds 13(ace rank)* 4 to rank factor
                        if (this.deckCard[i] / 4 == 0)
                        {
                            currentPlayerCategoryFactor = 1;
                            currentPlayerRankFactor = 13 * 4 + currentPlayerCategoryFactor * 100;
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                        }
                        ////If not adds highest card * 4 to rank factor
                        else
                        {
                            currentPlayerCategoryFactor = 1;
                            currentPlayerRankFactor = ((this.deckCard[i + 1] / 4) * 4) + (currentPlayerCategoryFactor * 100);
                            this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                            winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                        }
                    }
                    ////If true sets a bool value msg true
                    //This means competing hand category and rank factors are set
                    msgbox = true;
                }

                //This is for table cards(tableCard = 12-16)
                //
                for (int tableCard = 16; tableCard >= 12; tableCard--)
                {
                    //Checks if a table card and the second of the current player's two cards form a pair
                    if (this.deckCard[i + 1] / 4 == this.deckCard[tableCard] / 4)
                    {
                        //Checks if current player's two cards form a pair
                        //If current player's two cards form no pair,then adds current player competing hand as a pair
                        if (!msgbox)
                        {
                            //Checks if current player has an ace
                            //Special case for forming rank factor
                            if (this.deckCard[i + 1] / 4 == 0)
                            {
                                currentPlayerCategoryFactor = 1;
                                currentPlayerRankFactor = 13 * 4 + this.deckCard[i] / 4 + currentPlayerCategoryFactor * 100;
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                            }
                            ////If not, executes the usual case for forming rank factor
                            else
                            {
                                currentPlayerCategoryFactor = 1;
                                currentPlayerRankFactor = (((this.deckCard[i + 1] / 4) * 4) + (this.deckCard[i] / 4)) + (currentPlayerCategoryFactor * 100);
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                            }
                        }

                        msgbox = true;
                    }
                    ////Checks if a table card and the first of the current player's two cards form a pair
                    if (this.deckCard[i] / 4 == this.deckCard[tableCard] / 4)
                    {
                        //Checks if current player\s two cards form a pair
                        //If not, adds a competing hand pair with the following factors
                        if (!msgbox)
                        {
                            //Checks if current player has an ace
                            //Special case for forming rank factor
                            if (this.deckCard[i] / 4 == 0)
                            {
                                currentPlayerCategoryFactor = 1;
                                currentPlayerRankFactor = 13 * 4 + this.deckCard[i + 1] / 4 + currentPlayerCategoryFactor * 100;
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                            }
                            ////If not, this is the usual case for forming rank factor
                            else
                            {
                                currentPlayerCategoryFactor = 1;
                                currentPlayerRankFactor = (((this.deckCard[tableCard] / 4) * 4) + (this.deckCard[i + 1] / 4)) + (currentPlayerCategoryFactor * 100);
                                this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = 1 });
                                winningHand = this.competingHands.OrderByDescending(op => op.CategoryFactor).ThenByDescending(op => op.RankFactor).First();
                            }
                        }

                        msgbox = true;
                    }
                }
            }
        }
        
        /// <summary>
        /// If current player has no hand of category 1 or higher, his hand is determined by his highest card.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player hand category factor</param>
        /// <param name="currentPlayerRankFactor">TThe current player hand rank factor</param>        
        public void CheckHighCard(ref double currentPlayerCategoryFactor, ref double currentPlayerRankFactor)
        {
            //Checks if current player does not have a higher hand
            //If so, current player only competing hand is the high card hand
            if (currentPlayerCategoryFactor == -1)
            {
                //If the first of the two cards is higher, ranks are determined from it
                if (this.deckCard[i] / 4 > this.deckCard[i + 1] / 4)
                {
                    currentPlayerCategoryFactor = -1;
                    currentPlayerRankFactor = this.deckCard[i] / 4;
                    this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = -1 });
                    winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                }
                ////If the second of the two cards is higher, ranks are determined from it
                else
                {
                    currentPlayerCategoryFactor = -1;
                    currentPlayerRankFactor = this.deckCard[i + 1] / 4;
                    this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = -1 });
                    winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                }

                //Checks if you have an ace
                if (this.deckCard[i] / 4 == 0 || this.deckCard[i + 1] / 4 == 0)
                {
                    currentPlayerCategoryFactor = -1;
                    currentPlayerRankFactor = 13;
                    this.competingHands.Add(new PokerHand() { RankFactor = currentPlayerRankFactor, CategoryFactor = -1 });
                    winningHand = this.competingHands.OrderByDescending(op1 => op1.CategoryFactor).ThenByDescending(op1 => op1.RankFactor).First();
                }
            }
        }
    
        /// <summary>
        /// Checks if the current player is the only or one of the winners.
        /// If current player is the last player distributes all the winners their winnings.
        /// </summary>
        /// <param name="currentPlayerCategoryFactor">The current player's hand category factor</param>
        /// <param name="currentPlayerRankFactor">The current player's hand rank factor</param>
        /// <param name="currentText">The name of the current player</param>
        /// <param name="chips">The chips parameter</param>
        /// <param name="lastly">The last player name</param>        
       public void CheckWinners(double currentPlayerCategoryFactor, double currentPlayerRankFactor, string currentText, int chips, string lastly)
        {
            //Checks if all players have folded
            //sets lastly string to Bot 5
            if (lastly == " ")
            {
                lastly = "Bot 5";
            }

            //Makes players cards visible
            for (int j = 0; j <= 16; j++)
            {
                //await Task.Delay(5);
                if (cardToBeDealt[j].Visible)
                {
                    cardToBeDealt[j].Image = shuffledDeck[j];
                }
            }
            ////Checks if current player's category and rank factors match those of the winning hand
            //If so he is one of the winners(adds him to the list of winners)
            if (currentPlayerCategoryFactor == winningHand.CategoryFactor)
            {
                if (currentPlayerRankFactor == winningHand.RankFactor)
                {
                    winnersCount++;

                    //Depending on the category factor(the hand type),
                    //chooses a text for a message box that shows the winning hand
                    this.listOfWinners.Add(currentText);
                    if (currentPlayerCategoryFactor == -1)
                    {
                        MessageBox.Show(currentText + " High Card ");
                    }

                    if (currentPlayerCategoryFactor == 1 || currentPlayerCategoryFactor == 0)
                    {
                        MessageBox.Show(currentText + " Pair ");
                    }

                    if (currentPlayerCategoryFactor == 2)
                    {
                        MessageBox.Show(currentText + " Two Pair ");
                    }

                    if (currentPlayerCategoryFactor == 3)
                    {
                        MessageBox.Show(currentText + " Three of a Kind ");
                    }

                    if (currentPlayerCategoryFactor == 4)
                    {
                        MessageBox.Show(currentText + " Straight ");
                    }

                    if (currentPlayerCategoryFactor == 5 || currentPlayerCategoryFactor == 5.5)
                    {
                        MessageBox.Show(currentText + " Flush ");
                    }

                    if (currentPlayerCategoryFactor == 6)
                    {
                        MessageBox.Show(currentText + " Full House ");
                    }

                    if (currentPlayerCategoryFactor == 7)
                    {
                        MessageBox.Show(currentText + " Four of a Kind ");
                    }

                    if (currentPlayerCategoryFactor == 8)
                    {
                        MessageBox.Show(currentText + " Straight Flush ");
                    }

                    if (currentPlayerCategoryFactor == 9)
                    {
                        MessageBox.Show(currentText + " Royal Flush ! ");
                    }
                }
            }

            //If the search for winners has reached the last player who has not folded,
            //distributes winnings
            if (currentText == lastly)//last fixed
            {
                //If winners are more than one
                if (winnersCount > 1)
                {
                    if (this.listOfWinners.Contains("Player"))
                    {
                        this.playerChips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxPlayerChips.Text = this.playerChips.ToString();
                        //////playerPanel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 1"))
                    {
                        bot1Chips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxBot1Chips.Text = bot1Chips.ToString();
                        ////bot1Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 2"))
                    {
                        bot2Chips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxBot2Chips.Text = bot2Chips.ToString();
                        ////bot2Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 3"))
                    {
                        bot3Chips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxBot3Chips.Text = bot3Chips.ToString();
                        ////bot3Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 4"))
                    {
                        bot4Chips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxBot4Chips.Text = bot4Chips.ToString();
                        ////bot4Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 5"))
                    {
                        bot5Chips += int.Parse(textboxPot.Text) / winnersCount;
                        textboxBot5Chips.Text = bot5Chips.ToString();
                        ////bot5Panel.Visible = true;
                    }
                    ////await FinishGame(1);
                }

                //If the winner is only one 
                //textboxChips of the winner is not refreshed with his winnings
                if (winnersCount == 1)
                {
                    if (this.listOfWinners.Contains("Player"))
                    {
                        this.playerChips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        //playerPanel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 1"))
                    {
                        bot1Chips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        //bot1Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 2"))
                    {
                        bot2Chips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        ////bot2Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 3"))
                    {
                        bot3Chips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        //bot3Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 4"))
                    {
                        bot4Chips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        //bot4Panel.Visible = true;
                    }

                    if (this.listOfWinners.Contains("Bot 5"))
                    {
                        bot5Chips += int.Parse(textboxPot.Text);
                        ////await FinishGame(1);
                        //bot5Panel.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Follows raise status in the game.
        /// It is called each turn, if needed.
        /// Checks if bet is raised this turn.
        /// If so resets variables which count turns after raised turn and
        /// mark turn when bet is raised.
        /// Starts count down for raise expiration.
        /// If bet is not raised this turn, checks if raise is expired.
        /// After last community cards round(End) determines the winners 
        /// and finalizes the game.
        /// </summary>
        /// <param name="currentTurn">The current turn</param>
        /// <param name="raiseTurn">The turn of the last raise</param>
        /// <returns>The System.Threading.Tasks.Task type object</returns>        
        public async Task CheckRaise(int currentTurn, int raiseTurn)
        {
            //If bet is raised
            //Restarts turn count for calling the raise, resets IsBetRaised variable,
            //sets in which turn the bet is raised
            //resets bool variable changed to true
            if (isBetRaised)
            {
                turnCount = 0;
                isBetRaised = false;
                raisedTurn = currentTurn;
                changed = true;
            }

            //In the other scenario 
            else
            {
                //Checks if the call is reached the raiser or there was no raise
                if (turnCount >= maxLeft - 1 || !changed && turnCount == maxLeft)
                {
                    //If no raises are made before the last raiser or there was no raise after last check
                    //resets raise variables
                    if (currentTurn == raisedTurn - 1 || !changed && turnCount == maxLeft || raisedTurn == 0 && currentTurn == 5)
                    {
                        changed = false;
                        turnCount = 0;
                        this.raiseAmount = 0;
                        callAmount = 0;
                        raisedTurn = 123;
                        communityCardsRound++;//next round turning community cards face up

                        //If any player folded turn this is reflected in his status
                        if (!this.playerFoldOrAllIn)
                        {
                            labelPlayerStatus.Text = string.Empty;
                        }

                        if (!this.bot1FoldOrAllIn)
                        {
                            labelBot1Status.Text = string.Empty;
                        }

                        if (!this.bot2FoldOrAllIn)
                        {
                            labelBot2Status.Text = string.Empty;
                        }

                        if (!this.bot3FoldOrAllIn)
                        {
                            labelBot3Status.Text = string.Empty;
                        }

                        if (!this.bot4FoldOrAllIn)
                        {
                            labelBot4Status.Text = string.Empty;
                        }

                        if (!this.bot5FoldOrAllIn)
                        {
                            labelBot5Status.Text = string.Empty;
                        }
                    }
                }
            }

            //After Flop round flop cards are made visible
            if (communityCardsRound == Flop)
            {
                for (int j = 12; j <= 14; j++)
                {
                    if (cardToBeDealt[j].Image != shuffledDeck[j])
                    {
                        cardToBeDealt[j].Image = shuffledDeck[j];
                        this.playerCall = 0;                       
                        this.bot1Call = 0; 
                        this.bot2Call = 0; 
                        this.bot3Call = 0; 
                        this.bot4Call = 0; 
                        this.bot5Call = 0;

                        this.playerRaise = 0;
                        this.bot1Raise = 0;
                        this.bot2Raise = 0;
                        this.bot3Raise = 0;
                        this.bot4Raise = 0;
                        this.bot5Raise = 0;
                    }
                }
            }

            //After Turn round, turn card is made visible
            if (communityCardsRound == Turn)
            {
                for (int j = 14; j <= 15; j++)
                {
                    if (cardToBeDealt[j].Image != shuffledDeck[j])
                    {
                        cardToBeDealt[j].Image = shuffledDeck[j];
                        this.playerCall = 0; this.playerRaise = 0;
                        this.bot1Call = 0; this.bot1Raise = 0;
                        this.bot2Call = 0; this.bot2Raise = 0;
                        this.bot3Call = 0; this.bot3Raise = 0;
                        this.bot4Call = 0; this.bot4Raise = 0;
                        this.bot5Call = 0; this.bot5Raise = 0;
                    }
                }
            }

            // //After river round, river card is made visible
            if (communityCardsRound == River)
            {
                for (int j = 15; j <= 16; j++)
                {
                    if (cardToBeDealt[j].Image != shuffledDeck[j])
                    {
                        cardToBeDealt[j].Image = shuffledDeck[j];
                        this.playerCall = 0; this.playerRaise = 0;
                        this.bot1Call = 0; this.bot1Raise = 0;
                        this.bot2Call = 0; this.bot2Raise = 0;
                        this.bot3Call = 0; this.bot3Raise = 0;
                        this.bot4Call = 0; this.bot4Raise = 0;
                        this.bot5Call = 0; this.bot5Raise = 0;
                    }
                }
            }

            //If no player has folded and each player has checked after River turn,
            //game winner is determined
            if (communityCardsRound == End && maxLeft == 6)
            {
                string lastPlayerNotFolded = "qwerty";
                if (!labelPlayerStatus.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Player";
                    DeterminePlayerCurrentBestHand(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
                }

                if (!labelBot1Status.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Bot 1";
                    DeterminePlayerCurrentBestHand(2, 3, "Bot 1", ref this.bot1HandCategoryFactor, ref this.bot1HandRankFactor, this.bot1FoldOrAllIn);
                }

                if (!labelBot2Status.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Bot 2";
                    DeterminePlayerCurrentBestHand(4, 5, "Bot 2", ref this.bot2HandCategoryFactor, ref this.bot2HandRankFactor, this.bot2FoldOrAllIn);
                }

                if (!labelBot3Status.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Bot 3";
                    DeterminePlayerCurrentBestHand(6, 7, "Bot 3", ref this.bot3HandCategoryFactor, ref this.bot3HandRankFactor, this.bot3FoldOrAllIn);
                }

                if (!labelBot4Status.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Bot 4";
                    DeterminePlayerCurrentBestHand(8, 9, "Bot 4", ref this.bot4HandCategoryFactor, ref this.bot4HandRankFactor, this.bot4FoldOrAllIn);
                }

                if (!labelBot5Status.Text.Contains("Fold"))
                {
                    lastPlayerNotFolded = "Bot 5";
                    DeterminePlayerCurrentBestHand(10, 11, "Bot 5", ref this.bot5HandCategoryFactor, ref this.bot5HandRankFactor, this.bot5FoldOrAllIn);
                }

                CheckWinners(this.playerHandCategoryFactor, this.playerHandRankFactor, "Player", this.playerChips, lastPlayerNotFolded);//is human player a winner?
                CheckWinners(this.bot1HandCategoryFactor, this.bot1HandRankFactor, "Bot 1", bot1Chips, lastPlayerNotFolded);//is bot1 a winner?
                CheckWinners(this.bot2HandCategoryFactor, this.bot2HandRankFactor, "Bot 2", bot2Chips, lastPlayerNotFolded);//is bot2 a winner?
                CheckWinners(this.bot3HandCategoryFactor, this.bot3HandRankFactor, "Bot 3", bot3Chips, lastPlayerNotFolded);//is bot3 a winner?
                CheckWinners(this.bot4HandCategoryFactor, this.bot4HandRankFactor, "Bot 4", bot4Chips, lastPlayerNotFolded);//is bot4 a winner?
                CheckWinners(this.bot5HandCategoryFactor, this.bot5HandRankFactor, "Bot 5", bot5Chips, lastPlayerNotFolded);//is bot5 a winner?

                restart = true;//new game is ready for starting

                //If human player has no chips, he is given the options to add more
                if (this.playerChips <= 0)
                {
                    AddChips addChipsOption = new AddChips();
                    addChipsOption.ShowDialog();

                    //If human player adds chips, the same amount is added to he bots accounts
                    if (addChipsOption.a != 0)
                    {
                        this.playerChips = addChipsOption.a;
                        bot1Chips += addChipsOption.a;
                        bot2Chips += addChipsOption.a;
                        bot3Chips += addChipsOption.a;
                        bot4Chips += addChipsOption.a;
                        bot5Chips += addChipsOption.a;

                        //resets human player variables for the next game
                        this.playerFoldOrAllIn = false;
                        this.isPlayerTurn = true;
                        buttonRaise.Enabled = true;
                        buttonFold.Enabled = true;
                        buttonCheck.Enabled = true;
                        buttonRaise.Text = "Raise";
                    }
                }

                //resets variables and controls for the next game
                this.playerPanel.Visible = false;
                this.bot1Panel.Visible = false;
                this.bot2Panel.Visible = false;
                this.bot3Panel.Visible = false;
                this.bot4Panel.Visible = false;
                this.bot5Panel.Visible = false;

                this.playerCall = 0;
                this.bot1Call = 0;
                this.bot2Call = 0;
                this.bot3Call = 0;
                this.bot4Call = 0;
                this.bot5Call = 0;

                this.playerRaise = 0;
                this.bot1Raise = 0;
                this.bot2Raise = 0;
                this.bot3Raise = 0;
                this.bot4Raise = 0;
                this.bot5Raise = 0;

                this.isPlayerTurn = true;
                this.playerFoldOrAllIn = false;
                this.bot1FoldOrAllIn = false;
                this.bot2FoldOrAllIn = false;
                this.bot3FoldOrAllIn = false;
                this.bot4FoldOrAllIn = false;
                this.bot5FoldOrAllIn = false;

                this.playerHandRankFactor = 0;
                this.bot1HandRankFactor = 0;
                this.bot2HandRankFactor = 0;
                this.bot3HandRankFactor = 0;
                this.bot4HandRankFactor = 0;
                this.bot5HandRankFactor = 0;

                this.playerHandCategoryFactor = -1;
                this.bot1HandCategoryFactor = -1;
                this.bot2HandCategoryFactor = -1;
                this.bot3HandCategoryFactor = -1;
                this.bot4HandCategoryFactor = -1;
                this.bot5HandCategoryFactor = -1;

                last = 0;
                callAmount = this.bigBlind;
                this.raiseAmount = 0;

                this.imgCardsLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
                foldRegister.Clear();
                allInPlayers.Clear();
                this.listOfWinners.Clear();
                this.competingHands.Clear();

                communityCardsRound = 0;

                secondaryFactor = 0;

                winnersCount = 0;
                winningHand.CategoryFactor = 0;
                winningHand.RankFactor = 0;

                //Removes card controls
                for (int os = 0; os < MaximumCardsToBeDealt; os++)
                {
                    cardToBeDealt[os].Image = null;
                    cardToBeDealt[os].Invalidate();
                    cardToBeDealt[os].Visible = false;
                }

                textboxPot.Text = "0";//clears pot
                labelPlayerStatus.Text = string.Empty;//resets human player's status

                //Shuffles cards
                await ShuffleCards();
                await Turns();
            }
        }
 
        /// <summary>
        /// Adjusts player's raise and call statistics.
        /// There are 2 options for 2 steps:
        /// option 1 for step 1, 
        /// option 2 for step 2.
        /// In step 1 adjustments are made based on the choice the player
        /// has made the previous turn, if there was a previous turn.
        /// In step 2 adjustments are made based on current game statistics.
        /// Adjustments are maid in the following order:step 1, then step 2.
        /// </summary>
        /// <param name="currentPlayerStatus">The status text for the current player</param>
        /// <param name="currentPlayerCall">The current player' call amount</param>
        /// <param name="currentPlayerRaise">The current player's raise</param>
        /// <param name="options">The options parameter</param>        
        public void FixCall(Label currentPlayerStatus, ref int currentPlayerCall, ref int currentPlayerRaise, int options)
        {
            //Checks if all possibilities to bet after River round
            //are checked
            if (communityCardsRound != End)
            {
                //This check is made just before a player can 
                //click his buttons
                if (options == 1)
                {
                    //Checks if this player has raised the previous turn
                    //If so, changes his raise amount to the status value
                    if (currentPlayerStatus.Text.Contains("Raise"))
                    {
                        var changeRaise = currentPlayerStatus.Text.Substring(6);
                        currentPlayerRaise = int.Parse(changeRaise);
                    }
                    ////Checks if this player has called the previous turn
                    //If so, changes his call amount to the status value
                    if (currentPlayerStatus.Text.Contains("Call"))
                    {
                        var changeCall = currentPlayerStatus.Text.Substring(5);
                        currentPlayerCall = int.Parse(changeCall);
                    }
                    ////Checks if this player has checked the previous turn
                    //If so, nulls call and raise amount
                    if (currentPlayerStatus.Text.Contains("Check"))
                    {
                        currentPlayerRaise = 0;
                        currentPlayerCall = 0;
                    }
                }

                //This check is made after the first one,
                //(for the human player after timer start)
                if (options == 2)
                {
                    //If the game is raised adjusts the call amount
                    //for the currentPlayerCategoryFactor player 
                    if (currentPlayerRaise < this.raiseAmount)
                    {
                        callAmount = Convert.ToInt32(this.raiseAmount) - currentPlayerRaise;
                    }

                    //Checks if the player has called the previous turn 
                    //and if so subtracts it from the currentPlayerCategoryFactor call amount
                    if (currentPlayerCall != callAmount || currentPlayerCall <= callAmount)
                    {
                        callAmount = callAmount - currentPlayerCall;
                    }

                    //Checks if currentPlayerCategoryFactor player has raised previous turn 
                    //and the same raise reaches him.
                    //If so shows some text.
                    if (currentPlayerRaise == this.raiseAmount && this.raiseAmount > 0)
                    {
                        callAmount = 0;
                        buttonCall.Enabled = false;
                        buttonCall.Text = "Callisfuckedup";
                    }
                }
            }
        }

        /// <summary>
        /// Checks if there are two or more players left,
        /// who haven't folded or made an all in.
        /// Makes a check for all in or fold for each remaining player.
        /// If all players have made an all in, waits for the final community card round and determines winners.
        /// If some players have folded and 2 or more players are all in,
        /// waits for the final community card round and determines winners.
        /// If only one player has not folded gives him the winnings.
        /// </summary>
        /// <returns></returns>        
        public async Task AllIn()
        {
            //Checks if the human player has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            if (this.playerChips <= 0 && !addedToAllInPlayers)
            {
                if (labelPlayerStatus.Text.Contains("Raise"))
                {
                    allInPlayers.Add(this.playerChips);
                    addedToAllInPlayers = true;
                }

                if (labelPlayerStatus.Text.Contains("Call"))
                {
                    allInPlayers.Add(this.playerChips);
                    addedToAllInPlayers = true;
                }
            }

            //Checks if bot1 has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            addedToAllInPlayers = false;
            if (bot1Chips <= 0 && !this.bot1FoldOrAllIn)
            {
                if (!addedToAllInPlayers)
                {
                    allInPlayers.Add(bot1Chips);
                    addedToAllInPlayers = true;
                }

                addedToAllInPlayers = false;
            }

            //Checks if bot2 has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            if (bot2Chips <= 0 && !this.bot2FoldOrAllIn)
            {
                if (!addedToAllInPlayers)
                {
                    allInPlayers.Add(bot2Chips);
                    addedToAllInPlayers = true;
                }

                addedToAllInPlayers = false;
            }

            //Checks if bot3 has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            if (bot3Chips <= 0 && !this.bot3FoldOrAllIn)
            {
                if (!addedToAllInPlayers)
                {
                    allInPlayers.Add(bot3Chips);
                    addedToAllInPlayers = true;
                }

                addedToAllInPlayers = false;
            }

            //Checks if bot4 has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            if (bot4Chips <= 0 && !this.bot4FoldOrAllIn)
            {
                if (!addedToAllInPlayers)
                {
                    allInPlayers.Add(bot4Chips);
                    addedToAllInPlayers = true;
                }

                addedToAllInPlayers = false;
            }

            //Checks if bot5 has used his last chips for a raise or a call
            //If so adds him to a list of allInners
            if (bot5Chips <= 0 && !this.bot5FoldOrAllIn)
            {
                if (!addedToAllInPlayers)
                {
                    allInPlayers.Add(bot5Chips);
                    addedToAllInPlayers = true;
                }
            }

            //If all left players are all In
            //determines the winners and finishes the game
            if (allInPlayers.ToArray().Length == maxLeft)
            {
                await FinishGame(2);
            }

            //If not, clears the list of all in players
            else
            {
                allInPlayers.Clear();
            }

            //Checks who and how many from the remaining players folds turn
            var abc = foldRegister.Count(x => x == false);

            //If only one player has not folded this turn
            //he is the winner
            if (abc == 1)
            {
                int index = foldRegister.IndexOf(false);

                //human player is the winner
                if (index == 0)
                {
                    this.playerChips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = this.playerChips.ToString();
                    this.playerPanel.Visible = true;
                    MessageBox.Show("Player Wins");
                }

                //bot1 is the winner
                if (index == 1)
                {
                    bot1Chips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = bot1Chips.ToString();
                    this.bot1Panel.Visible = true;
                    MessageBox.Show("Bot 1 Wins");
                }
                ////bot2 is the winner
                if (index == 2)
                {
                    bot2Chips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = bot2Chips.ToString();
                    this.bot2Panel.Visible = true;
                    MessageBox.Show("Bot 2 Wins");
                }

                //bot3 is the winner
                if (index == 3)
                {
                    bot3Chips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = bot3Chips.ToString();
                    this.bot3Panel.Visible = true;
                    MessageBox.Show("Bot 3 Wins");
                }

                //bot4 is the winner
                if (index == 4)
                {
                    bot4Chips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = bot4Chips.ToString();
                    this.bot4Panel.Visible = true;
                    MessageBox.Show("Bot 4 Wins");
                }

                //bot5 is the winner
                if (index == 5)
                {
                    bot5Chips += int.Parse(textboxPot.Text);
                    textboxPlayerChips.Text = bot5Chips.ToString();
                    this.bot5Panel.Visible = true;
                    MessageBox.Show("Bot 5 Wins");
                }

                //Makes card controls not visible and finishes the game
                for (int j = 0; j <= 16; j++)
                {
                    cardToBeDealt[j].Visible = false;
                }

                await FinishGame(1);
            }

            addedToAllInPlayers = false;

            //If 2 or more players haven't folded
            //fixes winners and finishes the game
            //If not all community cards are turned face up,
            //waits for the end turn when winning hand is determined
            if (abc < 6 && abc > 1 && communityCardsRound >= End)
            {
                await FinishGame(2);
            }
        }
    
        /// <summary>
        /// Fix game winners.
        /// Reinitializes variables, disables players panels, 
        /// clears lists and text messages .
        /// </summary>
        /// <param name="n">The n parameter</param>
        /// <returns>The System.Threading.Tasks.Task type object</returns>        
        public async Task FinishGame(int n)
        {
            //For a given option n = 2,fixes winners 
            if (n == 2)
            {
                FixWinners();
            }

            //resets variables and controls
            this.playerPanel.Visible = false;
            this.bot1Panel.Visible = false;
            this.bot2Panel.Visible = false;
            this.bot3Panel.Visible = false;
            this.bot4Panel.Visible = false;
            this.bot5Panel.Visible = false;

            callAmount = this.bigBlind;
            this.raiseAmount = 0;
            this.raiseAmount = 0;
            foldedPlayers = 5;
            secondaryFactor = 0;
            communityCardsRound = 0;

            this.playerHandRankFactor = 0;
            this.bot1HandRankFactor = 0;
            this.bot2HandRankFactor = 0;
            this.bot3HandRankFactor = 0;
            this.bot4HandRankFactor = 0;
            this.bot5HandRankFactor = 0;

            this.playerHandCategoryFactor = -1;
            this.bot1HandCategoryFactor = -1;
            this.bot2HandCategoryFactor = -1;
            this.bot3HandCategoryFactor = -1;
            this.bot4HandCategoryFactor = -1;
            this.bot5HandCategoryFactor = -1;

            this.isPlayerTurn = true;
            this.isBot1Turn = false;
            this.isBot2Turn = false;
            this.isBot3Turn = false;
            this.isBot4Turn = false;
            this.isBot5Turn = false;

            this.playerFoldOrAllIn = false;
            this.bot1FoldOrAllIn = false;
            this.bot2FoldOrAllIn = false;
            this.bot3FoldOrAllIn = false;
            this.bot4FoldOrAllIn = false;
            this.bot5FoldOrAllIn = false;

            this.isPlayerFolded = false;
            this.isBot1Folded = false;
            this.isBot2Folded = false;
            this.isBot3Folded = false;
            this.isBot4Folded = false;
            this.isBot5Folded = false;

            restart = false;
            isBetRaised = false;

            this.playerCall = 0;
            this.bot1Call = 0;
            this.bot2Call = 0;
            this.bot3Call = 0;
            this.bot4Call = 0;
            this.bot5Call = 0;

            this.playerRaise = 0;
            this.bot1Raise = 0;
            this.bot2Raise = 0;
            this.bot3Raise = 0;
            this.bot4Raise = 0;
            this.bot5Raise = 0;

            windowHeight = 0;
            windowWidth = 0;

            winnersCount = 0;
            maxLeft = 6;
            last = 123;
            raisedTurn = 1;

            foldRegister.Clear();
            this.listOfWinners.Clear();
            allInPlayers.Clear();
            this.competingHands.Clear();

            winningHand.CategoryFactor = 0;
            winningHand.RankFactor = 0;

            textboxPot.Text = "0";

            playerTime = 60;
            up = 10000000;
            turnCount = 0;

            labelPlayerStatus.Text = string.Empty;
            labelBot1Status.Text = string.Empty;
            labelBot2Status.Text = string.Empty;
            labelBot3Status.Text = string.Empty;
            labelBot4Status.Text = string.Empty;
            labelBot5Status.Text = string.Empty;

            //If human player has no more chips.
            //pops the option to add more
            //The same amount is added for all the players
            if (this.playerChips <= 0)
            {
                AddChips addChipsOption = new AddChips();
                addChipsOption.ShowDialog();
                if (addChipsOption.a != 0)
                {
                    this.playerChips = addChipsOption.a;
                    bot1Chips += addChipsOption.a;
                    bot2Chips += addChipsOption.a;
                    bot3Chips += addChipsOption.a;
                    bot4Chips += addChipsOption.a;
                    bot5Chips += addChipsOption.a;
                    this.playerFoldOrAllIn = false;
                    this.isPlayerTurn = true;
                    buttonRaise.Enabled = true;
                    buttonFold.Enabled = true;
                    buttonCheck.Enabled = true;
                    buttonRaise.Text = "Raise";
                }
            }

            //Prepares the shuffledDeck for new shuffle
            //Resets all card controls
            this.imgCardsLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
            for (int os = 0; os < MaximumCardsToBeDealt; os++)
            {
                cardToBeDealt[os].Image = null;
                cardToBeDealt[os].Invalidate();
                cardToBeDealt[os].Visible = false;
            }

            await ShuffleCards();
            ////await Turns();
        }

        /// <summary>
        /// Determines game winners.
        /// </summary>        
        public void FixWinners()
        {
            //Resets winning hand factors and competing hands
            this.competingHands.Clear();
            winningHand.CategoryFactor = 0;
            winningHand.RankFactor = 0;

            //makes the same procedure as in CheckRaise
            string lastPlayerNotFolded = "qwerty";
            if (!labelPlayerStatus.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Player";
                DeterminePlayerCurrentBestHand(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
            }

            if (!labelBot1Status.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Bot 1";
                DeterminePlayerCurrentBestHand(2, 3, "Bot 1", ref this.bot1HandCategoryFactor, ref this.bot1HandRankFactor, this.bot1FoldOrAllIn);
            }

            if (!labelBot2Status.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Bot 2";
                DeterminePlayerCurrentBestHand(4, 5, "Bot 2", ref this.bot2HandCategoryFactor, ref this.bot2HandRankFactor, this.bot2FoldOrAllIn);
            }

            if (!labelBot3Status.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Bot 3";
                DeterminePlayerCurrentBestHand(6, 7, "Bot 3", ref this.bot3HandCategoryFactor, ref this.bot3HandRankFactor, this.bot3FoldOrAllIn);
            }

            if (!labelBot4Status.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Bot 4";
                DeterminePlayerCurrentBestHand(8, 9, "Bot 4", ref this.bot4HandCategoryFactor, ref this.bot4HandRankFactor, this.bot4FoldOrAllIn);
            }

            if (!labelBot5Status.Text.Contains("Fold"))
            {
                lastPlayerNotFolded = "Bot 5";
                DeterminePlayerCurrentBestHand(10, 11, "Bot 5", ref this.bot5HandCategoryFactor, ref this.bot5HandRankFactor, this.bot5FoldOrAllIn);
            }

            CheckWinners(this.playerHandCategoryFactor, this.playerHandRankFactor, "Player", this.playerChips, lastPlayerNotFolded);
            CheckWinners(this.bot1HandCategoryFactor, this.bot1HandRankFactor, "Bot 1", bot1Chips, lastPlayerNotFolded);
            CheckWinners(this.bot2HandCategoryFactor, this.bot2HandRankFactor, "Bot 2", bot2Chips, lastPlayerNotFolded);
            CheckWinners(this.bot3HandCategoryFactor, this.bot3HandRankFactor, "Bot 3", bot3Chips, lastPlayerNotFolded);
            CheckWinners(this.bot4HandCategoryFactor, this.bot4HandRankFactor, "Bot 4", bot4Chips, lastPlayerNotFolded);
            CheckWinners(this.bot5HandCategoryFactor, this.bot5HandRankFactor, "Bot 5", bot5Chips, lastPlayerNotFolded);
        }
  
        /// <summary>
        /// This is the AIEngine for bot players.
        /// Generates a choice for every bot, every turn 
        /// (if the bot has not folded),
        /// after refreshing his category and rank 
        /// factor using bot's best hand.
        /// The choice is based on category and rank factor,
        /// and the choice maker that is used.
        /// </summary>
        /// <param name="card1">The bot's first dealt card</param>
        /// <param name="card2">The bot's second dealt card</param>
        /// <param name="botChips">Current bot's chips</param>
        /// <param name="botTurn">Parameter, that indicates if it is current bot's turn</param>
        /// <param name="botFoldsTurn">Parameter, that indicates current player has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand rank factor</param>
        /// <param name="botHandCategoryFactor">The bot's hand category factor</param>        
        public void AIEngine(int card1, int card2, ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor, double botHandCategoryFactor)
        {
            //Checks if bot folds this turn
            //If not makes a check for each possible hand the bot can have
            if (!botFoldsTurn)
            {
                if (botHandCategoryFactor == -1)
                {
                    HighCard(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor);
                }

                if (botHandCategoryFactor == 0)
                {
                    PairTable(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor);
                }

                if (botHandCategoryFactor == 1)
                {
                    PairHand(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor);
                }

                if (botHandCategoryFactor == 2)
                {
                    TwoPair(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor);
                }

                if (botHandCategoryFactor == 3)
                {
                    ThreeOfAKind(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }

                if (botHandCategoryFactor == 4)
                {
                    Straight(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }

                if (botHandCategoryFactor == 5 || botHandCategoryFactor == 5.5)
                {
                    Flush(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }

                if (botHandCategoryFactor == 6)
                {
                    FullHouse(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }

                if (botHandCategoryFactor == 7)
                {
                    FourOfAKind(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }

                if (botHandCategoryFactor == 8 || botHandCategoryFactor == 9)
                {
                    StraightFlush(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, botHandRankFactor);
                }
            }

            //If bot folds turn(all in or folds) his card controls are  disabled
            if (botFoldsTurn)
            {
                cardToBeDealt[card1].Visible = false;
                cardToBeDealt[card2].Visible = false;
            }
        }
   
        /// <summary>
        /// Bot player makes a choice for this turn if it has a HighCard hand.
        /// Uses HP choice maker.
        /// Uses high card category factor, not the rank factor
        /// (though it is in the parameters list).
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current bot's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>        
        public void HighCard(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, double botHandRankFactor)
        {
            HP(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor, 20, 25);
        }
        
        /// <summary>
        /// Bot player makes a choice for this turn if he has a pair hand from table.
        /// Uses HP choice maker.
        /// Uses high card category factor, not the rank factor
        /// (though it is in the parameters list).
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>        
        public void PairTable(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, double botHandRankFactor)
        {
            HP(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botHandRankFactor, 16, 25);
        }
 
        /// <summary>
        /// Bot player makes a choice for this turn if he has a PairHand and
        /// it is from a player's card and a table card or both player's cards.
        /// Uses PH choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>        
        public void PairHand(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, double botHandRankFactor)
        {
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(10, 16);
            int raiseParameter = parameterGenerator.Next(10, 13);
            if (botHandRankFactor <= 199 && botHandRankFactor >= 140)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 6, raiseParameter);
            }

            if (botHandRankFactor <= 139 && botHandRankFactor >= 128)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 7, raiseParameter);
            }

            if (botHandRankFactor < 128 && botHandRankFactor >= 101)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 9, raiseParameter);
            }
        }
      
        /// <summary>
        /// Bot player makes a choice for this turn if he has a TwoPair hand.
        /// Uses PH choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>       
        public void TwoPair(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(6, 11);
            int raiseParameter = parameterGenerator.Next(6, 11);

            //Three cases for making a choice
            //based on bot rank factor
            if (botHandRankFactor <= 290 && botHandRankFactor >= 246)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 3, raiseParameter);
            }

            if (botHandRankFactor <= 244 && botHandRankFactor >= 234)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 4, raiseParameter);
            }

            if (botHandRankFactor < 234 && botHandRankFactor >= 201)
            {
                PH(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, callParameter, 4, raiseParameter);
            }
        }

        /// <summary>
        /// Bot player makes a choice for this turn if he has ThreeOfAkind.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>          
        public void ThreeOfAKind(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(3, 7);
            int raiseParameter = parameterGenerator.Next(4, 8);

            //Three cases for making a choice
            //based on bot rank factor
            if (botHandRankFactor <= 390 && botHandRankFactor >= 330)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }

            if (botHandRankFactor <= 327 && botHandRankFactor >= 321)//10  8
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }

            if (botHandRankFactor < 321 && botHandRankFactor >= 303)//7 2
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }
        }

        /// <summary>
        /// Bot player makes a choice for this turn if he has a Straight.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>     
        public void Straight(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(3, 6);
            int raiseParameter = parameterGenerator.Next(3, 8);

            //Three cases for making a choice
            //based on bot rank factor
            if (botHandRankFactor <= 480 && botHandRankFactor >= 410)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }

            if (botHandRankFactor <= 409 && botHandRankFactor >= 407)//10  8
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }

            if (botHandRankFactor < 407 && botHandRankFactor >= 404)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }
        }

        /// <summary>
        /// Bot player makes a choice for this turn if he has a Flush.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>    
        public void Flush(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(2, 6);
            int raiseParameter = parameterGenerator.Next(3, 7);
            Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
        }

        /// <summary>
        /// Bot player makes a choice for this turn if he has a FullHouse.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>       
        public void FullHouse(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(1, 5);
            int raiseParameter = parameterGenerator.Next(2, 6);

            //Checks if bot rank Factor is proper rank factor number for this category
            if (botHandRankFactor <= 626 && botHandRankFactor >= 620)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }

            if (botHandRankFactor < 620 && botHandRankFactor >= 602)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }
        }
        
        /// <summary>
        /// Bot player makes a choice for this turn if he has Four of a kind.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>       
        public void FourOfAKind(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(1, 4);
            int raiseParameter = parameterGenerator.Next(2, 5);

            //Checks if bot rank Factor is proper rank factor number for this category
            if (botHandRankFactor <= 752 && botHandRankFactor >= 704)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }
        }
 
        /// <summary>
        /// Bot player makes a choice for this turn if he has a StraightFlush.
        /// Uses Smooth choice maker.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The name of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param>        
        public void StraightFlush(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int botName, double botHandRankFactor)
        {
            //Creates a generator for parameters to use in BotChoiceFormula formula for raise calculation and call calculation
            Random parameterGenerator = new Random();
            int callParameter = parameterGenerator.Next(1, 3);
            int raiseParameter = parameterGenerator.Next(1, 3);

            //Checks if bot rank Factor is proper rank factor number for this category
            if (botHandRankFactor <= 913 && botHandRankFactor >= 804)
            {
                Smooth(ref botChips, ref botTurn, ref botFoldsTurn, botStatus, botName, callParameter, raiseParameter);
            }
        }

        /// <summary>
        /// If bot folds ,variables connected with fold are set accordingly.
        /// </summary>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        public void Fold(ref bool botTurn, ref bool botFoldsTurn, Label botStatus)
        {
            isBetRaised = false;
            botStatus.Text = "Fold";
            botTurn = false;
            botFoldsTurn = true;
        }

        /// <summary>
        /// If bot checks,bot  status,bot turn  and isBetRaised variables are set  accordingly.
        /// </summary>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botStatus">The status text of the bot</param>     
        public void Check(ref bool botTurn, Label botStatus)
        {
            botStatus.Text = "Check";
            botTurn = false;
            isBetRaised = false;
        }

        /// <summary>
        /// If bot calls, variables connected with call are set accordingly.
        /// </summary>
        /// <param name="botChips">Current bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botStatus">The status text of the bot</param>          
        public void Call(ref int botChips, ref bool botTurn, Label botStatus)
        {
            isBetRaised = false;
            botTurn = false;
            botChips -= callAmount;
            botStatus.Text = "Call " + callAmount;
            textboxPot.Text = (int.Parse(textboxPot.Text) + callAmount).ToString();
        }

        /// Bot raises, variables connected with raise are set accordingly. 
        /// <summary>
        /// The Raised method
        /// </summary>
        /// <param name="botChips">The botChips parameter</param>
        /// <param name="botTurn">The botTurn parameter</param>
        /// <param name="botStatus">The botStatus parameter</param>        
        public void Raised(ref int botChips, ref bool botTurn, Label botStatus)
        {
            botChips -= Convert.ToInt32(this.raiseAmount);
            botStatus.Text = "Raise " + this.raiseAmount;
            textboxPot.Text = (int.Parse(textboxPot.Text) + Convert.ToInt32(this.raiseAmount)).ToString();
            callAmount = Convert.ToInt32(this.raiseAmount);
            isBetRaised = true;
            botTurn = false;
        }

        /// <summary>
        /// Creates a choice generator for bots.
        /// This generator is used when bot has only high card or table pair hand.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botHandRankFactor">The bot's hand category factor</param> 
        /// <param name="n">The n parameter</param>
        /// <param name="n1">The n1 parameter</param>        
        public void HP(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, double botHandRankFactor, int n, int n1)
        {
            //Creates a 4 choices generator
            Random optionsGenerator = new Random();

            //Generates a random choice
            int randChoice = optionsGenerator.Next(1, 4);

            //If bot needs not to call, he checks
            if (callAmount <= 0)
            {
                Check(ref botTurn, botStatus);
            }

            //If bot needs to call or raise
            //Uses randChoice to pick up implementation of the formula to use for making his choice
            if (callAmount > 0)
            {
                //With this randChoice formula uses number n for choosing between call and fold
                if (randChoice == 1)
                {
                    //Calls
                    if (callAmount <= BotChoiceFormula(botChips, n))
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }
                    ////Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }

                //With this randChoice formula uses number n1 for choosing between call and fold
                if (randChoice == 2)
                {
                    //Calls
                    if (callAmount <= BotChoiceFormula(botChips, n1))
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }
                        ////Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }
            }

            //With this randChoice,BotChoiceFormula formula uses number n for choosing between raise and fold
            if (randChoice == 3)
            {
                //If he needs not to call a raise or raise
                if (this.raiseAmount == 0)
                {
                    this.raiseAmount = callAmount * 2;
                    Raised(ref botChips, ref botTurn, botStatus);
                }
                ////if he needs to call a raise or raise
                //uses formula with number n to make his choice
                else
                {
                    //Raises
                    if (this.raiseAmount <= BotChoiceFormula(botChips, n))
                    {
                        this.raiseAmount = callAmount * 2;
                        Raised(ref botChips, ref botTurn, botStatus);
                    }
                    ////Folds
                    else
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }
                }
            }

            //If bot is out of chips he folds turn(he has made an all in)
            if (botChips <= 0)
            {
                botFoldsTurn = true;
            }
        }
  
        /// <summary>
        /// Choice maker for bots if they have a hand which is a pair or two pairs.
        /// Uses BotChoiceFormula formula.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFoldsTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="n">The n parameter</param>
        /// <param name="n1">The n1 parameter</param>
        /// <param name="randGenerator">The randGenerator parameter</param>        
        public void PH(ref int botChips, ref bool botTurn, ref bool botFoldsTurn, Label botStatus, int n, int n1, int randGenerator)
        {
            //Creates a choice generator and picks one choice
            Random optionsGenerator = new Random();
            int randChoice = optionsGenerator.Next(1, 3); //randChoice is used in formula BotChoiceFormula

            //If 3 community cards are turned face up, etc. only Flop round is made
            if (communityCardsRound < Turn)
            {
                //Checks if he needs not to call or raise
                if (callAmount <= 0)
                {
                    Check(ref botTurn, botStatus);
                }

                //If he needs to call or raise 
                if (callAmount > 0)
                {
                    //Folds if call amount is not less than the number estimated using BotChoiceFormula formula with n1
                    if (callAmount >= BotChoiceFormula(botChips, n1))
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }

                    //Folds if raise amount is bigger than the number estimated using BotChoiceFormula formula with n
                    if (this.raiseAmount > BotChoiceFormula(botChips, n))
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }

                    //Checks if bot has not folded or made an all in
                    if (!botFoldsTurn)
                    {
                        //Calls if call amount is not less than the number estimated using BotChoiceFormula formula with n
                        //and callAmount is not bigger than the number estimated using BotChoiceFormula formula with n divided by two
                        if (callAmount >= BotChoiceFormula(botChips, n) && callAmount <= BotChoiceFormula(botChips, n1))
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }

                        //Calls if raise amount is not bigger than the number estimated using BotChoiceFormula formula with n
                        //raise amount is not less than the number estimated using BotChoiceFormula formula with n divided by two
                        if (this.raiseAmount <= BotChoiceFormula(botChips, n) && this.raiseAmount >= (BotChoiceFormula(botChips, n)) / 2)
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }

                        //Raises if raise amount is not bigger than the number estimated using BotChoiceFormula formula with n divided by two
                        if (this.raiseAmount <= (BotChoiceFormula(botChips, n)) / 2)
                        {
                            //If there was a previous raise
                            if (this.raiseAmount > 0)
                            {
                                this.raiseAmount = BotChoiceFormula(botChips, n);
                                Raised(ref botChips, ref botTurn, botStatus);
                            }
                                ////If there was no previous raise
                            else 
                            {
                                this.raiseAmount = callAmount * 2;
                                Raised(ref botChips, ref botTurn, botStatus);
                            }
                        }
                    }
                }
            }

            //If four or five cards are turned face up(Turn,River or End)
            if (communityCardsRound >= Turn)
            {
                //If he needs to call or raise
                if (callAmount > 0)
                {
                    //Folds when callAmount is no less than the number calculated via BotChoiceFormula using n1 - randChoice
                    if (callAmount >= BotChoiceFormula(botChips, n1 - randChoice))
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }

                    //Folds when callAmount is bigger than the number calculated via BotChoiceFormula using n - randChoice
                    if (this.raiseAmount > BotChoiceFormula(botChips, n - randChoice))
                    {
                        Fold(ref botTurn, ref botFoldsTurn, botStatus);
                    }

                    //If bot has not folded
                    if (!botFoldsTurn)
                    {
                        //Calls when callAmount is not less than the number calculated via BotChoiceFormula using n - randChoice
                        //and callAmount is not bigger than the number calculated via BotChoiceFormula using n1 - randChoice
                        if (callAmount >= BotChoiceFormula(botChips, n - randChoice) && callAmount <= BotChoiceFormula(botChips, n1 - randChoice))
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }

                        //Calls when raiseAmount is not bigger than the number calculated via BotChoiceFormula using n - randChoice
                        //and raiseAmount is not less than the number calculated via BotChoiceFormula using n - randChoice divided by two
                        if (this.raiseAmount <= BotChoiceFormula(botChips, n - randChoice) && this.raiseAmount >= (BotChoiceFormula(botChips, n - randChoice)) / 2)
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }

                        //Raises when raiseAmount is not bigger than the number calculated via BotChoiceFormula using n - randChoice
                        if (this.raiseAmount <= (BotChoiceFormula(botChips, n - randChoice)) / 2)
                        {
                            //If raiseAmount is > 0
                            if (this.raiseAmount > 0)
                            {
                                this.raiseAmount = BotChoiceFormula(botChips, n - randChoice);
                                Raised(ref botChips, ref botTurn, botStatus);
                            }
                                ////If raiseAmount == 0
                            else
                            {
                                this.raiseAmount = callAmount * 2;
                                Raised(ref botChips, ref botTurn, botStatus);
                            }
                        }
                    }
                }

                //if bot needs not to raise or call
                //raises with an amount calculated using Round randGenerator and randChoice
                if (callAmount <= 0)
                {
                    this.raiseAmount = BotChoiceFormula(botChips, randGenerator - randChoice);
                    Raised(ref botChips, ref botTurn, botStatus);
                }
            }

            //
            if (botChips <= 0)
            {
                botFoldsTurn = true;
            }
        }

        /// <summary>
        /// Choice maker for bots with a hand three of a kind or higher.
        /// Uses BotChoiceFormula formula.
        /// </summary>
        /// <param name="botChips">Bot's chips</param>
        /// <param name="botTurn">Parameter that indicates if it's current player's turn</param>
        /// <param name="botFTurn">Parameter that indicates if current bot has folded or is all in</param>
        /// <param name="botStatus">The status text of the bot</param>
        /// <param name="botName">The current bot's name</param>
        /// <param name="n">The n parameter</param>
        /// <param name="randGenerator">The randGenerator parameter</param>        
        public void Smooth(ref int botChips, ref bool botTurn, ref bool botFTurn, Label botStatus, int botName, int n, int randGenerator)
        {
            //Creates an optionGenerator
            //Chooses one of the options
            Random optionsGenerator = new Random();
            int randChoice = optionsGenerator.Next(1, 3);

            //If bot needs not to raise or call, he checks
            if (callAmount <= 0)
            {
                Check(ref botTurn, botStatus);
            }

             //If player has to call or raise
            else
            {
                //If call amount is bigger than the number calculated using BotChoiceFormula with n
                if (callAmount >= BotChoiceFormula(botChips, n))
                {
                    //Calls if call amount is less than bot's chips
                    if (botChips > callAmount)
                    {
                        Call(ref botChips, ref botTurn, botStatus);
                    }

                    //If bot has made an all in,
                    //No raise is made, status is "Call" and bot has no more chips
                    else if (botChips <= callAmount)
                    {
                        isBetRaised = false;
                        botTurn = false;
                        botChips = 0;
                        botStatus.Text = "Call " + botChips;
                        textboxPot.Text = (int.Parse(textboxPot.Text) + botChips).ToString();
                    }
                }

                //In this scenario bot checks if he can afford to raise
                else
                {
                    //checks if bot can raise(if he has at least double raise amount chips)
                    if (this.raiseAmount > 0)
                    {
                        //Bot raises
                        if (botChips >= this.raiseAmount * 2)
                        {
                            this.raiseAmount *= 2;
                            Raised(ref botChips, ref botTurn, botStatus);
                        }
                        ////Bot calls
                        else
                        {
                            Call(ref botChips, ref botTurn, botStatus);
                        }
                    }
                    ////Raise amount for bot is formed based on the call amount
                    else
                    {
                        this.raiseAmount = callAmount * 2;
                        Raised(ref botChips, ref botTurn, botStatus);
                    }
                }
            }

            //If bot has made an all in, he loses further turns
            if (botChips <= 0)
            {
                botFTurn = true;
            }
        }

        /// <summary>
        /// Checks if human player's time is expired
        /// If so player is considered to have folded the game.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public async void timer_Tick(object sender, object e)
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

        /// <summary>
        /// Updates status messages for all players every tick of the timer.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void Update_Tick(object sender, object e)
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
            if (textboxRaise.Text != string.Empty && int.TryParse(textboxRaise.Text, out parsedValue))
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
        
        /// <summary>
        /// Click Fold button event.
        /// Describes a series of changes in four variable values, 
        /// connected to fold status, that happen when human player clicks Fold button.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public async void bFold_Click(object sender, EventArgs e)
        {
            labelPlayerStatus.Text = "Fold";
            this.isPlayerTurn = false;
            this.playerFoldOrAllIn = true;
            await Turns();
        }
     
        /// <summary>
        /// Click Check button event.
        /// Describes a series of changes in four variable values, 
        /// connected to Check status,
        /// that happen when human player clicks Check button.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public async void bCheck_Click(object sender, EventArgs e)
        {
            //Player checks
            if (callAmount <= 0)
            {
                this.isPlayerTurn = false;
                labelPlayerStatus.Text = "Check";
            }
            ////Check buton shoud only be enabled when call amount is 0
            else
            {
                ////pStatus.Text = "All in " + playerChips;

                buttonCheck.Enabled = false;
            }

            await Turns();
        }     
        
        /// <summary>
        /// Click Call button event. 
        /// Describes a series of changes connected to Call status,
        /// that happen when human player clicks Call button.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public async void bCall_Click(object sender, EventArgs e)
        {
            //Refreshes player hand type status in case he is the last one to call the call amount
            //and the click is followed by any of the three community cards rounds:Flop, Turn or River
            DeterminePlayerCurrentBestHand(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
            if (this.playerChips >= callAmount)
            {
                //Human player chips value is recalculated and refreshed in textboxPlayerChips status box
                this.playerChips -= callAmount;
                textboxPlayerChips.Text = "Chips : " + this.playerChips.ToString();

                //Pot text is refreshed with the new value
                //If pot was empty before
                if (textboxPot.Text != string.Empty)
                {
                    textboxPot.Text = (int.Parse(textboxPot.Text) + callAmount).ToString();
                }
                    ////If pot was not empty new value is added to old value
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
        
        /// <summary> 
        /// Click Raise button event.
        /// Describes a series of changes connected to Raise status,
        /// that happen when human player clicks Raise button.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public async void bRaise_Click(object sender, EventArgs e)
        {
            //Refreshes player hand type status in case he is the last one to call the call amount
            //and the click is followed by any of the three community cards rounds:Flop, Turn or River
            DeterminePlayerCurrentBestHand(0, 1, "Player", ref this.playerHandCategoryFactor, ref this.playerHandRankFactor, this.playerFoldOrAllIn);
            int parsedValue;

            //Raise amount is not 0(empty string) 
            if (textboxRaise.Text != string.Empty && int.TryParse(textboxRaise.Text, out parsedValue))
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
                        ////In this case human player raises with all his chips, 
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

        /// <summary>
        /// AddChips event.
        /// If player enters a number > 0 for the added chips,
        /// this number is added to all players chips amounts.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void bAdd_Click(object sender, EventArgs e)
        {
            if (textboxAddChips.Text == string.Empty)
            {
            }
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
              
        /// <summary>
        /// Blinds button click event.
        /// Shows buttons for the two blinds with text messages for their amounts.     
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void bOptions_Click(object sender, EventArgs e)
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
 
        /// <summary>
        /// SmallBlind button click event.
        /// Checks the entered text for small blind value.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void bSB_Click(object sender, EventArgs e)
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
        
        /// <summary>
        /// BigBlind button click event.
        /// Checks the entered text for big blind value.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void bBB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            ////Checks if entered amount is a round number
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

        /// <summary>
        /// Layout change event.
        /// Describes changes in layout dimensions.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void Layout_Change(object sender, LayoutEventArgs e)
        {
            windowWidth = this.Width;
            windowHeight = this.Height;
        }
   
        /// <summary>
        /// Form loading event.
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void PokerTable_Load(object sender, EventArgs e)
        {
        }
    }
}