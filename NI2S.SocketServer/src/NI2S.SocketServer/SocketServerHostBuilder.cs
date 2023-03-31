using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NI2S.Network.Protocol;
using NI2S.Network.Protocol.Filters;
using NI2S.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NI2S.Network
{
    public class SocketServerHostBuilder<TReceivePackage> : HostBuilderAdapter<SocketServerHostBuilder<TReceivePackage>>, ISocketServerHostBuilder<TReceivePackage>, IHostBuilder
    {
        private Func<HostBuilderContext, IConfiguration, IConfiguration> _serverOptionsReader;

        protected List<Action<HostBuilderContext, IServiceCollection>> ConfigureServicesActions { get; private set; } = new List<Action<HostBuilderContext, IServiceCollection>>();

        protected List<Action<HostBuilderContext, IServiceCollection>> ConfigureSupplementServicesActions = new List<Action<HostBuilderContext, IServiceCollection>>();

        public SocketServerHostBuilder(IHostBuilder hostBuilder)
            : base(hostBuilder)
        {

        }

        public SocketServerHostBuilder()
            : this(args: null)
        {

        }

        public SocketServerHostBuilder(string[] args)
            : base(args)
        {

        }

        private void ConfigureHostBuilder()
        {
            HostBuilder.ConfigureServices((ctx, services) =>
            {
                RegisterBasicServices(ctx, services, services);
            }).ConfigureServices((ctx, services) =>
            {
                foreach (var action in ConfigureServicesActions)
                {
                    action(ctx, services);
                }

                foreach (var action in ConfigureSupplementServicesActions)
                {
                    action(ctx, services);
                }
            }).ConfigureServices((ctx, services) =>
            {
                RegisterDefaultServices(ctx, services, services);
            });
        }

        void IMinimalApiHostBuilder.ConfigureHostBuilder()
        {
            ConfigureHostBuilder();
        }

        public override IHost Build()
        {
            ConfigureHostBuilder();
            return HostBuilder.Build();
        }

        public ISocketServerHostBuilder<TReceivePackage> ConfigureSupplementServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            ConfigureSupplementServicesActions.Add(configureDelegate);
            return this;
        }

        ISocketServerHostBuilder ISocketServerHostBuilder.ConfigureSupplementServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            return ConfigureSupplementServices(configureDelegate);
        }

        protected virtual void RegisterBasicServices(HostBuilderContext builderContext, IServiceCollection servicesInHost, IServiceCollection services)
        {
            var serverOptionReader = _serverOptionsReader;

            if (serverOptionReader == null)
            {
                serverOptionReader = (ctx, config) =>
                {
                    return config;
                };
            }

            services.AddOptions();

            var config = builderContext.Configuration.GetSection("serverOptions");
            var serverConfig = serverOptionReader(builderContext, config);

            services.Configure<ServerOptions>(serverConfig);
        }

        protected virtual void RegisterDefaultServices(HostBuilderContext builderContext, IServiceCollection servicesInHost, IServiceCollection services)
        {
            // if the package type is StringPackageInfo
            if (typeof(TReceivePackage) == typeof(StringPackageInfo))
            {
                services.TryAdd(ServiceDescriptor.Singleton<IPackageDecoder<StringPackageInfo>, DefaultStringPackageDecoder>());
            }

            services.TryAdd(ServiceDescriptor.Singleton<IPackageEncoder<string>, DefaultStringEncoderForDI>());
            services.TryAdd(ServiceDescriptor.Singleton<ISessionFactory, DefaultSessionFactory>());

            // if no host service was defined, just use the default one
            if (!CheckIfExistHostedService(services))
            {
                RegisterDefaultHostedService(servicesInHost);
            }
        }

        protected virtual bool CheckIfExistHostedService(IServiceCollection services)
        {
            return services.Any(s => s.ServiceType == typeof(IHostedService)
                && typeof(SocketServerService<TReceivePackage>).IsAssignableFrom(GetImplementationType(s)));
        }

        private Type GetImplementationType(ServiceDescriptor serviceDescriptor)
        {
            if (serviceDescriptor.ImplementationType != null)
                return serviceDescriptor.ImplementationType;

            if (serviceDescriptor.ImplementationInstance != null)
                return serviceDescriptor.ImplementationInstance.GetType();

            if (serviceDescriptor.ImplementationFactory != null)
            {
                var typeArguments = serviceDescriptor.ImplementationFactory.GetType().GenericTypeArguments;

                if (typeArguments.Length == 2)
                    return typeArguments[1];
            }

            return null;
        }

        protected virtual void RegisterDefaultHostedService(IServiceCollection servicesInHost)
        {
            RegisterHostedService<SocketServerService<TReceivePackage>>(servicesInHost);
        }

        protected virtual void RegisterHostedService<THostedService>(IServiceCollection servicesInHost)
            where THostedService : class, IHostedService
        {
            servicesInHost.AddSingleton<THostedService, THostedService>();
            servicesInHost.AddSingleton<IServerInfo>(s => s.GetService<THostedService>() as IServerInfo);
            servicesInHost.AddHostedService<THostedService>(s => s.GetService<THostedService>());
        }

        public ISocketServerHostBuilder<TReceivePackage> ConfigureServerOptions(Func<HostBuilderContext, IConfiguration, IConfiguration> serverOptionsReader)
        {
            _serverOptionsReader = serverOptionsReader;
            return this;
        }

        ISocketServerHostBuilder<TReceivePackage> ISocketServerHostBuilder<TReceivePackage>.ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            return ConfigureServices(configureDelegate);
        }

        public override SocketServerHostBuilder<TReceivePackage> ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            ConfigureServicesActions.Add(configureDelegate);
            return this;
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UsePipelineFilter<TPipelineFilter>()
            where TPipelineFilter : IPipelineFilter<TReceivePackage>, new()
        {
            return this.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<IPipelineFilterFactory<TReceivePackage>, DefaultPipelineFilterFactory<TReceivePackage, TPipelineFilter>>();
            });
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UsePipelineFilterFactory<TPipelineFilterFactory>()
            where TPipelineFilterFactory : class, IPipelineFilterFactory<TReceivePackage>
        {
            return this.ConfigureServices((ctx, services) =>
            {
                services.AddSingleton<IPipelineFilterFactory<TReceivePackage>, TPipelineFilterFactory>();
            });
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UseSession<TSession>()
            where TSession : IAppSession
        {
            return this.UseSessionFactory<GenericSessionFactory<TSession>>();
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UseSessionFactory<TSessionFactory>()
            where TSessionFactory : class, ISessionFactory
        {
            return this.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<ISessionFactory, TSessionFactory>();
                }
            );
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UseHostedService<THostedService>()
            where THostedService : class, IHostedService
        {
            if (!typeof(SocketServerService<TReceivePackage>).IsAssignableFrom(typeof(THostedService)))
            {
                throw new ArgumentException($"The type parameter should be subclass of {nameof(SocketServerService<TReceivePackage>)}", nameof(THostedService));
            }

            return this.ConfigureServices((ctx, services) =>
            {
                RegisterHostedService<THostedService>(services);
            });
        }


        public virtual ISocketServerHostBuilder<TReceivePackage> UsePackageDecoder<TPackageDecoder>()
            where TPackageDecoder : class, IPackageDecoder<TReceivePackage>
        {
            return this.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<IPackageDecoder<TReceivePackage>, TPackageDecoder>();
                }
            );
        }

        public virtual ISocketServerHostBuilder<TReceivePackage> UseMiddleware<TMiddleware>()
            where TMiddleware : class, IMiddleware
        {
            return this.ConfigureServices((ctx, services) =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMiddleware, TMiddleware>());
            });
        }

        public ISocketServerHostBuilder<TReceivePackage> UsePackageHandlingScheduler<TPackageHandlingScheduler>()
            where TPackageHandlingScheduler : class, IPackageHandlingScheduler<TReceivePackage>
        {
            return this.ConfigureServices(
                (hostCtx, services) =>
                {
                    services.AddSingleton<IPackageHandlingScheduler<TReceivePackage>, TPackageHandlingScheduler>();
                }
            );
        }

        public ISocketServerHostBuilder<TReceivePackage> UsePackageHandlingContextAccessor()
        {
            return this.ConfigureServices(
                 (hostCtx, services) =>
                 {
                     services.AddSingleton<IPackageHandlingContextAccessor<TReceivePackage>, PackageHandlingContextAccessor<TReceivePackage>>();
                 }
             );
        }
    }

    public static class SocketServerHostBuilder
    {
        public static ISocketServerHostBuilder<TReceivePackage> Create<TReceivePackage>()
            where TReceivePackage : class
        {
            return Create<TReceivePackage>(args: null);
        }

        public static ISocketServerHostBuilder<TReceivePackage> Create<TReceivePackage>(string[] args)
        {
            return new SocketServerHostBuilder<TReceivePackage>(args);
        }

        public static ISocketServerHostBuilder<TReceivePackage> Create<TReceivePackage, TPipelineFilter>()
            where TPipelineFilter : IPipelineFilter<TReceivePackage>, new()
        {
            return Create<TReceivePackage, TPipelineFilter>(args: null);
        }

        public static ISocketServerHostBuilder<TReceivePackage> Create<TReceivePackage, TPipelineFilter>(string[] args)
            where TPipelineFilter : IPipelineFilter<TReceivePackage>, new()
        {
            return new SocketServerHostBuilder<TReceivePackage>(args)
                .UsePipelineFilter<TPipelineFilter>();
        }
    }
}
