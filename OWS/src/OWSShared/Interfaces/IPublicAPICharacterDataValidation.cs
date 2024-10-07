using System.Threading.Tasks;

namespace OWSShared.Interfaces
{
    public interface IPublicAPICharacterDataValidation
    {
        Task<bool> ValidatePublicAPICharacterData(string characterDataJson);
    }
}
