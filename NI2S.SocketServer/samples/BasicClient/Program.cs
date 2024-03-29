﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using NI2S.Network.Client;
using NI2S.Network.Protocol;

namespace BasicClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new NodeClient<MyPackage>(new MyPackageFilter()).AsClient();

            if (!await client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 4040)))
            {
                Console.WriteLine("Failed to connect the target server.");
                return;
            }

            while (true)
            {
                var p = await client.ReceiveAsync();

                if (p == null) // connection dropped
                    break;
                
                Console.WriteLine(p.Body);
            }
        }
    }
}
