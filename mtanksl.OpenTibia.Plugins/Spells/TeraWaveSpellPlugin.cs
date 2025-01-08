﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using OpenTibia.Game.Common;
using OpenTibia.Game.Plugins;

namespace OpenTibia.Plugins.Spells
{
    public class TeraWaveSpellPlugin : SpellPlugin
    {
        public TeraWaveSpellPlugin(Spell spell) : base(spell)
        {

        }

        public override PromiseResult<bool> OnCasting(Player player, Creature target, string message)
        {
            return Promise.FromResultAsBooleanTrue;
        }

        public override Promise OnCast(Player player, Creature target, string message)
        {
            Offset[] area = new Offset[]
            {
                                   new Offset(0, 1),
                                   new Offset(0, 2),
                new Offset(-1, 3), new Offset(0, 3), new Offset(1, 3),
                new Offset(-1, 4), new Offset(0, 4), new Offset(1, 4),
                new Offset(-1, 5), new Offset(0, 5), new Offset(1, 5),
            };

            var formula = Formula.GenericFormula(player.Level, player.Skills.MagicLevel, 3.5, 0, 7, 0);

            return Context.AddCommand(new CreatureAttackAreaCommand(player, true, player.Tile.Position, area, null, MagicEffectType.PlantAttack, 
                        
                new SimpleAttack(null, null, AnimatedTextColor.Green, formula.Min, formula.Max) ) );
        }
    }
}