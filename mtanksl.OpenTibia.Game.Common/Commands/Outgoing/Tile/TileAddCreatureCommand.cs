﻿using OpenTibia.Common.Objects;
using OpenTibia.Game.Common;
using OpenTibia.Game.Events;
using OpenTibia.Network.Packets.Outgoing;
using System.Collections.Generic;

namespace OpenTibia.Game.Commands
{
    public class TileAddCreatureCommand : Command
    {
        public TileAddCreatureCommand(Tile toTile, Creature creature)
        {
            ToTile = toTile;

            Creature = creature;
        }

        public Tile ToTile { get; set; }

        public Creature Creature { get; set; }

        public override Promise Execute()
        {
            int toIndex = ToTile.AddContent(Creature);

            Context.Server.Map.AddObserver(ToTile.Position, Creature);

            //List<Creature> canSeeToEvents = new List<Creature>();

            Dictionary<Player, byte> canSeeTo = new Dictionary<Player, byte>();

            foreach (var observer in Context.Server.Map.GetObserversOfTypeCreature(Creature.Tile.Position) )
            {
                if (observer is Player player && observer != Creature)
                {
                    byte clientIndex;

                    if (player.Client.TryGetIndex(Creature, out clientIndex) )
                    {
                        canSeeTo.Add(player, clientIndex);
                    }
                }

                //canSeeToEvents.Add(observer);
            }

            foreach (var pair in canSeeTo)
            {
                uint removeId;

                if (pair.Key.Client.Battles.IsKnownCreature(Creature.Id, out removeId) )
                {
                    Context.AddPacket(pair.Key, new ThingAddOutgoingPacket(ToTile.Position, pair.Value, Creature) );
                }
                else
                {
                    Context.AddPacket(pair.Key, new ThingAddOutgoingPacket(ToTile.Position, pair.Value, removeId, Creature) );
                }
            }

            TileAddCreatureEventArgs tileAddCreatureEventArgs = new TileAddCreatureEventArgs(Creature, null, null, ToTile, toIndex);

            //foreach (var e in canSeeToEvents)
            //{
            //    Context.AddEvent(e, tileAddCreatureEventArgs);
            //}

            Context.AddEvent(tileAddCreatureEventArgs);

            return Promise.Completed;
        }
    }
}