using System.Threading.Tasks;

namespace OWSShared.Interfaces
{
    public interface IGetReadOnlyPublicCharacterData
    {
        Task <string> GetReadOnlyPublicCharacterData (int characterId);
    }
}
