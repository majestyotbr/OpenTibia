﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using System;

namespace OpenTibia.Game.Components
{
    public class RandomWalkStrategy : IWalkStrategy
    {
        private int radius;

        public RandomWalkStrategy(int radius)
        {
            this.radius = radius;
        }

        public bool CanWalk(Creature attacker, Creature target, out Tile tile)
        {
            foreach (var direction in Context.Current.Server.Randomization.Shuffle(new[] { Direction.North, Direction.East, Direction.South, Direction.West } ) )
            {
                Tile toTile = Context.Current.Server.Map.GetTile(attacker.Tile.Position.Offset(direction) );

                if (toTile == null || toTile.Ground == null || !toTile.CanWalk || Math.Abs(toTile.Position.X - attacker.Spawn.Position.X) > radius || Math.Abs(toTile.Position.Y - attacker.Spawn.Position.Y) > radius)
                {

                }
                else
                {
                    tile = toTile;

                    return true;
                }
            }

            tile = null;

            return false;
        }
    }
}