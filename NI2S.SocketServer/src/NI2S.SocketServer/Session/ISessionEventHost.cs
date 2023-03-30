using NI2S.Network.Channel;
using System.Threading.Tasks;

namespace NI2S.Network.Server
{
    public interface ISessionEventHost
    {
        ValueTask HandleSessionConnectedEvent(AppSession session);

        ValueTask HandleSessionClosedEvent(AppSession session, CloseReason reason);
    }
}