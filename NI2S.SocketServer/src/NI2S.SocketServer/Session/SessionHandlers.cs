using NI2S.Network.Channel;
using System;
using System.Threading.Tasks;

namespace NI2S.Network.Server
{
    public class SessionHandlers
    {
        public Func<IAppSession, ValueTask> Connected { get; set; }

        public Func<IAppSession, CloseEventArgs, ValueTask> Closed { get; set; }
    }
}