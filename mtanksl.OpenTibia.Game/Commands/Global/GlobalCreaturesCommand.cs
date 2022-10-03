﻿using OpenTibia.Game.Components;

namespace OpenTibia.Game.Commands
{
    public class GlobalCreaturesCommand : Command
    {
        public override void Execute(Context context)
        {
            foreach (var creature in context.Server.GameObjects.GetMonsters() )
            {
                foreach (var component in creature.GetComponents<TimeBehaviour>() )
                {
                    component.Update(context);
                }
            }

            foreach (var creature in context.Server.GameObjects.GetNpcs() )
            {
                foreach (var component in creature.GetComponents<TimeBehaviour>() )
                {
                    component.Update(context);
                }
            }

            foreach (var creature in context.Server.GameObjects.GetPlayers() )
            {
                foreach (var component in creature.GetComponents<TimeBehaviour>() )
                {
                    component.Update(context);
                }
            }

            OnComplete(context);
        }
    }
}