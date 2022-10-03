using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repositories;
using SchoolApi.Services;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        private readonly ISchoolService _schoolService;
        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchool(int id)
        {
            var school = await _schoolService.GetSchoolById(id);
            
            return Ok(school);
        }
    }
}
