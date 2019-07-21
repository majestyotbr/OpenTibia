﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Network.Packets.Outgoing;

namespace OpenTibia.Game.Commands
{
    public class MoveItemFromContainerToContainerCommand : MoveItemCommand
    {
        public MoveItemFromContainerToContainerCommand(Player player, byte fromContainerId, byte fromContainerIndex, ushort itemId, byte toContainerId, byte toContainerIndex, byte count)
        {
            Player = player;

            FromContainerId = fromContainerId;

            FromContainerIndex = fromContainerIndex;

            ItemId = itemId;

            ToContainerId = toContainerId;

            ToContainerIndex = toContainerIndex;

            Count = count;
        }

        public Player Player { get; set; }

        public byte FromContainerId { get; set; }

        public byte FromContainerIndex { get; set; }

        public ushort ItemId { get; set; }

        public byte ToContainerId { get; set; }

        public byte ToContainerIndex { get; set; }

        public byte Count { get; set; }

        public override void Execute(Server server, CommandContext context)
        {
            //Arrange

            Container fromContainer = Player.Client.ContainerCollection.GetContainer(FromContainerId);

            if (fromContainer != null)
            {
                Item fromItem = fromContainer.GetContent(FromContainerIndex) as Item;

                if (fromItem != null && fromItem.Metadata.TibiaId == ItemId)
                {
                    Container toContainer = Player.Client.ContainerCollection.GetContainer(ToContainerId);

                    if (toContainer != null)
                    {
                        Container parent = fromItem as Container;

                        if (parent != null)
                        {
                            if (toContainer.IsChildOfParent(parent) )
                            {
                                context.Write(Player.Client.Connection, new ShowWindowTextOutgoingPacket(TextColor.WhiteBottomGameWindow, Constants.ThisIsImpossible) );

                                return;
                            }

                            //Act

                            CloseContainer(toContainer, parent,  server, context);
                        }
                        
                        RemoveItem(fromContainer, FromContainerIndex, server, context);

                        AddItem(toContainer, fromItem, server, context);

                        base.Execute(server, context);
                    }
                }
            }
        }
    }
}