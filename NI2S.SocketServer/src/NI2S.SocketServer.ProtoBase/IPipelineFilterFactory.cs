namespace NI2S.Node.Network.Protocol
{
    public interface IPipelineFilterFactory<TPackageInfo>
    {
        IPipelineFilter<TPackageInfo> Create(object client);
    }
}