using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.Entities.v1.UserEntitie;
using BankSlipControl.Domain.InputModels.v1.User;
using BankSlipControl.Domain.Services.v1.UserService;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BankSlipControl.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("/v1/user/register")]
        public async Task<IActionResult> RegisterUser(UserInputModel newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<User>(newUser);

                var result = await _userService.RegisterUser(user);

                if (result == null)
                    new Exception("error during the user registration process");

                return Ok(result); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error registering user", error = ex.Message });
            }
        }

        [HttpPost("/v1/user/login")]
        public async Task<IActionResult> Login(UserLoginInputModel userLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<User>(userLogin);

                var result = await _userService.LoginUser(user);

                if (result != null)
                {
                    var viewUser = _mapper.Map<UserViewModel>(result);

                    return Ok(viewUser);
                }
                else
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error when logging in", error = ex.Message });
            }
        }
    }
}
