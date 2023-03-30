using System.Threading.Tasks;

namespace NI2S.Network.Server
{
    public class SerialPackageHandlingScheduler<TPackageInfo> : PackageHandlingSchedulerBase<TPackageInfo>
    {
        public override async ValueTask HandlePackage(IAppSession session, TPackageInfo package)
        {
            await HandlePackageInternal(session, package);
        }
    }
}