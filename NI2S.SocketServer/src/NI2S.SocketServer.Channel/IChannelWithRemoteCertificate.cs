using System.Security.Cryptography.X509Certificates;

namespace NI2S.Node.Network.Channel
{
    public interface IChannelWithRemoteCertificate
    {
        X509Certificate RemoteCertificate { get; }
    }
}
