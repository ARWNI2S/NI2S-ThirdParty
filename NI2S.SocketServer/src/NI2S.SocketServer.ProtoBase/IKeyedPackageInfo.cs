namespace NI2S.Network.Protocol
{
    public interface IKeyedPackageInfo<TKey>
    {
        TKey Key { get; }
    }
}
