﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NI2S.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomProtocol
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = SocketServerHostBuilder.Create<MyPackage, MyPackageFilter>(args)
                .UsePackageHandler(async (s, p) =>
                {
                    // handle package
                    await Task.Delay(0);
                })
                .ConfigureSocketServer(options =>
                {
                    options.Name = "CustomProtocol Server";
                    options.Listeners = new List<ListenOptions>
                    {
                        new ListenOptions
                        {
                            Ip = "Any",
                            Port = 4040
                        }
                    };
                })
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                }).Build();

            await host.RunAsync();
        }
    }
}
