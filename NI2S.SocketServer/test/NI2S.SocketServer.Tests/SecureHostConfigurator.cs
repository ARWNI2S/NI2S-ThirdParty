using Microsoft.Extensions.DependencyInjection;
using NI2S.Network.Client;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace NI2S.Network.Tests
{
    public class SecureHostConfigurator : TcpHostConfigurator
    {
        public SecureHostConfigurator()
        {
            WebSocketSchema = "wss";
            IsSecure = true;
        }

        public override void Configure(ISocketServerHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((ctx, services) =>
            {
                services.Configure<ServerOptions>((options) =>
                {
                    var listener = options.Listeners[0];

                    if (listener.Security == SslProtocols.None)
                        listener.Security = GetServerEnabledSslProtocols();

                    listener.CertificateOptions = new CertificateOptions
                    {
                        FilePath = "arwniis.pfx",
                        Password = "AK47@ffline"
                    };
                });
            });

            base.Configure(hostBuilder);
        }
        public override async ValueTask<Stream> GetClientStream(Socket socket)
        {
            var stream = new SslStream(new DerivedNetworkStream(socket), false);
            var options = new SslClientAuthenticationOptions();
            options.TargetHost = "arwniis";
            options.EnabledSslProtocols = GetClientEnabledSslProtocols();
            options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            await stream.AuthenticateAsClientAsync(options);
            return stream;
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
            var client = new NodeClient<TPackageInfo>(pipelineFilter, options);
            client.Security = new SecurityOptions
            {
                TargetHost = "arwniis",
                EnabledSslProtocols = GetClientEnabledSslProtocols(),
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            return client;
        }
    }

    public class TLS13OnlySecureHostConfigurator : SecureHostConfigurator
    {
        protected override SslProtocols GetServerEnabledSslProtocols()
        {
            return SslProtocols.Tls13;
        }

        protected override SslProtocols GetClientEnabledSslProtocols()
        {
            return SslProtocols.Tls13;
        }
    }
}