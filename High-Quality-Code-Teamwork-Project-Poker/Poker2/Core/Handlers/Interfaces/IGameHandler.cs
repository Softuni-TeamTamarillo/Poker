﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker2.Core.Handlers.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    using Poker2.Core.Controllers.Interfaces;
    using Poker2.Core.Interfaces;

    public interface IGameHandler
    {
        IDatabase Database { get; }

        IBetHandler BetHandler { get; }

        IDealHandler DealHandler { get; }

        void StartGame();

        void FinishGame();
        ITimerController TimerController { get; }

    }
}
