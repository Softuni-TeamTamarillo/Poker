using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers
{
    using Poker2.Core.Handlers.Interfaces;
    using Poker2.Core.Interfaces;
    using Poker2.Models;
    using Poker2.Models.Interfaces;

    /// <summary>
    /// Class that describes the bot's logic in making a choice.
    /// </summary>
    public class BotHandler : IBotHandler
    {

        private IBotBetMaker botBetMaker = null;
        //private IBotBetMaker PickABotBetMaker(IPlayer bot)
        //{
        //    switch (bot.Hand.Type)
        //    {
        //        case HandType.HighCard:
        //        case HandType.PairTable: 
        //        return new BotChoiceMakerWeakerHand();

        //        case HandType.Pair: 
        //        case HandType.TwoPairs:
        //            return new BotChoiceMakerWeakHand();

        //        case HandType.ThreeOfAKind: 
        //        case HandType.Straight: 
        //        case HandType.Flush: 
        //        case HandType.FullHouse: 
        //        case HandType.FourOfAKind: 
        //        case HandType.StraightFlush:
        //        case HandType.RoyalFlush: return new BotChoiceMakerOtherHand();
        //        default:
        //            throw new ArgumentException("Wrong hand Type!Only types of type HandType are accepted.");
        //    }
        //}

        public void BotMakesAChoice(IPlayer bot)
        {
           
        }
    }
}
