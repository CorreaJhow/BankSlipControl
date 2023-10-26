using AutoMapper;
using BankSlipControl.Domain.Entities.v1.UserEntitie;
using BankSlipControl.Domain.InputModels.v1.User;
using BankSlipControl.Domain.Services.v1.UserService;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class UserService : IUserService
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public UserService(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> RegisterUser(User newUser)
        {
            try
            {
                _context.User.Add(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error registering user", ex);
            }
        }

        public async Task<UserViewModel> LoginUser(User userLogin)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Login == userLogin.Login && u.Password == userLogin.Password);

                if (user != null)
                {
                    var userViewModel = _mapper.Map<UserViewModel>(user);
                   
                    return userViewModel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error when logging in.", ex);
            }
        }
    }
}
