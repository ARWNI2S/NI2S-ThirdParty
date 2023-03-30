namespace NI2S.Node.Network.Server
{

    public interface IPackageHandlingContextAccessor<TPackageInfo>
    {
        PackageHandlingContext<IAppSession, TPackageInfo> PackageHandlingContext { get; set; }
    }


}
