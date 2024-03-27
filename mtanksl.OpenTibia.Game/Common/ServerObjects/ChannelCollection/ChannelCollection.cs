﻿using OpenTibia.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTibia.Game
{
    public class ChannelCollection
    {
        private uint statementId = 0;

        public uint GenerateStatementId(int databasePlayerId, string message)
        {
            statementId++;

            statements.Add(statementId, new Statement()
            {
                Id = statementId,

                DatabasePlayerId = databasePlayerId,

                Message = message
            } );

            return statementId;
        }

        private Dictionary<uint, Statement> statements = new Dictionary<uint, Statement>();

        public Statement GetStatement(uint statementId)
        {
            Statement statement;

            statements.TryGetValue(statementId, out statement);

            return statement;
        }

        private List<Channel> channels = new List<Channel>
        {
            new Channel() { Id = 0, Name = "Guild" },

            new Channel() { Id = 1, Name = "Party" },

            new Channel() { Id = 2, Name = "Tutor" },

            new Channel() { Id = 3, Name = "Rule Violations" },

            new Channel() { Id = 4, Name = "Gamemaster" },

            new Channel() { Id = 5, Name = "Game Chat" },

            new Channel() { Id = 6, Name = "Trade" },

            new Channel() { Id = 7, Name = "Trade-Rookgaard" },

            new Channel() { Id = 8, Name = "Real Life Chat" },

            new Channel() { Id = 9, Name = "Help" }
        };

        /// <exception cref="InvalidOperationException"></exception>
        
        private ushort GenerateId()
        {
            for (ushort id = 10; id < 65535; id++)
            {
                if ( !channels.Any(c => c.Id == id) )
                {
                    return id;
                }
            }

            throw new InvalidOperationException("Channel limit exceeded.");
        }

        public void AddChannel(Channel channel)
        {
            if (channel.Id == 0)
            {
                channel.Id = GenerateId();
            }

            channels.Add(channel);
        }

        public void RemoveChannel(Channel channel)
        {
            channels.Remove(channel);
        }

        public Channel GetChannel(int channelId)
        {
            return GetChannels()
                .Where(c => c.Id == channelId)
                .FirstOrDefault();
        }

        public PrivateChannel GetPrivateChannel(Player owner)
        {
            return GetPrivateChannels()
                .Where(c => c.Owner == owner)
                .FirstOrDefault();
        }

        public IEnumerable<Channel> GetChannels()
        {
            return channels;
        }

        public IEnumerable<PrivateChannel> GetPrivateChannels()
        {
            return GetChannels().OfType<PrivateChannel>();
        }
    }
}