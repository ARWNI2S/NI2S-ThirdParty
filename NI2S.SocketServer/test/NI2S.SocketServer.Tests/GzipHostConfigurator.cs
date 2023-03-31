using Microsoft.Extensions.DependencyInjection;
using NI2S.Network.Client;
using NI2S.Network.Channel;
using NI2S.Network.GZip;
using NI2S.Network.Protocol;
using System.IO;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace NI2S.Network.Tests
{
    public class GzipHostConfigurator : TcpHostConfigurator
    {
        public GzipHostConfigurator()
        {
            WebSocketSchema = "wss";
            IsSecure = false;
        }

        public override void Configure(ISocketServerHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((ctx, services) =>
            {
                services.Configure<ServerOptions>((options) =>
                {
                    var listener = options.Listeners[0];

                });
            });
            hostBuilder.UseGZip();

            base.Configure(hostBuilder);
        }
        public override ValueTask<Stream> GetClientStream(Socket socket)
        {
            Stream stream = new GZipReadWriteStream(new NetworkStream(socket, false), false);
            return new ValueTask<Stream>(stream);
        }

        protected virtual SslProtocols GetServerEnabledSslProtocols()
        {
            return SslProtocols.Tls13 | SslProtocols.Tls12 | SslProtocols.Tls11;
        }

        protected virtual SslProtocols GetClientEnabledSslProtocols()
        {
            return SslProtocols.Tls13 | SslProtocols.Tls12 | SslProtocols.Tls11;
        }

        public override INodeClient<TPackageInfo> ConfigureEasyClient<TPackageInfo>(IPipelineFilter<TPackageInfo> pipelineFilter, ChannelOptions options) where TPackageInfo : class
        {
            return new GZipEasyClient<TPackageInfo>(pipelineFilter, options);
        }
    }

}