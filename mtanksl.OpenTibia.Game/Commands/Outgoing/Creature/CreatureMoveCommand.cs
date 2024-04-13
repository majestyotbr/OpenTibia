﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Components;
using OpenTibia.Game.Events;
using OpenTibia.Network.Packets.Outgoing;
using System.Collections.Generic;
using System.Linq;

namespace OpenTibia.Game.Commands
{
    public class CreatureMoveCommand : Command
    {
        public CreatureMoveCommand(Creature creature, Tile toTile) : this(creature, toTile, null)
        {

        }

        public CreatureMoveCommand(Creature creature, Tile toTile, Direction? changeDirectionOnMove)
        {
            Creature = creature;

            ToTile = toTile;

            ChangeDirectionOnMove = changeDirectionOnMove;
        }

        public Creature Creature { get; set; }

        public Tile ToTile { get; set; }

        public Direction? ChangeDirectionOnMove { get; set; }

        public override Promise Execute()
        {
            Dictionary<Player, byte> canSeeFrom = new Dictionary<Player, byte>();

            foreach (var observer in Context.Server.Map.GetObserversOfTypePlayer(Creature.Tile.Position) )
            {
                byte clientIndex;

                if (observer.Client.TryGetIndex(Creature, out clientIndex) )
                {
                    canSeeFrom.Add(observer, clientIndex);
                }
            }

            Tile fromTile = Creature.Tile;

            int fromIndex = fromTile.GetIndex(Creature);

            fromTile.RemoveContent(fromIndex);

            Context.Server.Map.RemoveObserver(fromTile.Position, Creature);

            int toIndex = ToTile.AddContent(Creature);

            Context.Server.Map.AddObserver(ToTile.Position, Creature);

            Dictionary<Player, byte> canSeeTo = new Dictionary<Player, byte>();

            foreach (var observer in Context.Server.Map.GetObserversOfTypePlayer(Creature.Tile.Position) )
            {
                byte clientIndex;

                if (observer.Client.TryGetIndex(Creature, out clientIndex) )
                {
                    canSeeTo.Add(observer, clientIndex);
                }
            }

            Direction? direction = fromTile.Position.ToDirection(ToTile.Position);

            if (direction != null)
            {
                Creature.Direction = direction.Value;
            }

            if (fromTile.Position.IsNextTo(ToTile.Position) )
            {
                MoveDirection? moveDirection = fromTile.Position.ToMoveDirection(ToTile.Position);

                if (moveDirection != null)
                {
                    if (moveDirection == MoveDirection.NorthWest || moveDirection == MoveDirection.NorthEast || moveDirection == MoveDirection.SouthWest || moveDirection == MoveDirection.SouthEast)
                    {
                        Creature.LastMoveDiagonalCost = 2;
                    }
                    else
                    {
                        Creature.LastMoveDiagonalCost = 1;
                    }
                }
            }
            else
            {
                Creature.LastMoveDiagonalCost = 1;
            }

            if (Creature is Player player)
            {
                int deltaZ = ToTile.Position.Z - fromTile.Position.Z;

                int deltaY = ToTile.Position.Y - fromTile.Position.Y;

                int deltaX = ToTile.Position.X - fromTile.Position.X;

                if (deltaZ < -1 || deltaZ > 1 || deltaY < -6 || deltaY > 7 || deltaX < -8 || deltaX > 9 || (fromTile.Position.Z == 7 && ToTile.Position.Z == 8) )
                {
                    Context.AddPacket(player, new SendTilesOutgoingPacket(Context.Server.Map, player.Client, ToTile.Position) );
                }
                else
                {
                    if (canSeeFrom.ContainsKey(player) && canSeeTo.ContainsKey(player) )
                    {
                        Context.AddPacket(player, new WalkOutgoingPacket(fromTile.Position, canSeeFrom[player], ToTile.Position) );

                        if (fromTile.Count >= Constants.ObjectsPerPoint)
                        {
                            Context.AddPacket(player, new SendTileOutgoingPacket(Context.Server.Map, player.Client, fromTile.Position) );
                        }
                    }
                    else if (canSeeFrom.ContainsKey(player) )
                    {
                        if (fromTile.Count >= Constants.ObjectsPerPoint)
                        {
                            Context.AddPacket(player, new SendTileOutgoingPacket(Context.Server.Map, player.Client, fromTile.Position) );
                        }
                        else
                        {
                            Context.AddPacket(player, new ThingRemoveOutgoingPacket(fromTile.Position, canSeeFrom[player] ) );
                        }
                    }
                    else if (canSeeTo.ContainsKey(player) )
                    {
                        uint removeId;

                        if (player.Client.Battles.IsKnownCreature(Creature.Id, out removeId) )
                        {
                            Context.AddPacket(player, new ThingAddOutgoingPacket(ToTile.Position, canSeeTo[player], Creature) );
                        }
                        else
                        {
                            Context.AddPacket(player, new ThingAddOutgoingPacket(ToTile.Position, canSeeTo[player], removeId, Creature) );
                        }
                    }

                    Position position = fromTile.Position;

                    while (deltaZ < 0)
                    {
                        Context.AddPacket(player, new SendMapUpOutgoingPacket(Context.Server.Map, player.Client, position) );

                        Context.AddPacket(player, new SendMapWestOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, 1, -1) ) );

                        Context.AddPacket(player, new SendMapNorthOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, 0, -1) ) );

