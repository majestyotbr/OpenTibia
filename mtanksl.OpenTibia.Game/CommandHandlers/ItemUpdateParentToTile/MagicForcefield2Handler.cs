﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using System;
using System.Collections.Generic;

namespace OpenTibia.Game.CommandHandlers
{
    public class MagicForcefield2Handler : CommandHandler<ItemUpdateParentToTileCommand>
    {
        private HashSet<ushort> magicForcefields = new HashSet<ushort>() { 1387 };

        public override Promise Handle(Context context, Func<Context, Promise> next, ItemUpdateParentToTileCommand command)
        {
            Tile fromTile = command.ToTile;

            if (fromTile.TopItem != null && magicForcefields.Contains(fromTile.TopItem.Metadata.OpenTibiaId) )
            {
                Tile toTile = context.Server.Map.GetTile( ( (TeleportItem)fromTile.TopItem ).Position );

                return context.AddCommand(new ItemUpdateParentToTileCommand(command.Item, toTile) ).Then(ctx =>
                {
                    return ctx.AddCommand(new ShowMagicEffectCommand(fromTile.Position, MagicEffectType.Teleport) );

                } ).Then(ctx =>
                {
                    return ctx.AddCommand(new ShowMagicEffectCommand(toTile.Position, MagicEffectType.Teleport) );
                } );
            }

            return next(context);
        }
    }
}