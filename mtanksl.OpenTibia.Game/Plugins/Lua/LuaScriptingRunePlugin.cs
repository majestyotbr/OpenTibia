﻿using NLua;
using OpenTibia.Common.Objects;
using OpenTibia.Game.Commands;
using OpenTibia.Game.Plugins;

namespace OpenTibia.Game.Components
{
    public class LuaScriptingRunePlugin : RunePlugin
    {
        private string fileName;

        private LuaScope script;

        private LuaTable parameters;

        public LuaScriptingRunePlugin(string fileName, Rune rune) : base(rune)
        {
            this.fileName = fileName;
        }

        public LuaScriptingRunePlugin(LuaScope script, LuaTable parameters, Rune rune) : base(rune)
        {
            this.script = script;

            this.parameters = parameters;
        }

        public override void Start()
        {
            if (fileName != null)
            {
                script = Context.Server.LuaScripts.LoadScript(
                    Context.Server.PathResolver.GetFullPath("data/plugins/runes/" + fileName),
                    Context.Server.PathResolver.GetFullPath("data/plugins/runes/lib.lua"), 
                    Context.Server.PathResolver.GetFullPath("data/plugins/lib.lua"),
                    Context.Server.PathResolver.GetFullPath("data/lib.lua") );
            }
        }

        public override PromiseResult<bool> OnUsingRune(Player player, Creature target, Tile tile, Item item)
        {
            if (fileName != null)
            {
                return script.CallFunction("onusingrune", player, target, tile, item).Then(result =>
                {
                    return (bool)result[0] ? Promise.FromResultAsBooleanTrue : Promise.FromResultAsBooleanFalse;
                } );
            }
            else
            {
                return script.CallFunction( (LuaFunction)parameters["onusingrune"], player, target, tile, item).Then(result =>
                {
                    return (bool)result[0] ? Promise.FromResultAsBooleanTrue : Promise.FromResultAsBooleanFalse;
                } );
            }            
        }

        public override Promise OnUseRune(Player player, Creature target, Tile tile, Item item)
        {
            if (fileName != null)
            {
                return script.CallFunction("onuserune", player, target, tile, item);
            }
            else
            {
                return script.CallFunction( (LuaFunction)parameters["onuserune"], player, target, tile, item);
            }
        }

        public override void Stop()
        {
            if (fileName != null)
            {
                script.Dispose();
            }
        }
    }
}