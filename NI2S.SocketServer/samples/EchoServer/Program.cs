using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NI2S.Node.Network;
using NI2S.Node.Network.Protocol;
using NI2S.Node.Network.Protocol.Filters;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = SuperSocketHostBuilder.Create<TextPackageInfo, LinePipelineFilter>(args)
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Encoding.UTF8.GetBytes(p.Text + "\r\n"));
                })
                .ConfigureSuperSocket(options =>
                {
                    options.Name = "Echo Server";
                    options.AddListener(new ListenOptions
                    {
                        Ip = "Any",
                        Port = 4040
                    }
                    );
                })
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
