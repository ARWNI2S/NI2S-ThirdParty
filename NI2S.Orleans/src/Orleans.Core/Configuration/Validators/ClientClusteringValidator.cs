using System;

using Microsoft.Extensions.DependencyInjection;
using Orleans.Messaging;
using Orleans.Runtime;

namespace Orleans.Configuration.Validators
{
    /// <summary>
    /// Validator for client-side clustering.
    /// </summary>
    internal class ClientClusteringValidator : IConfigurationValidator
    {
        /// <summary>
        /// The error message displayed when clustering is misconfigured.
        /// </summary>
        internal const string ClusteringNotConfigured =
            "Clustering has not been configured. Configure clustering using one of the clustering packages, such as:"
            + "\n  * NI2S.Orleans.Clustering.AzureStorage"
            + "\n  * NI2S.Orleans.Clustering.AdoNet for ADO.NET systems such as SQL Server, MySQL, PostgreSQL, and Oracle"
            + "\n  * NI2S.Orleans.Clustering.DynamoDB"
            + "\n  * NI2S.Orleans.Clustering.ServiceFabric"
            + "\n  * NI2S.Orleans.Clustering.Consul"
            + "\n  * NI2S.Orleans.Clustering.ZooKeeper"
            + "\n  * Others, see: https://www.nuget.org/packages?q=NI2S.Orleans.Clustering.";

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientClusteringValidator"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public ClientClusteringValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public void ValidateConfiguration()
        {
            var gatewayProvider = _serviceProvider.GetService<IGatewayListProvider>();
            if (gatewayProvider == null)
            {
                throw new OrleansConfigurationException(ClusteringNotConfigured);
            }
        }
    }
}
