using BankSlipControl.Domain.Entities.v1.UserEntitie;
using BankSlipControl.Domain.InputModels.v1.User;

namespace BankSlipControl.Domain.Services.v1.UserService
{
    public interface IUserService
    {
        public Task<User> RegisterUser(User newUser);
        public Task<UserViewModel> LoginUser(User userLogin);
    }
}
