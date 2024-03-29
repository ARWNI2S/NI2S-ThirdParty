using System;

namespace NI2S.Network
{
    public class PackageHandlingException<TPackageInfo> : Exception
    {
        public TPackageInfo Package { get; private set; }

        public PackageHandlingException(string message, TPackageInfo package, Exception e)
            : base(message, e)
        {
            Package = package;
        }
    }
}