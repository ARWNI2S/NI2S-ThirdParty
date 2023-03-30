using NI2S.Node.Network.Channel;
using System.Threading.Tasks;

namespace NI2S.Node.Network.Server
{
    public interface ISessionEventHost
    {
        ValueTask HandleSessionConnectedEvent(AppSession session);

        ValueTask HandleSessionClosedEvent(AppSession session, CloseReason reason);
    }
}