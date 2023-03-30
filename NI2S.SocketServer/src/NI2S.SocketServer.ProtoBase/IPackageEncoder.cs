using System.Buffers;

namespace NI2S.Network.Protocol
{
    public interface IPackageEncoder<in TPackageInfo>
    {
        int Encode(IBufferWriter<byte> writer, TPackageInfo pack);
    }
}