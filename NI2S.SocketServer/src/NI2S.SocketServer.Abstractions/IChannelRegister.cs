using System.Threading.Tasks;

namespace NI2S.Node.Network
{
    public interface IChannelRegister
    {
        Task RegisterChannel(object connection);
    }
}