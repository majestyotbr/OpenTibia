﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using OpenTibia.Network.Packets.Outgoing;
using System;
using System.Linq;

namespace OpenTibia.Game.CommandHandlers
{
    public class SplitStackableItemHandler : CommandHandler<PlayerMoveItemCommand>
    {
        public override Promise Handle(Context context, Func<Context, Promise> next, PlayerMoveItemCommand command)
        {
            if (command.ToContainer is Tile toTile)
            {
                if (toTile.Ground == null || toTile.GetItems().Any(i => i.Metadata.Flags.Is(ItemMetadataFlags.NotWalkable) ) || (toTile.GetCreatures().Any(c => c.Block) && command.Item.Metadata.Flags.Is(ItemMetadataFlags.NotWalkable) ) )
                {
                    context.AddPacket(command.Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.ThereIsNotEnoughtRoom) );
                
                    return Promise.Break();
                }
                else
                {
                    if (command.Item is StackableItem fromStackableItem)
                    {
                        if (toTile.TopItem is StackableItem toStackableItem && toStackableItem.Metadata.OpenTibiaId == fromStackableItem.Metadata.OpenTibiaId)
                        {
                            if (toStackableItem.Count + command.Count > 100)
                            {
                                context.AddCommand(new TileCreateItemCommand(toTile, fromStackableItem.Metadata.OpenTibiaId, (byte)(toStackableItem.Count + command.Count - 100) ) );

                                context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, 100) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                            }
                            else
                            {
                                context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, (byte)(toStackableItem.Count + command.Count) ) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                            }
                        }
                        else
                        {
                            if (fromStackableItem.Count == command.Count)
                            {
                                return next(context);
                            }
                            else
                            {
                                context.AddCommand(new TileCreateItemCommand(toTile, fromStackableItem.Metadata.OpenTibiaId, command.Count) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                            }
                        }
                    }
                    else
                    {
                        return next(context);
                    }
                }
            }
            else if (command.ToContainer is Inventory toInventory)
            {
                IContent toContent = toInventory.GetContent(command.ToIndex);

                if (toContent is Container toContainer2)
                {
                    return context.AddCommand(new PlayerMoveItemCommand(command.Player, command.Item, toContainer2, 254, command.Count, false) );
                }
                else
                {
                    if (command.Item is StackableItem fromStackableItem)
                    {
                        if (toContent is StackableItem toStackableItem && toStackableItem.Metadata.OpenTibiaId == fromStackableItem.Metadata.OpenTibiaId)
                        {
                            if (toStackableItem.Count + command.Count > 100)
                            {
                                byte count = (byte)(100 - toStackableItem.Count);

                                context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, 100) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, count) );
                            }
                            else
                            {
                                context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, (byte)(toStackableItem.Count + command.Count) ) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                            }
                        }
                        else
                        {
                            if (toContent == null)
                            {
                                if (fromStackableItem.Count == command.Count)
                                {
                                    return next(context);
                                }
                                else
                                {
                                    context.AddCommand(new InventoryCreateItemCommand(toInventory, command.ToIndex, fromStackableItem.Metadata.OpenTibiaId, command.Count) );

                                    context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                                }
                            }
                            else
                            {
                                context.AddPacket(command.Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.YouCannotPutMoreObjectsInThisContainer) );
                        
                                return Promise.Break();
                            }
                        }
                    }
                    else
                    {
                        if (toContent == null)
                        {
                            return next(context);
                        }
                        else
                        {
                            context.AddPacket(command.Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.YouCannotPutMoreObjectsInThisContainer) );
                        
                            return Promise.Break();
                        }
                    }
                }
            }
            else if (command.ToContainer is Container toContainer)
            {
                IContent toContent = toContainer.GetContent(command.ToIndex);

                if (toContent is Container toContainer2)
                {
                    return context.AddCommand(new PlayerMoveItemCommand(command.Player, command.Item, toContainer2, 254, command.Count, false) );
                }
                else
                {
                    if (command.Item is StackableItem fromStackableItem)
                    {
                        if (toContent is StackableItem toStackableItem && toStackableItem.Metadata.OpenTibiaId == fromStackableItem.Metadata.OpenTibiaId)
                        {
                            if (toStackableItem.Count + command.Count > 100)
                            {
                                if (toContainer.Count < toContainer.Metadata.Capacity)
                                {
                                    context.AddCommand(new ContainerCreateItemCommand(toContainer, fromStackableItem.Metadata.OpenTibiaId, (byte)(toStackableItem.Count + command.Count - 100) ) );

                                    context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, 100) );

                                    context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                                }
                                else
                                {
                                    byte count = (byte)(100 - toStackableItem.Count);

                                    context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, 100) );

                                    context.AddCommand(new ItemDecrementCommand(fromStackableItem, count) );
                                }
                            }
                            else
                            {
                                context.AddCommand(new StackableItemUpdateCountCommand(toStackableItem, (byte)(toStackableItem.Count + command.Count) ) );

                                context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                            }
                        }
                        else
                        {
                            if (toContainer.Count < toContainer.Metadata.Capacity)
                            {
                                if (fromStackableItem.Count == command.Count)
                                {
                                    return next(context);
                                }
                                else
                                {
                                    context.AddCommand(new ContainerCreateItemCommand(toContainer, fromStackableItem.Metadata.OpenTibiaId, command.Count) );

                                    context.AddCommand(new ItemDecrementCommand(fromStackableItem, command.Count) );
                                }
                            }
                            else
                            {
                                context.AddPacket(command.Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.YouCannotPutMoreObjectsInThisContainer) );
                    
                                return Promise.Break();
                            }
                        }
                    }
                    else
                    {
                        if (toContainer.Count < toContainer.Metadata.Capacity)
                        {
                            return next(context);
                        }
                        else
                        {
                            context.AddPacket(command.Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.YouCannotPutMoreObjectsInThisContainer) );
                    
                            return Promise.Break();
                        }
                    }
                }
            }

            return Promise.FromResult(context);
        }
    }
}