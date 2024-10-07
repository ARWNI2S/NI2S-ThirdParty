using OWSData.Models.StoredProcs;
using System.Collections.Generic;

namespace OWSData.Models.Composites
{
    public class CharacterAndCustomData
    {
        public GetCharByCharName CharacterData { get; set; }
        public List<CustomCharacterDataDTO> CustomCharacterDataRows { get; set; }
}
}
