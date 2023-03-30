using Microsoft.Extensions.Logging;
using NI2S.Node.Network.Channel;

namespace NI2S.Node.Network
{
    public interface IChannelCreatorFactory
    {
        IChannelCreator CreateChannelCreator<TPackageInfo>(ListenOptions options, ChannelOptions channelOptions, ILoggerFactory loggerFactory, object pipelineFilterFactory);
    }
}