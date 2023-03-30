using System.Threading.Tasks;

namespace NI2S.Node.Network
{
    public interface IPackageHandler<TReceivePackageInfo>
    {
        ValueTask Handle(IAppSession session, TReceivePackageInfo package);
    }
}