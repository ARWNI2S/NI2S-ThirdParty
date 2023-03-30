using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NI2S.Node.Network.Command
{
    public interface ICommandSource
    {
        IEnumerable<Type> GetCommandTypes(Predicate<Type> criteria);
    }
}
