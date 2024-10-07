namespace OWSShared.Interfaces
{
    public interface ICustomCharacterDataSelector
    {
        bool ShouldExportThisCustomCharacterDataField(string fieldName);
    }
}
