using System;
using System.Threading.Tasks;

namespace NI2S.Network
{
    public class DelegatePackageHandler<TReceivePackageInfo> : IPackageHandler<TReceivePackageInfo>
    {

        Func<IAppSession, TReceivePackageInfo, ValueTask> _func;

        public DelegatePackageHandler(Func<IAppSession, TReceivePackageInfo, ValueTask> func)
        {
            _func = func;
        }

        public async ValueTask Handle(IAppSession session, TReceivePackageInfo package)
        {
            await _func(session, package);
        }
    }
}