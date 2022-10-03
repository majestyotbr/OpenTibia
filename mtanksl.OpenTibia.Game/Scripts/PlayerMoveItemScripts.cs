﻿using OpenTibia.Game.CommandHandlers;

namespace OpenTibia.Game.Scripts
{
    public class PlayerMoveItemScripts : IScript
    {
        public void Start(Server server)
        {
            server.CommandHandlers.Add(new MoveItemWalkToSourceHandler() );
        }

        public void Stop(Server server)
        {
            
        }
    }
}