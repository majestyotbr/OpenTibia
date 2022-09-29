﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Data;
using OpenTibia.Network.Packets.Incoming;
using OpenTibia.Network.Packets.Outgoing;

namespace OpenTibia.Game.Commands
{
    public class SelectedCharacterCommand : Command
    {
        public SelectedCharacterCommand(IConnection connection, SelectedCharacterIncomingPacket packet)
        {
            Connection = connection;

            Packet = packet;
        }

        public IConnection Connection { get; set; }

        public SelectedCharacterIncomingPacket Packet { get; set; }

        public override void Execute(Context context)
        {
            Connection.Keys = Packet.Keys;

            if (Packet.Version != 860)
            {
                context.AddPacket(Connection, new OpenSorryDialogOutgoingPacket(true, Constants.OnlyProtocol86Allowed) );

                context.Disconnect(Connection);
            }
            else
            {
                var account = new PlayerRepository().GetPlayer(Packet.Account, Packet.Password, Packet.Character);

                if (account == null)
                {
                    context.AddPacket(Connection, new OpenSorryDialogOutgoingPacket(true, Constants.AccountNameOrPasswordIsNotCorrect) );

                    context.Disconnect(Connection);
                }
                else
                {
                    Player player = context.Server.PlayerFactory.Create(account.Name);

                    Client client = new Client(context.Server);

                    client.Player = player;

                    Connection.Client = client;

                    Tile toTile = context.Server.Map.GetTile(new Position(account.CoordinateX, account.CoordinateY, account.CoordinateZ) );

                    byte toIndex = toTile.AddContent(player);

                    foreach (var observer in context.Server.GameObjects.GetPlayers() )
                    {
                        if (observer == player)
                        {
                            context.AddPacket(observer.Client.Connection, new SendInfoOutgoingPacket(player.Id, player.CanReportBugs), 

                                                                            new SetSpecialConditionOutgoingPacket(SpecialCondition.None),
                                                                            
                                                                            new SendStatusOutgoingPacket(player.Health, player.MaxHealth, 
                                                                            
                                                                                                        player.Capacity, 
                                                                                                             
                                                                                                        player.Experience, player.Level, player.LevelPercent, 
                                                                                                             
                                                                                                        player.Mana, player.MaxMana, 0, 0, player.Soul,
                                                                                                             
                                                                                                        player.Stamina),
                                                                            
                                                                            new SendSkillsOutgoingPacket(10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0),
                                                                            
                                                                            new SetEnvironmentLightOutgoingPacket(context.Server.Clock.Light),
                                                                            
                                                                            new SendTilesOutgoingPacket(context.Server.Map, player.Client, toTile.Position),
                                                                            
                                                                            new ShowMagicEffectOutgoingPacket(toTile.Position, MagicEffectType.Teleport) );
                        }
                        else
                        {
                            if (observer.Tile.Position.CanSee(toTile.Position) )
                            {
                                uint removeId;

                                if (observer.Client.CreatureCollection.IsKnownCreature(player.Id, out removeId) )
                                {
                                    context.AddPacket(observer.Client.Connection, new ThingAddOutgoingPacket(toTile.Position, toIndex, player),

                                                                                    new ShowMagicEffectOutgoingPacket(toTile.Position, MagicEffectType.Teleport) );
                                }
                                else
                                {
                                    context.AddPacket(observer.Client.Connection, new ThingAddOutgoingPacket(toTile.Position, toIndex, removeId, player),

                                                                                    new ShowMagicEffectOutgoingPacket(toTile.Position, MagicEffectType.Teleport) );
                                }
                            }
                        }                                
                    }
                }

                base.Execute(context);
            }
        }
    }
}