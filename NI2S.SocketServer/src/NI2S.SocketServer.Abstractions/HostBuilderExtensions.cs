using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;


namespace NI2S.Network
{
    public static class HostBuilderExtensions
    {
        public static ISocketServerHostBuilder AsSocketServerBuilder(this IHostBuilder hostBuilder)
        {
            return hostBuilder as ISocketServerHostBuilder;
        }

        public static ISocketServerHostBuilder UseMiddleware<TMiddleware>(this ISocketServerHostBuilder builder)
            where TMiddleware : class, IMiddleware
        {
            return builder.ConfigureServices((ctx, services) =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMiddleware, TMiddleware>());
            }).AsSocketServerBuilder();
        }

        public static ISocketServerHostBuilder UseMiddleware<TMiddleware>(this ISocketServerHostBuilder builder, Func<IServiceProvider, TMiddleware> implementationFactory)
            where TMiddleware : class, IMiddleware
        {
            return builder.ConfigureServices((ctx, services) =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMiddleware, TMiddleware>(implementationFactory));
            }).AsSocketServerBuilder();
        }
        public static ISocketServerHostBuilder UseChannelCreatorFactory<TChannelCreatorFactory>(this ISocketServerHostBuilder builder)
            where TChannelCreatorFactory : class, IChannelCreatorFactory
        {
            return builder.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<IChannelCreatorFactory, TChannelCreatorFactory>();
            }).AsSocketServerBuilder();
        }
    }
}
