﻿using OpenTibia.Common.Objects;

namespace OpenTibia.Game.Commands
{
    public class ParseMoveItemFromContainerToInventoryCommand : ParseMoveItemCommand
    {
        public ParseMoveItemFromContainerToInventoryCommand(Player player, byte fromContainerId, byte fromContainerIndex, ushort tibiaId, byte toSlot, byte count) : base(player)
        {
            FromContainerId = fromContainerId;

            FromContainerIndex = fromContainerIndex;

            TibiaId = tibiaId;
            
            ToSlot = toSlot;

            Count = count;
        }

        public byte FromContainerId { get; set; }

        public byte FromContainerIndex { get; set; }

        public ushort TibiaId { get; set; }

        public byte ToSlot { get; set; }

        public byte Count { get; set; }

        public override Promise Execute()
        {
            Container fromContainer = Player.Client.Containers.GetContainer(FromContainerId);

            if (fromContainer != null)
            {
                Item fromItem = fromContainer.GetContent(FromContainerIndex) as Item;

                if (fromItem != null && fromItem.Metadata.TibiaId == TibiaId)
                {
                    Inventory toInventory = Player.Inventory;

                    if (IsPickupable(fromItem) && IsMoveable(fromItem, Count) )
                    {
                        return Context.AddCommand(new PlayerMoveItemCommand(this, Player, fromItem, toInventory, ToSlot, Count, true) );
                    }
                }
            }

            return Promise.Break;
        }
    }
}