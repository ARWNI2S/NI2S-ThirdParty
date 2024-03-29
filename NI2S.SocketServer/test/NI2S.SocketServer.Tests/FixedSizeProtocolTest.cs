using NI2S.Network.Protocol;
using NI2S.Network.Protocol.Filters;
using System.Buffers;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace NI2S.Network.Tests
{
    [Trait("Category", "Protocol.FixedSize")]
    public class FixedSizeProtocolTest : ProtocolTestBase
    {
        public FixedSizeProtocolTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        class MyFixedSizePipelineFilter : FixedSizePipelineFilter<TextPackageInfo>
        {
            public MyFixedSizePipelineFilter()
                : base(36)
            {

            }

            protected override TextPackageInfo DecodePackage(ref ReadOnlySequence<byte> buffer)
            {
                return new TextPackageInfo { Text = buffer.GetString(Encoding.UTF8) };
            }
        }

        protected override string CreateRequest(string sourceLine)
        {
            return sourceLine;
        }

        protected override IServer CreateServer(IHostConfigurator hostConfigurator)
        {
            var server = CreateSocketServerBuilder<TextPackageInfo, MyFixedSizePipelineFilter>(hostConfigurator)
                .UsePackageHandler(async (s, p) =>
                {
                    await s.SendAsync(Utf8Encoding.GetBytes(p.Text + "\r\n"));
                }).BuildAsServer() as IServer;

            return server;
        }
    }
}
