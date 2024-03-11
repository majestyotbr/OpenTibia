﻿using OpenTibia.Common.Objects;
using OpenTibia.Game.Commands;
using OpenTibia.Game.Events;
using System;
using System.Linq;

namespace OpenTibia.Game.Components
{
    public class ChannelNpcThinkBehaviour : Behaviour
    {
        private DialoguePlugin dialoguePlugin;

        private IWalkStrategy walkStrategy;

        public ChannelNpcThinkBehaviour(DialoguePlugin dialoguePlugin, IWalkStrategy walkStrategy)
        {
            this.dialoguePlugin = dialoguePlugin;

            this.walkStrategy = walkStrategy;
        }

        private QueueHashSet<Player> queue = new QueueHashSet<Player>();

        private async Promise Add(Player player)
        {
            Npc npc = (Npc)GameObject;

            if (queue.Add(player) )
            {
                await dialoguePlugin.OnEnqueue(npc, player);
            }
        }

        private async Promise Remove(Player player)
        {
            Npc npc = (Npc)GameObject;

            if (queue.Remove(player) )
            {
                await dialoguePlugin.OnDequeue(npc, player);
            }
        }

        public async Promise Idle(Player player)
        {
            Npc npc = (Npc)GameObject;

            await Remove(player);
        }

        public async Promise Farewell(Player player)
        {
            Npc npc = (Npc)GameObject;

            await Remove(player);

            await dialoguePlugin.OnFarewell(npc, player);
        }

        public async Promise Disappear(Player player)
        {
            Npc npc = (Npc)GameObject;

            await Remove(player);

            await dialoguePlugin.OnDisappear(npc, player);
        }

        private Guid playerSay;

        private Guid globalTick;

        public override void Start()
        {
            Npc npc = (Npc)GameObject;

            playerSay = Context.Server.EventHandlers.Subscribe<PlayerSayEventArgs>(async (context, e) =>
            {
                Player player = e.Player;

                if (npc.Tile.Position.IsInRange(player.Tile.Position, 3) )
                {               
                    string message = e.Message;

                    if ( !queue.Contains(player) )
                    {
                        if (await dialoguePlugin.ShouldGreet(npc, player, message) )
                        {
                            await Add(player);

                            await dialoguePlugin.OnGreet(npc, player);
                        }
                    }
                    else
                    {
                        if (await dialoguePlugin.ShouldFarewell(npc, player, message) )
                        {
                            await Farewell(player);
                        }
                        else
                        {
                            await dialoguePlugin.OnSay(npc, player, message);
                        }
                    }
                }
            } );

            globalTick = Context.Server.EventHandlers.Subscribe<GlobalTickEventArgs>(async (context, e) =>
            {
                foreach (var player in queue.ToList() )
                {
                    if (player.Tile == null || player.IsDestroyed || !npc.Tile.Position.IsInRange(player.Tile.Position, 3) )
                    {
                        await Disappear(player);
                    }
                }

                if (queue.Count == 0)
                {
                    CreatureWalkBehaviour creatureWalkBehaviour = Context.Server.GameObjectComponents.GetComponent<CreatureWalkBehaviour>(npc);

                    if (creatureWalkBehaviour == null)
                    {
                        Context.Server.GameObjectComponents.AddComponent(npc, new CreatureWalkBehaviour(walkStrategy, null) );
                    }

                    CreatureFocusBehaviour creatureFocusBehaviour = Context.Server.GameObjectComponents.GetComponent<CreatureFocusBehaviour>(npc);

                    if (creatureFocusBehaviour != null)
                    {
                        Context.Server.GameObjectComponents.RemoveComponent(npc, creatureFocusBehaviour);
                    }
                }
                else
                {
                    Player target = queue.Peek();

                    CreatureWalkBehaviour creatureWalkBehaviour = Context.Server.GameObjectComponents.GetComponent<CreatureWalkBehaviour>(npc);

                    if (creatureWalkBehaviour != null)
                    {
                        Context.Server.GameObjectComponents.RemoveComponent(npc, creatureWalkBehaviour);
                    }

                    CreatureFocusBehaviour creatureFocusBehaviour = Context.Server.GameObjectComponents.GetComponent<CreatureFocusBehaviour>(npc);

                    if (creatureFocusBehaviour == null || creatureFocusBehaviour.Target != target)
                    {
                        Context.Server.GameObjectComponents.AddComponent(npc, new CreatureFocusBehaviour(target) );
                    }
                }
            } );
        }

        public override void Stop()
        {
            Context.Server.EventHandlers.Unsubscribe<PlayerSayEventArgs>(playerSay);

            Context.Server.EventHandlers.Unsubscribe<GlobalTickEventArgs>(globalTick);
        }
    }
}