using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NI2S.Network.Command;
using NI2S.Network.Protocol;

namespace NI2S.Network
{
    public static class CommandMiddlewareExtensions
    {
        public static Type GetKeyType<TPackageInfo>()
        {
            var interfaces = typeof(TPackageInfo).GetInterfaces();
            var keyInterface = interfaces.FirstOrDefault(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IKeyedPackageInfo<>));
            
            if (keyInterface == null)
                throw new Exception($"The package type {nameof(TPackageInfo)} should implement the interface {typeof(IKeyedPackageInfo<>).Name}.");

            return keyInterface.GetGenericArguments().FirstOrDefault();
        }

        private static ISocketServerHostBuilder ConfigureCommand(this ISocketServerHostBuilder builder)
        {
            return builder.ConfigureServices((hostCxt, services) =>
                {
                    services.Configure<CommandOptions>(hostCxt.Configuration?.GetSection("serverOptions")?.GetSection("commands"));
                }) as ISocketServerHostBuilder;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TPackageInfo>(this ISocketServerHostBuilder<TPackageInfo> builder)
            where TPackageInfo : class
        {
            var keyType = GetKeyType<TPackageInfo>();

            var useCommandMethod = typeof(CommandMiddlewareExtensions).GetMethod("UseCommand",  new Type[] { typeof(ISocketServerHostBuilder) });
            useCommandMethod = useCommandMethod.MakeGenericMethod(keyType, typeof(TPackageInfo));

            var hostBuilder = useCommandMethod.Invoke(null, new object[] { builder }) as ISocketServerHostBuilder;
            return hostBuilder.ConfigureCommand() as ISocketServerHostBuilder<TPackageInfo>;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TPackageInfo>(this ISocketServerHostBuilder<TPackageInfo> builder, Action<CommandOptions> configurator)
            where TPackageInfo : class
        {
             return builder.UseCommand()
                .ConfigureServices((hostCtx, services) =>
                {
                    services.Configure(configurator);
                }) as ISocketServerHostBuilder<TPackageInfo>;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TKey, TPackageInfo>(this ISocketServerHostBuilder<TPackageInfo> builder, Action<CommandOptions> configurator, IEqualityComparer<TKey> comparer)
            where TPackageInfo : class, IKeyedPackageInfo<TKey>
        {
            return builder.UseCommand(configurator)
                .ConfigureServices((hostCtx, services) =>
                {
                    services.AddSingleton<IEqualityComparer<TKey>>(comparer);
                }) as ISocketServerHostBuilder<TPackageInfo>;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TKey, TPackageInfo>(this ISocketServerHostBuilder builder)
            where TPackageInfo : class, IKeyedPackageInfo<TKey>
        {
            return builder.UseMiddleware<CommandMiddleware<TKey, TPackageInfo>>()
                .ConfigureCommand() as ISocketServerHostBuilder<TPackageInfo>;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TKey, TPackageInfo>(this ISocketServerHostBuilder builder, Action<CommandOptions> configurator)
            where TPackageInfo : class, IKeyedPackageInfo<TKey>
        {
             return builder.UseCommand<TKey, TPackageInfo>()
                .ConfigureServices((hostCtx, services) =>
                {
                    services.Configure(configurator);
                }) as ISocketServerHostBuilder<TPackageInfo>;
        }

        public static ISocketServerHostBuilder<TPackageInfo> UseCommand<TKey, TPackageInfo>(this ISocketServerHostBuilder builder, Action<CommandOptions> configurator, IEqualityComparer<TKey> comparer)
            where TPackageInfo : class, IKeyedPackageInfo<TKey>
        {
            return builder.UseCommand<TKey, TPackageInfo>(configurator)
                .ConfigureServices((hostCtx, services) =>
                {
                    services.AddSingleton<IEqualityComparer<TKey>>(comparer);
                }) as ISocketServerHostBuilder<TPackageInfo>;
        }
    }
}
