﻿using Microsoft.AspNetCore.Mvc;
using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSPublicAPI.Requests.Users
{
    /// <summary>
    /// CreateCharacterRequest Handler
    /// </summary>
    /// <remarks>
    /// Handles api/Users/CreateCharacter requests.
    /// </remarks>
    public class CreateCharacterRequest : IRequestHandler<CreateCharacterRequest, IActionResult>, IRequest
    {
        /// <summary>
        /// UserSessionGUID Request Paramater.
        /// </summary>
        /// <remarks>
        /// Contains the User Session GUID from the request.  This identifies the User we are modifying.
        /// </remarks>
        public Guid UserSessionGUID { get; set; }
        /// <summary>
        /// CharacterName Request Paramater.
        /// </summary>
        /// <remarks>
        /// Contains the Character Name from the request.  This is the new Character Name to create.
        /// </remarks>
        public string CharacterName { get; set; }
        /// <summary>
        /// ClassName Request Paramater.
        /// </summary>
        /// <remarks>
        /// Contains the Class Name from the request.  This sets the default values for the new Character.
        /// </remarks>
        public string ClassName { get; set; }

        private CreateCharacter Output;
        private Guid CustomerGUID;
        private IUsersRepository usersRepository;
        private IPublicAPIInputValidation publicAPIInputValidation;

        /// <summary>
        /// Set Dependencies for CreateCharacterRequest
        /// </summary>
        /// <remarks>
        /// Injects the dependencies for the CreateCharacterRequest.
        /// </remarks>
        public void SetData(IUsersRepository usersRepository, IPublicAPIInputValidation publicAPIInputValidation, IHeaderCustomerGUID customerGuid)
        {
            CustomerGUID = customerGuid.CustomerGUID;
            this.usersRepository = usersRepository;
            this.publicAPIInputValidation = publicAPIInputValidation;
        }

        /// <summary>
        /// Handles the CreateCharacterRequest
        /// </summary>
        /// <remarks>
        /// Overrides IRequestHandler Handle().
        /// </remarks>
        public async Task<IActionResult> Handle()
        {
            //Validate Character Name
            string errorMessage = publicAPIInputValidation.ValidateCharacterName(CharacterName);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                CreateCharacter createCharacterErrorMessage = new CreateCharacter();
                createCharacterErrorMessage.ErrorMessage = errorMessage;
                return new OkObjectResult(createCharacterErrorMessage);
            }

            Output = await usersRepository.CreateCharacter(CustomerGUID, UserSessionGUID, CharacterName, ClassName);

            return new OkObjectResult(Output);
        }
    }
}
