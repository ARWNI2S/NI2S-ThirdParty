using OWSData.Models.Tables;
using OWSData.Repositories.Interfaces;

namespace OWSManagement.Requests.Users
{
    public class GetUsersRequest
    {
        private readonly Guid _customerGuid;
        private readonly IUsersRepository _usersRepository;

        public GetUsersRequest(Guid customerGuid, IUsersRepository usersRepository)
        {
            _customerGuid = customerGuid;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<User>> Handle()
        {
            return await _usersRepository.GetUsers(_customerGuid); ;
        }
    }
}
