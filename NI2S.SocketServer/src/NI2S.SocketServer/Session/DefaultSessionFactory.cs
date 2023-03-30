using System;

namespace NI2S.Node.Network.Server
{
    class DefaultSessionFactory : ISessionFactory
    {
        public Type SessionType => typeof(AppSession);

        public IAppSession Create()
        {
            return new AppSession();
        }
    }
}