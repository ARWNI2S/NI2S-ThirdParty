using System;
using System.Threading.Tasks;

namespace NI2S.Network
{
    public interface IServer : IServerInfo, IDisposable, IAsyncDisposable
    {
        Task<bool> StartAsync();

        Task StopAsync();
    }
}