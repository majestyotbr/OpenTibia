﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.Game.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTibia.Game.Components
{
    public class ScriptingConversationStrategy : IConversationStrategy
    {
        private string script;

        public ScriptingConversationStrategy(string script)
        {
            this.script = script;
        }

        private LuaScope lua;

        public void Start(Npc npc)
        {
            lua = Context.Current.Server.LuaScripts.Load("data/npcs/lib/npc.lua", "data/npcs/scripts/" + script);

                lua.RegisterFunction("npcsay", parameters =>
                {
                    return Context.Current.AddCommand(new NpcSayCommand(npc, (string)parameters[0] ) ).Then( () =>
                    {
                        return Promise.FromResult(Array.Empty<object>() );
                    } );
                } );

                lua.RegisterFunction("npcaddmoney", async parameters =>
                {
                    Player player = (Player)parameters[0];

                    int price = (int)(long)parameters[1];


                    int crystal = 0;

                    int platinum = 0;

                    int gold = 0;

                    int n = price / 10000;

                    if (n > 0)
                    {
                        price -= n * 10000;

                        crystal += n;
                    }

                    n = price / 100;

                    if (n > 0)
                    {
                        price -= n * 100;

                        platinum += n;
                    }

                    n = price / 1;

                    if (n > 0)
                    {
                        price -= n * 1;

                        gold += n;
                    }

                    while (crystal > 0)
                    {
                        byte stack = (byte)Math.Min(100, crystal);

                        await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2160, stack) );

                        crystal -= stack;
                    }

                    while (platinum > 0)
                    {
                        byte stack = (byte)Math.Min(100, platinum);

                        await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2152, stack) );

                        platinum -= stack;
                    }

                    while (gold > 0)
                    {
                        byte stack = (byte)Math.Min(100, gold);

                        await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2148, stack) );

                        gold -= stack;
                    }

                    return Array.Empty<object>();
                } );

                lua.RegisterFunction("npcdeletemoney", async parameters =>
                {
                    Player player = (Player)parameters[0];

                    int price = (int)(long)parameters[1];


                    int crystal = 0;

                    int platinum = 0;

                    int gold = 0;

                    List<Item> crystals = new List<Item>();

                    List<Item> platinums = new List<Item>();

                    List<Item> golds = new List<Item>();

                    int sum = Sum(player.Inventory, crystals, platinums, golds);

                    if (sum < price)
                    {
                        return new object[] { false };
                    }

                    int sumCrystal = crystals.Sum(i => ( (StackableItem)i).Count);

                    int sumPlatinum = platinums.Sum(i => ( (StackableItem)i).Count);

                    int sumGold = golds.Sum(i => ( (StackableItem)i).Count);

                    while (price > 0)
                    {
                        var n = Math.Min(price / 10000, sumCrystal);

                        if (n > 0)
                        {
                            price -= n * 10000;

                            sumCrystal -= n;

                            crystal -= n;
                        }

                        n = Math.Min(price / 100, sumPlatinum);

                        if (n > 0)
                        {
                            price -= n * 100;

                            sumPlatinum -= n;

                            platinum -= n;
                        }

                        n = Math.Min(price / 1, sumGold);

                        if (n > 0)
                        {
                            price -= n * 1;

                            sumGold -= n;

                            gold -= n;
                        }

                        if (price > 0)
                        {
                            if (sumPlatinum > 0)
                            {
                                sumPlatinum -= 1;

                                platinum -= 1;

                                sumGold += 100;

                                gold += 100;
                            }
                            else if (sumCrystal > 0)
                            {
                                sumCrystal -= 1;

                                crystal -= 1;

                                sumPlatinum += 100;

                                platinum += 100;
                            }
                        }
                    }

                    if (crystal > 0)
                    {
                        while (crystal > 0)
                        {
                            byte stack = (byte)Math.Min(100, crystal);

                            await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2160, stack) );

                            crystal -= stack;
                        }
                    }
                    else
                    {
                        foreach (Item item in crystals)
                        {
                            if (crystal == 0)
                            {
                                break;
                            }

                            byte stack = (byte)Math.Min( ( (StackableItem)item).Count, -crystal);

                            await Context.Current.AddCommand(new ItemDecrementCommand(item, stack) );

                            crystal += stack;
                        }
                    }

                    if (platinum > 0)
                    {
                        while (platinum > 0)
                        {
                            byte stack = (byte)Math.Min(100, platinum);

                            await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2152, stack) );

                            platinum -= stack;
                        }
                    }
                    else
                    {
                        foreach (Item item in platinums)
                        {
                            if (platinum == 0)
                            {
                                break;
                            }

                            byte stack = (byte)Math.Min( ( (StackableItem)item).Count, -platinum);

                            await Context.Current.AddCommand(new ItemDecrementCommand(item, stack) );

                            platinum += stack;
                        }
                    }

                    if (gold > 0)
                    {
                        while (gold > 0)
                        {
                            byte stack = (byte)Math.Min(100, gold);

                            await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, 2148, stack) );

                            gold -= stack;
                        }
                    }
                    else
                    {
                        foreach (Item item in golds)
                        {
                            if (gold == 0)
                            {
                                break;
                            }

                            byte stack = (byte)Math.Min( ( (StackableItem)item).Count, -gold);

                            await Context.Current.AddCommand(new ItemDecrementCommand(item, stack) );

                            gold += stack;
                        }
                    }

                    return new object[] { true };

                    int Sum(IContainer parent, List<Item> crystals, List<Item> platinums, List<Item> golds)
                    {
                        int sum = 0;

                        foreach (Item content in parent.GetContents() )
                        {
                            if (content is Container container)
                            {
                                sum += Sum(container, crystals, platinums, golds);
                            }

                            if (content.Metadata.OpenTibiaId == 2160) // Crystal coin
                            {
                                crystals.Add(content);

                                sum += ( (StackableItem)content ).Count * 10000;
                            }
                            else if (content.Metadata.OpenTibiaId == 2152) // Platinum coin
                            {
                                platinums.Add(content);

                                sum += ( (StackableItem)content ).Count * 100;
                            }
                            else if (content.Metadata.OpenTibiaId == 2148) // Gold coin
                            {
                                golds.Add(content);

                                sum += ( (StackableItem)content ).Count * 1;
                            }
                        }

                        return sum;
                    }
                } );

                lua.RegisterFunction("npcadditem", async parameters =>
                {
                    Player player = (Player)parameters[0];

                    ushort openTibiaId = (ushort)(long)parameters[1];

                    byte type = (byte)(long)parameters[2];

                    int count = (int)(long)parameters[3];


                    ItemMetadata itemMetadata = Context.Current.Server.ItemFactory.GetItemMetadata(openTibiaId);

                    if (itemMetadata.Flags.Is(ItemMetadataFlags.Stackable) )
                    {
                        while (count > 0)
                        {
                            byte stack = (byte)Math.Min(100, count);

                            await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, openTibiaId, stack) );

                            count -= stack;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            await Context.Current.AddCommand(new PlayerInventoryContainerTileCreateItemCommand(player, openTibiaId, type) );
                        }
                    }

                    return Array.Empty<object>();
                } );

                lua.RegisterFunction("npcremoveitem", async parameters =>
                {
                    Player player = (Player)parameters[0];

                    ushort openTibiaId = (ushort)(long)parameters[1];

                    byte type = (byte)(long)parameters[2];

                    int count = (int)(long)parameters[3];


                    List<Item> items = new List<Item>();

                    int sum = Sum(player.Inventory, openTibiaId, items);

                    if (sum < count)
                    {
                        return new object[] { false };
                    }

                    foreach (Item item in items)
                    {
                        if (count == 0)
                        {
                            break;
                        }

                        if (item is StackableItem stackableItem)
                        {
                            byte stack = (byte)Math.Min(stackableItem.Count, count);

                            await Context.Current.AddCommand(new ItemDecrementCommand(item, stack) );

                            count -= stack;
                        }
                        else
                        {
                            await Context.Current.AddCommand(new ItemDecrementCommand(item, 1) );

                            count -= 1;
                        }
                    }

                    return new object[] { true };

                    int Sum(IContainer parent, ushort openTibiaId, List<Item> items)
                    {
                        int sum = 0;

                        foreach (Item content in parent.GetContents() )
                        {
                            if (content is Container container)
                            {
                                sum += Sum(container, openTibiaId, items);
                            }

                            if (content.Metadata.OpenTibiaId == openTibiaId)
                            {
                                items.Add(content);

                                if (content is StackableItem stackableItem)
                                {
                                    sum += stackableItem.Count;
                                }
                                else
                                {
                                    sum += 1;
                                }
                            }
                        }

                        return sum;
                    }
                } );
        }

        public PromiseResult<bool> ShouldGreet(Npc npc, Player player, string message)
        {
            return lua.Call("shouldgreet", npc, player, message).Then(result =>
            {
                return Promise.FromResult( (bool)result[0] );
            } );
        }

        public PromiseResult<bool> ShouldFarewell(Npc npc, Player player, string message)
        {
            return lua.Call("shouldfarewell", npc, player, message).Then(result =>
            {
                return Promise.FromResult( (bool)result[0] );
            } );
        }

        public Promise OnGreet(Npc npc, Player player)
        {
            return lua.Call("ongreet", npc, player);
        }

        public Promise OnBusy(Npc npc, Player player)
        {
            return lua.Call("onbusy", npc, player);
        }

        public Promise OnSay(Npc npc, Player player, string message)
        {
            return lua.Call("onsay", npc, player, message);
        }

        public Promise OnFarewell(Npc npc, Player player)
        {
            return lua.Call("onfarewell", npc, player);
        }

        public Promise OnDismiss(Npc npc, Player player)
        {
            return lua.Call("ondismiss", npc, player);
        }

        public void Stop()
        {
            lua.Dispose();
        }
    }
}