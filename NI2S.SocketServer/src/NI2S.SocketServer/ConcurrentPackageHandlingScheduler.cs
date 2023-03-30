using System.Threading.Tasks;

namespace NI2S.Node.Network.Server
{
    public class ConcurrentPackageHandlingScheduler<TPackageInfo> : PackageHandlingSchedulerBase<TPackageInfo>
    {
        public override ValueTask HandlePackage(IAppSession session, TPackageInfo package)
        {
            HandlePackageInternal(session, package).DoNotAwait();
            return new ValueTask();
        }
    }
}