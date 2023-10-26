using AutoMapper;
using BankSlipControl.Domain.Entities.v1.UserEntitie;
using BankSlipControl.Domain.InputModels.v1.User;
using BankSlipControl.Domain.Services.v1.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation
{
    public class UserService : IUserService
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(ContextDb context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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

        public string GetToken(UserViewModel user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("DisplayName", user.Login),
                        new Claim("UserName", user.Login),
                        new Claim("Email", user.Email),
                        };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }
    }
}
