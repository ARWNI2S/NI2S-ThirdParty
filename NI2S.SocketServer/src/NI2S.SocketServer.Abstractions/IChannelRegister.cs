using System.Threading.Tasks;

namespace NI2S.Network
{
    public interface IChannelRegister
    {
        Task RegisterChannel(object connection);
    }
}