using System;
using System.Net.Sockets;

namespace NI2S.Network.Server
{
    class SocketOptionsSetter
    {
        public Action<Socket> Setter { get; private set; }

        public SocketOptionsSetter(Action<Socket> setter)
        {
            Setter = setter;
        }
    }
}