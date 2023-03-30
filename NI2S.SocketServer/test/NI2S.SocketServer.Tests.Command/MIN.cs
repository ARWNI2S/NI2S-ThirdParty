using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI2S.Node.Network;
using NI2S.Node.Network.Command;
using NI2S.Node.Network.Protocol;

namespace NI2S.Node.Network.Tests.Command
{
    public class MIN : IAsyncCommand<IAppSession, StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {            
            var result = package.Parameters
                .Select(p => int.Parse(p)).OrderBy(x => x).FirstOrDefault();

            await session.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
        }
    }
}
