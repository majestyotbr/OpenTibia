﻿using OpenTibia.Common.Objects;
using OpenTibia.Network.Packets.Outgoing;

namespace OpenTibia.Game.Commands
{
    public class TileRefreshItemCommand : Command
    {
        public TileRefreshItemCommand(Tile tile, Item item)
        {
            Tile = tile;

            Item = item;
        }

        public Tile Tile { get; set; }

        public Item Item { get; set; }

        public override Promise Execute()
        {
            byte index = Tile.GetIndex(Item);

            if (index < Constants.ObjectsPerPoint)
            {
                foreach (var observer in Context.Server.GameObjects.GetPlayers() )
                {
                    if (observer.Tile.Position.CanSee(Tile.Position) )
                    {
                        Context.AddPacket(observer.Client.Connection, new ThingUpdateOutgoingPacket(Tile.Position, index, Item) );
                    }
                }
            }

            return Promise.Completed;
        }
    }
}