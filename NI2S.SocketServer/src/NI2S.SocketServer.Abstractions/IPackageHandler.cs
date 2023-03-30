using System.Threading.Tasks;

namespace NI2S.Network
{
    public interface IPackageHandler<TReceivePackageInfo>
    {
        ValueTask Handle(IAppSession session, TReceivePackageInfo package);
    }
}