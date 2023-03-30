namespace NI2S.Node.Network.Protocol
{
    public interface IKeyedPackageInfo<TKey>
    {
        TKey Key { get; }
    }
}
