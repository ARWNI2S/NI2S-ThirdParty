using Microsoft.Extensions.Logging;
using NI2S.Network.Channel;

namespace NI2S.Network
{
    public interface IChannelCreatorFactory
    {
        IChannelCreator CreateChannelCreator<TPackageInfo>(ListenOptions options, ChannelOptions channelOptions, ILoggerFactory loggerFactory, object pipelineFilterFactory);
    }
}