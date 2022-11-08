using H4LoginAPI.Managers;
using Microsoft.AspNetCore.Mvc;

namespace H4LoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        LoginManager loginManager = new LoginManager(new CryptoService());

        [Route("[action]")]
        [HttpPost]
        public IActionResult SignUp([FromForm] string username, [FromForm] string password)
        {
            try
            {
                return Ok(loginManager.Register(username,password));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Login([FromForm]string username, [FromForm]string password)
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
