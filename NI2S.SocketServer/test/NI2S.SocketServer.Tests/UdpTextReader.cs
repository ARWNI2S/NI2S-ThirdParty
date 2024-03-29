using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;

namespace NI2S.Network.Tests
{
    public class UdpTextReader : TextReader
    {
        public UdpPipeChannel<TextPackageInfo> Channel { get; }

        private IAsyncEnumerator<TextPackageInfo> _packageEnumerator;

        public UdpTextReader(UdpPipeChannel<TextPackageInfo> channel)
        {
            Channel = channel;
            _packageEnumerator = channel.RunAsync().GetAsyncEnumerator();
        }

        public override string ReadLine()
        {
            return ReadLineAsync().GetAwaiter().GetResult();
        }

        public async override Task<string> ReadLineAsync()
        {
            var ret = await _packageEnumerator.MoveNextAsync().ConfigureAwait(false);

            if (!ret)
                return null;

            return _packageEnumerator.Current?.Text;
        }
    }
}