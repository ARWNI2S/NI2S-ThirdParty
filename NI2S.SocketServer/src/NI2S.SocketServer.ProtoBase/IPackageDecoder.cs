using System.Buffers;

namespace NI2S.Network.Protocol
{
    public interface IPackageDecoder<out TPackageInfo>
    {
        TPackageInfo Decode(ref ReadOnlySequence<byte> buffer, object context);
    }
}