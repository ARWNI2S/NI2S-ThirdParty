using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NI2S.Node.Network.Protocol;
using NI2S.Node.Network.Server;
using NI2S.Node.Network.Channel;

namespace NI2S.Node.Network.GZip
{
    public static class HostBuilderExtensions
    {

        // move to extensions
        public static ISuperSocketHostBuilder UseGZip(this ISuperSocketHostBuilder hostBuilder)
        {
            return hostBuilder.UseChannelCreatorFactory<GZipTcpChannelCreatorFactory>();
        }

    }
}
