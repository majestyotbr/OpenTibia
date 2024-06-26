﻿using OpenTibia.Common.Objects;

namespace OpenTibia.Game.Commands
{
    public abstract class ParseLookCommand : IncomingCommand
    {
        public ParseLookCommand(Player player)
        {
            Player = player;
        }

        public Player Player { get; set; }
    }
}