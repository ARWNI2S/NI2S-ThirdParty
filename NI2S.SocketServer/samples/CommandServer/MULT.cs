using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI2S.Node.Network;
using NI2S.Node.Network.Command;
using NI2S.Node.Network.Protocol;

namespace CommandServer
{
    [Command]
    public class MULT : IAsyncCommand<StringPackageInfo>
    {

        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var result = package.Parameters
                .Select(p => int.Parse(p))
                .Aggregate((x, y) => x * y);

            await session.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
        }
    }
}
