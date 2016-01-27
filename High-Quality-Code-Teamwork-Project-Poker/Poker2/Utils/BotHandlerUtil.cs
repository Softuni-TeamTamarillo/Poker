﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Utils
{
    public static class BotHandlerUtil
    {
        /// <summary>
        /// Holds the logic of the number paratmeters needed for bot's logic for making a choice.
        /// </summary>
        /// <param name="botChips">Current available bot chips</param>
        /// <param name="randFactor">Random factor</param>
        /// <returns>double</returns>
        public static double ChoiceFormula(int botChips,  int randFactor)
        {
            double result = Math.Round((botChips / randFactor) / 100d, 0) * 100;
            return result;
        }
    }
}
