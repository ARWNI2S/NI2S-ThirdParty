namespace NI2S.Network.Server
{

    public interface IPackageHandlingContextAccessor<TPackageInfo>
    {
        PackageHandlingContext<IAppSession, TPackageInfo> PackageHandlingContext { get; set; }
    }


}
