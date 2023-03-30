using System;

namespace NI2S.Network
{
    public interface ISessionFactory
    {
        IAppSession Create();

        Type SessionType { get; }
    }
}