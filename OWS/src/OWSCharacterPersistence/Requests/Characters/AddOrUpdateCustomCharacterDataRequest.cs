﻿using OWSData.Models.StoredProcs;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSCharacterPersistence.Requests.Characters
{
    public class AddOrUpdateCustomDataRequest
    {
        public AddOrUpdateCustomCharacterData addOrUpdateCustomCharacterData { get; set; }

        private Guid customerGUID;
        private ICharactersRepository charactersRepository;

        public void SetData(ICharactersRepository charactersRepository, IHeaderCustomerGUID customerGuid)
        {
            this.charactersRepository = charactersRepository;
            customerGUID = customerGuid.CustomerGUID;
        }

        public async Task Handle()
        {
            await charactersRepository.AddOrUpdateCustomCharacterData(customerGUID, addOrUpdateCustomCharacterData);

            return;
        }
    }
}