                        position = position.Offset(0, 0, -1);

                        deltaZ++;
                    }

                    while (deltaZ > 0)
                    {
                        Context.AddPacket(player, new SendMapDownOutgoingPacket(Context.Server.Map, player.Client, position) );

                        Context.AddPacket(player, new SendMapEastOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, -1, 1) ) );

                        Context.AddPacket(player, new SendMapSouthOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, 0, 1) ) );

                        position = position.Offset(0, 0, 1);

                        deltaZ--;
                    }

                    while (deltaY < 0)
                    {
                        Context.AddPacket(player, new SendMapNorthOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, -1, 0) ) );

                        position = position.Offset(0, -1, 0);

                        deltaY++;
                    }

                    while (deltaY > 0)
                    {
                        Context.AddPacket(player, new SendMapSouthOutgoingPacket(Context.Server.Map, player.Client, position.Offset(0, 1, 0) ) );

                        position = position.Offset(0, 1, 0);

                        deltaY--;
                    }

                    while (deltaX < 0)
                    {
                        Context.AddPacket(player, new SendMapWestOutgoingPacket(Context.Server.Map, player.Client, position.Offset(-1, 0, 0) ) );

                        position = position.Offset(-1, 0, 0);

                        deltaX++;
                    }

                    while (deltaX > 0)
                    {
                        Context.AddPacket(player, new SendMapEastOutgoingPacket(Context.Server.Map, player.Client, position.Offset(1, 0, 0) ) );

                        position = position.Offset(1, 0, 0);

                        deltaX--;
                    }
                }     
                
                PlayerActionDelayBehaviour playerActionDelayBehaviour = Context.Server.GameObjectComponents.GetComponent<PlayerActionDelayBehaviour>(player);

                if (playerActionDelayBehaviour != null)
                {
                    Context.Server.GameObjectComponents.RemoveComponent(player, playerActionDelayBehaviour);
                }

                PlayerWalkDelayBehaviour playerWalkDelayBehaviour = Context.Server.GameObjectComponents.GetComponent<PlayerWalkDelayBehaviour>(player);

                if (playerWalkDelayBehaviour != null)
                {
                    if (Context.Server.GameObjectComponents.RemoveComponent(player, playerWalkDelayBehaviour) )
                    {
                        Context.AddPacket(player, new StopWalkOutgoingPacket(player.Direction) );
                    }
                }
            }

            foreach (var observer in canSeeFrom.Keys.Intersect(canSeeTo.Keys) )
            {
                if (observer != Creature)
                {
                    Context.AddPacket(observer, new WalkOutgoingPacket(fromTile.Position, canSeeFrom[observer], ToTile.Position) );

                    if (fromTile.Count >= Constants.ObjectsPerPoint)
                    {
                        Context.AddPacket(observer, new SendTileOutgoingPacket(Context.Server.Map, observer.Client, fromTile.Position) );
                    }
                }
            }

            foreach (var observer in canSeeFrom.Keys.Except(canSeeTo.Keys) )
            {
                if (observer != Creature)
                {
                    if (fromTile.Count >= Constants.ObjectsPerPoint)
                    {
                        Context.AddPacket(observer, new SendTileOutgoingPacket(Context.Server.Map, observer.Client, fromTile.Position) );
                    }
                    else
                    {
                        Context.AddPacket(observer, new ThingRemoveOutgoingPacket(fromTile.Position, canSeeFrom[observer] ) );
                    }
                }
            }

            foreach (var observer in canSeeTo.Keys.Except(canSeeFrom.Keys) )
            {
                if (observer != Creature)
                {
                    uint removeId;

                    if (observer.Client.Battles.IsKnownCreature(Creature.Id, out removeId) )
                    {
                        Context.AddPacket(observer, new ThingAddOutgoingPacket(ToTile.Position, canSeeTo[observer], Creature) );
                    }
                    else
                    {
                        Context.AddPacket(observer, new ThingAddOutgoingPacket(ToTile.Position, canSeeTo[observer], removeId, Creature) );
                    }
                }
            }

            Context.AddEvent(new TileRemoveCreatureEventArgs(Creature, fromTile, fromIndex, ToTile, toIndex) );

            Context.AddEvent(new TileAddCreatureEventArgs(Creature, fromTile, fromIndex, ToTile, toIndex) );

            return Promise.Completed;
        }
    }
}