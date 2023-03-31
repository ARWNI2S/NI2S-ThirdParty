using Microsoft.Extensions.DependencyInjection;
using NI2S.Network.Client;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NI2S.Network.Tests
{
    public abstract class TcpHostConfigurator : IHostConfigurator
    {
        public string WebSocketSchema { get; protected set; }

        public bool IsSecure { get; protected set; }

        public ListenOptions Listener { get; private set; }

        public virtual void Configure(ISocketServerHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((ctx, services) =>
            {
                services.Configure<ServerOptions>((options) =>
                {
                    var listener = options.Listeners[0];
                    Listener = listener;
                });
            });
        }

        public Socket CreateClient()
        {
            var serverAddress = this.GetServerEndPoint();
            var socket = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(serverAddress);
            return socket;
        }


        public TextReader GetStreamReader(Stream stream, Encoding encoding)
        {
            return new StreamReader(stream, encoding, true);
        }

        public abstract INodeClient<TPackageInfo> ConfigureEasyClient<TPackageInfo>(IPipelineFilter<TPackageInfo> pipelineFilter, ChannelOptions options)
            where TPackageInfo : class;

        public abstract ValueTask<Stream> GetClientStream(Socket socket);

        public ValueTask KeepSequence()
        {
            return new ValueTask();
        }
    }
}