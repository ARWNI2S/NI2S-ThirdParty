using System;
using System.Threading.Tasks;

namespace NI2S.Node.Network.Command
{
    public interface IPackageMapper<PackageFrom, PackageTo>
    {
        PackageTo Map(PackageFrom package);
    }
}
