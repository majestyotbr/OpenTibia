﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using System;
using System.Collections.Generic;

namespace OpenTibia.Game.CommandHandlers
{
    public class HealthPotionHandler : CommandHandler<PlayerUseItemWithCreatureCommand>
    {
        private HashSet<ushort> healthPotions = new HashSet<ushort>() { 7618 };

        public override Promise Handle(Context context, Func<Context, Promise> next, PlayerUseItemWithCreatureCommand command)
        {
            if (healthPotions.Contains(command.Item.Metadata.OpenTibiaId) && command.ToCreature is Player)
            {
                return context.AddCommand(new ItemDecrementCommand(command.Item, 1) ).Then(ctx =>
                {
                    return ctx.AddCommand(new ShowTextCommand(command.ToCreature, TalkType.MonsterSay, "Aaaah...") );

                } ).Then(ctx =>
                {
                    return ctx.AddCommand(new ShowMagicEffectCommand(command.ToCreature.Tile.Position, MagicEffectType.RedShimmer) );
                } );
            }

            return next(context);
        }
    }
}