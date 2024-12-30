using OWSData.Models.StoredProcs;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSInstanceManagement.Requests.Instance
{
    /// <summary>
    /// GetZoneInstanceRequest
    /// </summary>
    /// <remarks>
    /// Get information on the server instance that matches the ZoneInstanceId
    /// </remarks>
    public class GetZoneInstanceRequest
    {
        private readonly int _zoneInstanceId;
        private readonly Guid _customerGUID;
        private readonly IInstanceManagementRepository _instanceMangementRepository;

        /// <summary>
        /// GetZoneInstanceRequest Constructor
        /// </summary>
        /// <remarks>
        /// This constructor is used to inject the dependencies into the GetZoneInstanceRequest
        /// </remarks>
        public GetZoneInstanceRequest(int zoneInstanceId, IInstanceManagementRepository instanceMangementRepository, IHeaderCustomerGUID customerGuid)
        {
            _zoneInstanceId = zoneInstanceId;
            _customerGUID = customerGuid.CustomerGUID;
            _instanceMangementRepository = instanceMangementRepository;
        }

        public async Task<GetServerInstanceFromPort> Handle()
        {
            GetServerInstanceFromPort output = await _instanceMangementRepository.GetZoneInstance(_customerGUID, _zoneInstanceId);

            return output;
        }
    }
}
