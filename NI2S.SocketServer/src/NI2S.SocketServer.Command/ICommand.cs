﻿using System;
using System.Threading.Tasks;
using NI2S.Network.Protocol;

namespace NI2S.Network.Command
{
    public interface ICommand
    {
        // empty interface
    }

    public interface ICommand<TPackageInfo> : ICommand<IAppSession, TPackageInfo>
    {

    }

    public interface ICommand<TAppSession, TPackageInfo> : ICommand
        where TAppSession : IAppSession
    {
        void Execute(TAppSession session, TPackageInfo package);
    }

    public interface IAsyncCommand<TPackageInfo> : IAsyncCommand<IAppSession, TPackageInfo>
    {

    }

    public interface IAsyncCommand<TAppSession, TPackageInfo> : ICommand
        where TAppSession : IAppSession
    {
        ValueTask ExecuteAsync(TAppSession session, TPackageInfo package);
    }
}
