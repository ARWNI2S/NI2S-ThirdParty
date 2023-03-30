using NI2S.Network.Protocol;
using NI2S.Network.Protocol.Filters;
using Xunit;
using Xunit.Abstractions;

namespace NI2S.Network.Tests
{
    [Trait("Category", "Protocol.Terminator")]
    public class TerminatorProtocolTest : ProtocolTestBase
    {
        public TerminatorProtocolTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        protected override string CreateRequest(string sourceLine)
        {
            return $"{sourceLine}##";
        }

        protected override IServer CreateServer(IHostConfigurator hostConfigurator)
        {
            var server = CreateSocketServerBuilder<TextPackageInfo>((x) => new TerminatorTextPipelineFilter(new[] { (byte)'#', (byte)'#' }), hostConfigurator)
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Utf8Encoding.GetBytes(p.Text + "\r\n"));
                }).BuildAsServer() as IServer;

            return server;
        }
    }
}
