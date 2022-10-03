using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetSchool(int id)
        {
            return Ok("Hello " + id);
        }
    }
}
