using NI2S.Network.Protocol;
using System.IO.Pipelines;

namespace NI2S.Network.Channel
{
    public interface IPipeChannel
    {
        Pipe In { get; }

        Pipe Out { get; }

        IPipelineFilter PipelineFilter { get; }
    }
}
