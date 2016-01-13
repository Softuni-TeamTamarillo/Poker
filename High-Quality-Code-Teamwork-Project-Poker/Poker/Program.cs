//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="MyCompanyName">
//     Copyright (c) MyCompanyName. All rights reserved.
// </copyright>
// <summary>
// This file contains Program class.
// </summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The Program class
    /// </summary>    
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PokerTable());
        }
    }
}
