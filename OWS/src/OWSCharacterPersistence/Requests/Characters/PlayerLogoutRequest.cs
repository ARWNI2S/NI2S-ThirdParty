﻿using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSCharacterPersistence.Requests.Characters
{
    public class PlayerLogoutRequest
    {
        public string CharacterName { get; set; }

        private Guid customerGUID;
        private ICharactersRepository charactersRepository;

        public void SetData(ICharactersRepository charactersRepository, IHeaderCustomerGUID customerGuid)
        {
            this.charactersRepository = charactersRepository;
            customerGUID = customerGuid.CustomerGUID;
        }

        public async Task<SuccessAndErrorMessage> Handle()
        {
            await charactersRepository.PlayerLogout(customerGUID, CharacterName);

            SuccessAndErrorMessage output = new SuccessAndErrorMessage();
            output.Success = true;
            output.ErrorMessage = "";
            return output;
        }
    }
}
