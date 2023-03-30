using NI2S.Node.Network.Protocol;
using System.IO.Pipelines;

namespace NI2S.Node.Network.Channel
{
    public interface IPipeChannel
    {
        Pipe In { get; }

        Pipe Out { get; }

        IPipelineFilter PipelineFilter { get; }
    }
}
