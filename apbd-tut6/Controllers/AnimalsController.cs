using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tut6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
