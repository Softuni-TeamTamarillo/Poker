//-----------------------------------------------------------------------
// <copyright file="AddChips.cs" company="MyCompanyName">
//     Copyright (c) MyCompanyName. All rights reserved.
// </copyright>
// <summary>
// This file contains AddChips class.
// </summary>
//-----------------------------------------------------------------------
namespace Poker2.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// AddChips Form class
    /// </summary>
    public partial class AddChips : Form
    {
        /// <summary>
        /// The addedChips field
        /// </summary>        
        private int addedChips = 0;

        /// <summary>
        /// Initializes addedChips new instance of the <see cref="AddChips" /> class.
        /// </summary>        
        public AddChips()
        {
            FontFamily fontFamily = new FontFamily("Arial");
            InitializeComponent();
            ControlBox = false;
            labelFinishedChips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        public int AddedChips { get; set; }
        /// <summary>
        /// The button1_Click method
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        public void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.Parse(textBoxAddChips.Text) > 100000000)
            {
                MessageBox.Show("The maximium chips you can add is 100000000");
                return;
            }

            if (!int.TryParse(textBoxAddChips.Text, out parsedValue))
            {
                MessageBox.Show("This is addedChips number only field");
                return;
            }
            else if (int.TryParse(textBoxAddChips.Text, out parsedValue) && int.Parse(textBoxAddChips.Text) <= 100000000)
            {
                addedChips = int.Parse(textBoxAddChips.Text);
                this.Close();
            }
        }

        /// <summary>
        /// The button2_Click method
        /// </summary>
        /// <param name="sender">The sender parameter</param>
        /// <param name="e">The e parameter</param>        
        private void button2_Click(object sender, EventArgs e)
        {
            var message = "Are you sure?";
            var title = "Quit";
            var result = MessageBox.Show(
            message,
            title,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    Application.Exit();
                    break;
            }
        }
    }
}
