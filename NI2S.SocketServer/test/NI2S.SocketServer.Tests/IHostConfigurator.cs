using NI2S.Network.Client;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NI2S.Network.Tests
{
    public interface IHostConfigurator
    {
        void Configure(ISuperSocketHostBuilder hostBuilder);

        ValueTask KeepSequence();

        Socket CreateClient();

        ValueTask<Stream> GetClientStream(Socket socket);

        TextReader GetStreamReader(Stream stream, Encoding encoding);

        string WebSocketSchema { get; }

        bool IsSecure { get; }

        ListenOptions Listener { get; }

        IEasyClient<TPackageInfo> ConfigureEasyClient<TPackageInfo>(IPipelineFilter<TPackageInfo> pipelineFilter, ChannelOptions options)
            where TPackageInfo : class;
    }
}