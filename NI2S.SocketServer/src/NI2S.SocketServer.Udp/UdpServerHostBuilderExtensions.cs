using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NI2S.Network.SessionContainer;
using NI2S.Network.Udp;


namespace NI2S.Network
{
    public static class UdpServerHostBuilderExtensions
    {
        public static ISocketServerHostBuilder<TReceivePackage> UseUdp<TReceivePackage>(this ISocketServerHostBuilder<TReceivePackage> hostBuilder)
        {
            return (hostBuilder as ISocketServerHostBuilder).UseUdp() as ISocketServerHostBuilder<TReceivePackage>;
        }

        public static ISocketServerHostBuilder UseUdp(this ISocketServerHostBuilder hostBuilder)
        {
            return (hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IChannelCreatorFactory, UdpChannelCreatorFactory>();                
            }) as ISocketServerHostBuilder)
            .ConfigureSupplementServices((context, services) =>
            {
                if (!services.Any(s => s.ServiceType == typeof(IUdpSessionIdentifierProvider)))
                {
                    services.AddSingleton<IUdpSessionIdentifierProvider, IPAddressUdpSessionIdentifierProvider>();
                }

                if (!services.Any(s => s.ServiceType == typeof(IAsyncSessionContainer)))
                {
                    services.TryAddEnumerable(ServiceDescriptor.Singleton<IMiddleware, InProcSessionContainerMiddleware>(s => s.GetRequiredService<InProcSessionContainerMiddleware>()));
                    services.AddSingleton<InProcSessionContainerMiddleware>();
                    services.AddSingleton<ISessionContainer>((s) => s.GetRequiredService<InProcSessionContainerMiddleware>());
                    services.AddSingleton<IAsyncSessionContainer>((s) => s.GetRequiredService<ISessionContainer>().ToAsyncSessionContainer());
                }
            });
        }
    }
}