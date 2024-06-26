﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;

namespace OpenTibia.Game.Commands
{
    public class ParseMoveItemFromTileToInventoryCommand : ParseMoveItemCommand
    {
        public ParseMoveItemFromTileToInventoryCommand(Player player, Position fromPosition, byte fromIndex, ushort tibiaId, byte toSlot, byte count) : base(player)
        {
            FromPosition = fromPosition;

            FromIndex = fromIndex;

            TibiaId = tibiaId;

            ToSlot = toSlot;

            Count = count;
        }

        public Position FromPosition { get; set; }

        public byte FromIndex { get; set; }

        public ushort TibiaId { get; set; }

        public byte ToSlot { get; set; }

        public byte Count { get; set; }
        
        public override Promise Execute()
        {
            Tile fromTile = Context.Server.Map.GetTile(FromPosition);

            if (fromTile != null)
            {
                if (Player.Tile.Position.CanHearSay(fromTile.Position) )
                {
                    Item fromItem = Player.Client.GetContent(fromTile, FromIndex) as Item;

                    if (fromItem != null && fromItem.Metadata.TibiaId == TibiaId)
                    {
                        Inventory toInventory = Player.Inventory;

                        if (IsPickupable(fromItem) && IsMoveable(fromItem, Count) )
                        {
                            return Context.AddCommand(new PlayerMoveItemCommand(this, Player, fromItem, toInventory, ToSlot, Count, true) );
                        }
                    }
                }
            }

            return Promise.Break;
        }
    }
}