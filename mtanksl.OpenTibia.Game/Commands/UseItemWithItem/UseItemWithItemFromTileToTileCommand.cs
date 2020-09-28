﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;

namespace OpenTibia.Game.Commands
{
    public class UseItemWithItemFromTileToTileCommand : UseItemWithItemCommand
    {
        public UseItemWithItemFromTileToTileCommand(Player player, Position fromPosition, byte fromIndex, ushort fromItemId, Position toPosition, byte toIndex, ushort toItemId) : base(player)
        {
            FromPosition = fromPosition;

            FromIndex = fromIndex;

            FromItemId = fromItemId;

            ToPosition = toPosition;

            ToIndex = toIndex;

            ToItemId = toItemId;
        }
        
        public Position FromPosition { get; set; }

        public byte FromIndex { get; set; }

        public ushort FromItemId { get; set; }

        public Position ToPosition { get; set; }

        public byte ToIndex { get; set; }

        public ushort ToItemId { get; set; }

        public override void Execute(Context context)
        {
            Tile fromTile = context.Server.Map.GetTile(FromPosition);

            if (fromTile != null)
            {
                Item fromItem = fromTile.GetContent(FromIndex) as Item;

                if (fromItem != null && fromItem.Metadata.TibiaId == FromItemId)
                {
                    Tile toTile = context.Server.Map.GetTile(ToPosition);

                    if (toTile != null)
                    {
                        switch (toTile.GetContent(ToIndex) )
                        {
                            case Item toItem:

                                if (toItem.Metadata.TibiaId == ToItemId)
                                {
                                    if ( IsUseable(fromItem, context) )
                                    {
                                        UseItemWithItem(fromItem, toItem, context);
                                    }
                                }

                                break;

                            case Creature toCreature:

                                if (ToItemId == 99)
                                {
                                    if ( IsUseable(fromItem, context) )
                                    {
                                        UseItemWithCreature(fromItem, toCreature, context);
                                    }
                                }

                                break;
                        }
                    }
                }
            }
        }
    }
}