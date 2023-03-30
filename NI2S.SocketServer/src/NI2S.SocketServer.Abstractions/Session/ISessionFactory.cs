using System;

namespace NI2S.Node.Network
{
    public interface ISessionFactory
    {
        IAppSession Create();

        Type SessionType { get; }
    }
}