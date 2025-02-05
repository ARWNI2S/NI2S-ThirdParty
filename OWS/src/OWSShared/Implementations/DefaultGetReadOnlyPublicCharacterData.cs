﻿using OWSShared.Interfaces;

namespace OWSShared.Implementations
{
    public class DefaultGetReadOnlyPublicCharacterData : IGetReadOnlyPublicCharacterData
    {
        public Task<string> GetReadOnlyPublicCharacterData(int characterId)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
