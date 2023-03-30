namespace NI2S.Network.Protocol
{
    public interface IPipelineFilterFactory<TPackageInfo>
    {
        IPipelineFilter<TPackageInfo> Create(object client);
    }
}