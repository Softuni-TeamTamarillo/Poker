//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Poker2.Core.Handlers
//{
//    using System.Windows.Forms;

//    using Poker2.Core.Controllers;
//    using Poker2.Core.Handlers.Interfaces;
//    using Poker2.Models.Interfaces;

//    public class TurnHandler : ITurnHandler
//    {
//        private readonly TimerController timerController;
//        public TurnHandler()
//        {
//            this.timerController = new TimerController();
//        }
//        public void AdvanceTurns(IList<IPlayer> players)
//        {
//            foreach (var player in players)
//            {
//                PlayerTakesTurn(player);
//            }
//        }
//        public TimerController TimerController
//        {
//            get
//            {
//                return this.timerController;
//            }
//        }

//        private void PlayerTakesTurn(IPlayer player)
//        {
            
//        }

//        public void DisableCurrentPlayer()
//        {
            
//        }

//        public void EnableNextPlayer()
//        {
            
//        }
            
//        public void StartTurns()
//        {
            
//        }

//        public void TakeTurns()
//        {
            
//        }
//        public void EndTurns()
//        {
            
//        }
//    }
//}
