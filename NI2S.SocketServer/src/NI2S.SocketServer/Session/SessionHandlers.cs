using NI2S.Node.Network.Channel;
using System;
using System.Threading.Tasks;

namespace NI2S.Node.Network.Server
{
    public class SessionHandlers
    {
        public Func<IAppSession, ValueTask> Connected { get; set; }

        public Func<IAppSession, CloseEventArgs, ValueTask> Closed { get; set; }
    }
}