using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Utils
{
    public static class BotHandlerUtil
    {
        public static double ChoiceFormula(int botChips,  int randFactor)
        {
            double result = Math.Round((botChips / randFactor) / 100d, 0) * 100;
            return result;
        }
    }
}
