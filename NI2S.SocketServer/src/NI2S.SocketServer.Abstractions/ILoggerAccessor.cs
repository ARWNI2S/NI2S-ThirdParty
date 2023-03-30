using Microsoft.Extensions.Logging;

namespace NI2S.Node.Network
{
    public interface ILoggerAccessor
    {
        ILogger Logger { get; }
    }
}