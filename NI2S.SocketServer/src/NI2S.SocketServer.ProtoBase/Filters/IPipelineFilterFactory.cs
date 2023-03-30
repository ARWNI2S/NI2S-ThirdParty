namespace NI2S.Node.Network.Protocol.Filters
{
    public interface IPipelineFilterFactory<TPackageInfo>
    {
        IPipelineFilter<TPackageInfo> Create(object client);
    }
}