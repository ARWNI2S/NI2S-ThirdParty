using NI2S.Network.Client;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NI2S.Network.Tests
{
    public class RegularHostConfigurator : TcpHostConfigurator
    {
        public RegularHostConfigurator()
        {
            WebSocketSchema = "ws";
        }

        public override INodeClient<TPackageInfo> ConfigureEasyClient<TPackageInfo>(IPipelineFilter<TPackageInfo> pipelineFilter, ChannelOptions options) where TPackageInfo : class
        {
            return new NodeClient<TPackageInfo>(pipelineFilter, options);
        }

        public override ValueTask<Stream> GetClientStream(Socket socket)
        {
            return new ValueTask<Stream>(new DerivedNetworkStream(socket, false));
        }
    }
}