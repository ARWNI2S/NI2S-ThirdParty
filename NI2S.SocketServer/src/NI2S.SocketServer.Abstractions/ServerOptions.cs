using NI2S.Node.Network.Channel;
using System.Collections.Generic;
using System.Text;

namespace NI2S.Node.Network
{
    public class ServerOptions : ChannelOptions
    {
        public string Name { get; set; }

        public List<ListenOptions> Listeners { get; set; }

        public Encoding DefaultTextEncoding { get; set; }

        public int ClearIdleSessionInterval { get; set; } = 120;

        public int IdleSessionTimeOut { get; set; } = 300;
    }
}