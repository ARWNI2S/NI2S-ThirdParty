using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NI2S.Network.Channel;
using NI2S.Network.Protocol;
using NI2S.Network.Protocol.Filters;
using NI2S.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NI2S.Network
{
    public static class HostBuilderExtensions
    {
        public static ISocketServerHostBuilder<TReceivePackage> AsSocketServerHostBuilder<TReceivePackage>(this IHostBuilder hostBuilder)
        {
            if (hostBuilder is ISocketServerHostBuilder<TReceivePackage> ssHostBuilder)
            {
                return ssHostBuilder;
            }

            return new SocketServerHostBuilder<TReceivePackage>(hostBuilder);
        }

        public static ISocketServerHostBuilder<TReceivePackage> AsSocketServerHostBuilder<TReceivePackage, TPipelineFilter>(this IHostBuilder hostBuilder)
            where TPipelineFilter : IPipelineFilter<TReceivePackage>, new()
        {
            if (hostBuilder is ISocketServerHostBuilder<TReceivePackage> ssHostBuilder)
            {
                return ssHostBuilder;
            }

            return (new SocketServerHostBuilder<TReceivePackage>(hostBuilder))
                .UsePipelineFilter<TPipelineFilter>();
        }

        public static ISocketServerHostBuilder<TReceivePackage> UsePipelineFilterFactory<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Func<object, IPipelineFilter<TReceivePackage>> filterFactory)
        {
            hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<Func<object, IPipelineFilter<TReceivePackage>>>(filterFactory);
                }
            );

            return hostBuilder.UsePipelineFilterFactory<DelegatePipelineFilterFactory<TReceivePackage>>();
        }

        public static ISocketServerHostBuilder<TReceivePackage> UseClearIdleSession<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder)
        {
            return hostBuilder.UseMiddleware<ClearIdleSessionMiddleware>();
        }

        public static ISocketServerHostBuilder<TReceivePackage> UseSessionHandler<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Func<IAppSession, ValueTask> onConnected = null, Func<IAppSession, CloseEventArgs, ValueTask> onClosed = null)
        {
            return hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<SessionHandlers>(new SessionHandlers
                    {
                        Connected = onConnected,
                        Closed = onClosed
                    });
                }
            );
        }

        public static ISocketServerHostBuilder<TReceivePackage> ConfigureSocketServer<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Action<ServerOptions> configurator)
        {
            return hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.Configure<ServerOptions>(configurator);
                }
            );
        }

        public static ISocketServerHostBuilder<TReceivePackage> ConfigureSocketOptions<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Action<Socket> socketOptionsSetter)
            where TReceivePackage : class
        {
            return hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<SocketOptionsSetter>(new SocketOptionsSetter(socketOptionsSetter));
                }
            );
        }

        public static IServer BuildAsServer(this IHostBuilder hostBuilder)
        {
            var host = hostBuilder.Build();
            return host.AsServer();
        }

        public static IServer AsServer(this IHost host)
        {
            return host.Services.GetService<IEnumerable<IHostedService>>().OfType<IServer>().FirstOrDefault();
        }

        public static ISocketServerHostBuilder<TReceivePackage> ConfigureErrorHandler<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Func<IAppSession, PackageHandlingException<TReceivePackage>, ValueTask<bool>> errorHandler)
        {
            return hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<Func<IAppSession, PackageHandlingException<TReceivePackage>, ValueTask<bool>>>(errorHandler);
                }
            );
        }

        // move to extensions
        public static ISocketServerHostBuilder<TReceivePackage> UsePackageHandler<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder, Func<IAppSession, TReceivePackage, ValueTask> packageHandler, Func<IAppSession, PackageHandlingException<TReceivePackage>, ValueTask<bool>> errorHandler = null)
        {
            return hostBuilder.ConfigureServices(
                (hostCtx, services) =>
                {
                    if (packageHandler != null)
                        services.AddSingleton<IPackageHandler<TReceivePackage>>(new DelegatePackageHandler<TReceivePackage>(packageHandler));

                    if (errorHandler != null)
                        services.AddSingleton<Func<IAppSession, PackageHandlingException<TReceivePackage>, ValueTask<bool>>>(errorHandler);
                }
            );
        }

        public static MultipleServerHostBuilder AsMultipleServerHostBuilder(this IHostBuilder hostBuilder)
        {
            return new MultipleServerHostBuilder(hostBuilder);
        }

        public static IMinimalApiHostBuilder AsMinimalApiHostBuilder(this ISocketServerHostBuilder hostBuilder)
        {
            return hostBuilder;
        }
    }
}
