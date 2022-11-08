using H4LoginAPI.Managers;
using Microsoft.AspNetCore.Mvc;

namespace H4LoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        LoginManager loginManager = new LoginManager(new CryptoService());

        [Route("/Signup")]
        [HttpPost]
        public IActionResult SignUp(string username, string password)
        {
            try
            {
                return Ok(loginManager.Register(username, password));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("/SignIn")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                return Ok(loginManager.Login(username, password));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
