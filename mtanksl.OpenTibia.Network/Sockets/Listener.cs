﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OpenTibia.Network.Sockets
{
    public class Listener : IDisposable
    {
        private readonly object sync = new object();

            private bool stopped = false;
        
            private AutoResetEvent syncStop = new AutoResetEvent(false);

        private Func<Listener, Socket, Connection> factory;

        public Listener(Func<Listener, Socket, Connection> factory)
        {
            this.factory = factory;
        }

        ~Listener()
        {
            Dispose(false);
        }

        private HashSet<string> bannedIpAddresses = new HashSet<string>();

        public bool IsBanned(string ipAddress)
        {
            lock (sync)
            {
                return bannedIpAddresses.Contains(ipAddress);
            }
        }

        public void AddBan(string ipAddress)
        {
            lock (sync)
            {
                bannedIpAddresses.Add(ipAddress);
            }
        }

        private Socket serverSocket;
        
        public void Start(int port)
        {
            lock (sync)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    serverSocket.Bind(new IPEndPoint(IPAddress.Any, port) );

                    serverSocket.Listen(0);


                serverSocket.BeginAccept(Accept, null);
            }
        }

        private List<Connection> connections = new List<Connection>();

        private void Accept(IAsyncResult result)
        {
            lock (sync)
            {
                if (stopped)
                {
                    syncStop.Set();
                }
                else
                {
                    try
                    {
                        Socket clientSocket = serverSocket.EndAccept(result);

                        Connection connection = factory(this, clientSocket);

                        connection.Disconnected += (sender, e) =>
                        {
                            lock (sync)
                            {
                                if ( !stopped )
                                {
                                    connections.Remove(connection);

                                    connection.Dispose();
                                }
                            }
                        };

                        connections.Add(connection);

                        connection.Start();
                        

                        serverSocket.BeginAccept(Accept, null);
                    }
                    catch (SocketException)
                    {
                        //
                    }
                }
            }
        }

        public void Stop(bool wait = true)
        {
            lock (sync)
            {
                if (stopped)
                {
                    wait = false;
                }
                else
                {
                    stopped = true;

                    foreach (var connection in connections)
                    {
                        connection.Stop();
                    }

                    serverSocket.Close();
                }
            }

            if (wait)
            {
                syncStop.WaitOne();
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;

                if (disposing)
                {
                    if (connections != null)
                    {
                        foreach (var connection in connections)
                        {
                            connection.Dispose();
                        }
                    }

                    if (serverSocket != null)
                    {
                        serverSocket.Dispose();
                    }
                }
            }
        }
    }
}