using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace NI2S.Network.Channel
{
    public interface IVirtualChannel : IChannel
    {
        ValueTask<FlushResult> WritePipeDataAsync(Memory<byte> memory, CancellationToken cancellationToken);
    }
}
