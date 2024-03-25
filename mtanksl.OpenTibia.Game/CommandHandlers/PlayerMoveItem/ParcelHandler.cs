﻿using OpenTibia.Common.Objects;
using OpenTibia.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTibia.Game.CommandHandlers
{
    public class ParcelHandler : CommandHandler<PlayerMoveItemCommand>
    {
        private ushort parcel = 2595;

        private ushort label = 2599;

        private HashSet<ushort> mailbox = new HashSet<ushort>() { 2593, 3981 };

        private ushort stampedParcel = 2596;

        public override Promise Handle(Func<Promise> next, PlayerMoveItemCommand command)
        {
            if (command.Item.Metadata.OpenTibiaId == parcel && command.ToContainer is Tile toTile && toTile.TopItem != null && mailbox.Contains(toTile.TopItem.Metadata.OpenTibiaId) )
            {
                Container parcelItem = (Container)command.Item;

                ReadableItem labelItem = (ReadableItem)parcelItem.GetItems().Where(i => i.Metadata.OpenTibiaId == label).FirstOrDefault();

                if (labelItem != null)
                {
                    if (labelItem.Text != null)
                    {
                        string[] text = labelItem.Text.Split('\n');

                        if (text.Length >= 2)
                        {
                            string townName = text[1];

                            Town town = Context.Server.Map.GetTown(townName);

                            if (town != null)
                            {
                                string playerName = text[0];

                                Player player = Context.Server.GameObjectPool.GetPlayer(playerName);

                                if (player != null)
                                {
                                    Locker locker = Context.Server.Lockers.GetLocker(player.DatabasePlayerId, (ushort)town.Id);

                                    if (locker == null)
                                    {
                                        locker = (Locker)Context.Server.ItemFactory.Create(2591, 1);

                                        locker.TownId = (ushort)town.Id;

                                        Context.Server.ItemFactory.Attach(locker);

                                        Item depot = Context.Server.ItemFactory.Create(2594, 1);

                                        Context.Server.ItemFactory.Attach(depot);

                                        locker.AddContent(depot);

                                        Context.Server.Lockers.AddLocker(command.Player.DatabasePlayerId, locker);
                                    }

                                    if (locker.Count < locker.Metadata.Capacity)
                                    {
                                        //TODO: Close containers

                                        return Context.AddCommand(new ItemTransformCommand(parcelItem, stampedParcel, 1) ).Then( (item) =>
                                        {
                                            return Context.AddCommand(new ItemMoveCommand(item, locker, 0) );
                                        } );
                                    }
                                }
                                else
                                {
                                    //TODO: Load player from database, add parcel to locker
                                }
                            }
                        }
                    }
                }
            }

            return next();
        }
    }
}