﻿using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSCharacterPersistence.Requests.Abilities
{
    /// <summary>
    /// Get Abilities
    /// </summary>
    /// <remarks>
    /// Gets a List of all Abilities
    /// </remarks>
    public class GetAbilitiesRequest
    {

        private IEnumerable<OWSData.Models.Tables.Abilities> output;
        private Guid customerGUID;
        private ICharactersRepository charactersRepository;

        public void SetData(ICharactersRepository charactersRepository, IHeaderCustomerGUID customerGuid)
        {
            this.charactersRepository = charactersRepository;
            customerGUID = customerGuid.CustomerGUID;
        }

        public async Task<IEnumerable<OWSData.Models.Tables.Abilities>> Handle()
        {
            output = await charactersRepository.GetAbilities(customerGUID);

            return output;
        }
    }
}
