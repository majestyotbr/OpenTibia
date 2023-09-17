﻿namespace OpenTibia.Game
{
    public class Config
    {
        private Server server;

        public Config(Server server)
        {
            this.server = server;
        }

        private LuaScope script;

        public void Start()
        {
            script = server.LuaScripts.Create(server.PathResolver.GetFullPath("data/server/config.lua") );

            LoginPort = (int)(long)script["server.login.port"];

            GamePort = (int)(long)script["server.game.port"];

            GameMaxPlayers = (int)(long)script["server.game.maxplayers"];

            DatabaseType = (string)script["server.database.type"];

            DatabaseHost = (string)script["server.database.host"];

            DatabasePort = (int)(long)script["server.database.port"];

            DatabaseUser = (string)script["server.database.user"];

            DatabasePassword = (string)script["server.database.password"];

            DatabaseName = (string)script["server.database.name"];

            DatabaseFile = (string)script["server.database.file"];
        }

        public int LoginPort { get; set; }

        public int GamePort { get; set; }

        public int GameMaxPlayers { get; set; }

        public string DatabaseType { get; set; }

        public string DatabaseHost { get; set; }
    
        public int DatabasePort { get; set; }
    
        public string DatabaseUser { get; set; }
    
        public string DatabasePassword { get; set; }
    
        public string DatabaseName { get; set; }
        
        public string DatabaseFile { get; set; }

        public void Dispose()
        {
            script.Dispose();
        }
    }
}