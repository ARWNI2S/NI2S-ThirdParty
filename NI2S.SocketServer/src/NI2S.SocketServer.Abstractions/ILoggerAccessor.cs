using Microsoft.Extensions.Logging;

namespace NI2S.Network
{
    public interface ILoggerAccessor
    {
        ILogger Logger { get; }
    }
}