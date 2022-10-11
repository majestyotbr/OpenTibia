﻿using OpenTibia.Common.Objects;
using System;

namespace OpenTibia.Game.Commands
{
    public class ItemTransformCommand : CommandResult<Item>
    {
        public ItemTransformCommand(Item fromItem, ushort openTibiaId, byte count)
        {
            FromItem = fromItem;

            OpenTibiaId = openTibiaId;

            Count = count;
        }

        public Item FromItem { get; set; }

        public ushort OpenTibiaId { get; set; }

        public byte Count { get; set; }

        public override PromiseResult<Item> Execute(Context context)
        {
            return PromiseResult<Item>.Run(resolve =>
            {
                Item toItem = context.Server.ItemFactory.Create(OpenTibiaId, Count);

                if (toItem != null)
                {
                    switch (FromItem.Parent)
                    {
                        case Tile tile:

                            context.AddCommand(new TileReplaceItemCommand(tile, FromItem, toItem) ).Then( (ctx, index) =>
                            {
                                context.Server.ItemFactory.Destroy(FromItem);

                                resolve(ctx, toItem);
                            } );
                  
                            break;

                        case Inventory inventory:

                            context.AddCommand(new InventoryReplaceItemCommand(inventory, FromItem, toItem) ).Then( (ctx, index) =>
                            {
                                context.Server.ItemFactory.Destroy(FromItem);

                                resolve(ctx, toItem);
                            } );
                   
                            break;

                        case Container container:

                            context.AddCommand(new ContainerReplaceItemCommand(container, FromItem, toItem) ).Then( (ctx, index) =>
                            {
                                context.Server.ItemFactory.Destroy(FromItem);

                                resolve(ctx, toItem);
                            } );

                            break;                    
                    }
                }
            } );            
        }
    }
}