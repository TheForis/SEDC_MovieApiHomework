using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qinshift.Movies.DTOs;
using Qinshift.Movies.Services.Interface;

namespace Qinshift.Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public ActionResult<UserDto> LogIn(string username, string password)
        {
            try
            {
                var result =_userService.LogInUser(username, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserDto newUser)
        {
            try
            {
                var createUser = _userService.CreateUser(newUser);
                if (createUser == 0) {
                    return BadRequest("Cannot register user!"); }
                else { return Ok("User successfully created!"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
