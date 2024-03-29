using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NI2S.Network
{
    public interface IAppSession
    {
        string SessionID { get; }

        DateTimeOffset StartTime { get; }

        DateTimeOffset LastActiveTime { get; }

        IChannel Channel { get; }

        EndPoint RemoteEndPoint { get; }

        EndPoint LocalEndPoint { get; }

        ValueTask SendAsync(ReadOnlyMemory<byte> data);

        ValueTask SendAsync<TPackage>(IPackageEncoder<TPackage> packageEncoder, TPackage package);

        ValueTask CloseAsync(CloseReason reason);

        IServerInfo Server { get; }

        event AsyncEventHandler Connected;

        event AsyncEventHandler<CloseEventArgs> Closed;

        object DataContext { get; set; }

        void Initialize(IServerInfo server, IChannel channel);

        object this[object name] { get; set; }

        SessionState State { get; }

        void Reset();
    }
}