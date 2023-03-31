using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NI2S.Network.SessionContainer;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NI2S.Network
{
    public static class InProcSessionContainerMiddlewareExtensions
    {
        public static ISocketServerHostBuilder UseInProcSessionContainer(this ISocketServerHostBuilder builder)
        {
            return builder
                .UseMiddleware<InProcSessionContainerMiddleware>(s => s.GetRequiredService<InProcSessionContainerMiddleware>())
                .ConfigureServices((ctx, services) =>
                {
                    services.AddSingleton<InProcSessionContainerMiddleware>();
                    services.AddSingleton<ISessionContainer>((s) => s.GetRequiredService<InProcSessionContainerMiddleware>());
                    services.AddSingleton<IAsyncSessionContainer>((s) => s.GetRequiredService<ISessionContainer>().ToAsyncSessionContainer());
                }) as ISocketServerHostBuilder;
        }
    }
}
