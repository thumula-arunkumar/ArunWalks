using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Repository;

namespace NzWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Model.Domain.RequestLogin requestLogin)
        {
            //check the username and password 
            var user = await userRepository.AuthenticateUser(requestLogin.username, requestLogin.password); 
            if(user != null)
            {
                var token = tokenHandler.CreateJwtToke(user);
                return Ok(token);
            }
            return BadRequest("Username or Password is null");

        }
    }
}
