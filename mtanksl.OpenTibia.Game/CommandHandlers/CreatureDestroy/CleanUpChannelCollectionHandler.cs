﻿using OpenTibia.Common.Objects;
using OpenTibia.Game.Commands;
using OpenTibia.Network.Packets.Outgoing;
using System;
using System.Linq;

namespace OpenTibia.Game.CommandHandlers
{
    public class CleanUpChannelCollectionHandler : CommandHandler<CreatureDestroyCommand>
    {
        public override Promise Handle(Func<Promise> next, CreatureDestroyCommand command)
        {
            if (command.Creature is Player player)
            {
                return next().Then( () =>
                {
                    foreach (var channel in Context.Server.Channels.GetChannels().ToList() )
                    {
                        if (channel.ContainerMember(player) )
                        {
                            channel.RemoveMember(player);

                            Context.AddPacket(player, new CloseChannelOutgoingPacket(channel.Id) );

                            if (channel is PrivateChannel privateChannel)
                            {
                                if (privateChannel.ContainsInvitation(player) )
                                {
                                    privateChannel.RemoveInvitation(player);
                                }

                                if (privateChannel.Owner == player)
                                {
                                    foreach (var observer in privateChannel.GetMembers().ToList() )
                                    {
                                        privateChannel.RemoveMember(observer);

                                        Context.AddPacket(observer, new CloseChannelOutgoingPacket(channel.Id) );
                                    }

                                    foreach (var observer in privateChannel.GetInvitations().ToList() )
                                    {
                                        privateChannel.RemoveInvitation(observer);
                                    }

                                    Context.Server.Channels.RemoveChannel(privateChannel);
                                }
                            }
                        }
                    }

                    return Promise.Completed;
                } );
            }

            return next();
        }
    }
}