using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI2S.Network;
using NI2S.Network.Command;
using NI2S.Network.Protocol;

namespace CommandServer
{
    [Command("add")]
    public class ADD : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var result = package.Parameters
                .Select(p => int.Parse(p))
                .Sum();

            await session.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
        }
    }
}
