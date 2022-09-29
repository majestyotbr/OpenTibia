﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;

namespace OpenTibia.Game.CommandHandlers
{
    public class CreateNpcHandler : CommandHandler<PlayerSayCommand>
    {
        private string name;

        public override bool CanHandle(Context context, PlayerSayCommand command)
        {
            if (command.Message.StartsWith("/n") && command.Message.Contains(" ") )
            {
                name = command.Message.Split(' ')[1];

                return true;
            }

            return false;
        }

        public override void Handle(Context context, PlayerSayCommand command)
        {
            Tile toTile = context.Server.Map.GetTile(command.Player.Tile.Position.Offset(command.Player.Direction) );

            if (toTile != null)
            {
                context.AddCommand(new NpcCreateCommand(toTile, name) );

                context.AddCommand(new MagicEffectCommand(toTile.Position, MagicEffectType.BlueShimmer) );
            }
            else
            {
                context.AddCommand(new MagicEffectCommand(command.Player.Tile.Position, MagicEffectType.Puff) );
            }

            base.Handle(context, command);
        }
    }
}