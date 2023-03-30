using NI2S.Network.Channel;
using System.Threading.Tasks;

namespace NI2S.Network
{
    public delegate void NewClientAcceptHandler(IChannelCreator listener, IChannel channel);

    public interface IChannelCreator
    {
        ListenOptions Options { get; }

        bool Start();

        event NewClientAcceptHandler NewClientAccepted;

        Task<IChannel> CreateChannel(object connection);

        Task StopAsync();

        bool IsRunning { get; }
    }
}