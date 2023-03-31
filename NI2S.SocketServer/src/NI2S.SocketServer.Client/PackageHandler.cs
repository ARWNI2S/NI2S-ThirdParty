using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NI2S.Network.Client
{
    public delegate ValueTask PackageHandler<TReceivePackage>(NodeClient<TReceivePackage> sender, TReceivePackage package)
        where TReceivePackage : class;
}