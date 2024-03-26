﻿using OpenTibia.Game.CommandHandlers;

namespace OpenTibia.Game.Scripts
{
    public class StackableItemUpdateCountScripts : Script
    {
        public override void Start()
        {
            Context.Server.CommandHandlers.AddCommandHandler(new StackableItemUpdateCountTradingRejectHandler() );            
        }

        public override void Stop()
        {
            
        }
    }
}