using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NI2S.Network;
using NI2S.Network.Protocol;
using NI2S.Network.Protocol.Filters;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = SocketServerHostBuilder.Create<TextPackageInfo, LinePipelineFilter>(args)
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Encoding.UTF8.GetBytes(p.Text + "\r\n"));
                })
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    // register your logging library here
                    loggingBuilder.AddConsole();
                }).Build();

            await host.RunAsync();
        }
    }
}
