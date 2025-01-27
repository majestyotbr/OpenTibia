﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using OpenTibia.Game.Common;
using OpenTibia.Game.Plugins;
using System;
using System.Linq;

namespace OpenTibia.Plugins.Runes
{
    public class SoulFireRunePlugin : RunePlugin
    {
        public SoulFireRunePlugin(Rune rune) : base(rune)
        {

        }

        public override PromiseResult<bool> OnUsingRune(Player player, Creature target, Tile toTile, Item rune)
        {
            return Promise.FromResultAsBooleanTrue;
        }

        public override Promise OnUseRune(Player player, Creature target, Tile toTile, Item rune)
        {
            int repeat;

            if (player.Vocation == Vocation.Druid || player.Vocation == Vocation.Sorcerer || player.Vocation == Vocation.ElderDruid || player.Vocation == Vocation.MasterSorcerer)
            {
                repeat = (player.Level + player.Skills.MagicLevel) / 3;
            }
            else if (player.Vocation == Vocation.Knight || player.Vocation == Vocation.EliteKnight)
            {
                repeat = (player.Level + player.Skills.MagicLevel) / 20;
            }
            else if (player.Vocation == Vocation.Paladin || player.Vocation == Vocation.RoyalPaladin)
            {
                repeat = (player.Level + player.Skills.MagicLevel) / 15;
            }
            else
            {
                repeat = 1;
            }

            return Context.AddCommand(new CreatureAttackCreatureCommand(player, target,

                new SimpleAttack(null, MagicEffectType.FirePlume, AnimatedTextColor.Orange, 10, 10),
                
                new DamageCondition(SpecialCondition.Burning, MagicEffectType.FirePlume, AnimatedTextColor.Orange, Enumerable.Repeat(10, Math.Max(1, repeat) ).ToArray(), TimeSpan.FromSeconds(9) ) ) );

        }
    }
}