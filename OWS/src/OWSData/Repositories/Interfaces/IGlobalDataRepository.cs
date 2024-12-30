using OWSData.Models.Tables;

namespace OWSData.Repositories.Interfaces
{
    public interface IGlobalDataRepository
    {
        Task AddOrUpdateGlobalData(GlobalData globalData);
        Task<GlobalData> GetGlobalDataByGlobalDataKey(Guid customerGuid, string globalDataKey);
    }
}
