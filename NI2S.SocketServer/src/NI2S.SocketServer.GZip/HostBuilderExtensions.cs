using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NI2S.Network.Protocol;
using NI2S.Network.Server;
using NI2S.Network.Channel;

namespace NI2S.Network.GZip
{
    public static class HostBuilderExtensions
    {

        // move to extensions
        public static ISocketServerHostBuilder UseGZip(this ISocketServerHostBuilder hostBuilder)
        {
            return hostBuilder.UseChannelCreatorFactory<GZipTcpChannelCreatorFactory>();
        }

    }
}
