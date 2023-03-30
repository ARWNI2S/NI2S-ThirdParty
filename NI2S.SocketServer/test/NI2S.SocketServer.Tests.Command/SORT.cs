using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI2S.Node.Network;
using NI2S.Node.Network.Command;
using NI2S.Node.Network.Protocol;

namespace NI2S.Node.Network.Tests.Command
{
    public class SORT : IAsyncCommand<IAppSession, StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {            
            var result = string.Join(' ', package.Parameters
                .Select(p => int.Parse(p)).OrderBy(x => x).Select(x => x.ToString()));

            await session.SendAsync(Encoding.UTF8.GetBytes($"{nameof(SORT)} {result}\r\n"));
        }
    }
}
