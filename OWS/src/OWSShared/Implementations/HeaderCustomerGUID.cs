using System;
using OWSShared.Interfaces;

namespace OWSShared.Implementations
{
    public class HeaderCustomerGUID : IHeaderCustomerGUID
    {
        public Guid CustomerGUID { get; set; }
    }
}
