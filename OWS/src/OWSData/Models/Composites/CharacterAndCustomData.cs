using OWSData.Models.StoredProcs;

namespace OWSData.Models.Composites
{
    public class CharacterAndCustomData
    {
        public GetCharByCharName CharacterData { get; set; }
        public List<CustomCharacterDataDTO> CustomCharacterDataRows { get; set; }
}
}
