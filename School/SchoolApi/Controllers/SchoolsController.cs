using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Models;
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

        [HttpGet("{id}", Name = "GetSchoolById")] // GET /api/schools/{id} ex: /api/schools/-4.5
        public async Task<IActionResult> GetSchool(int id)
        {
            try
            {
                var school = await _schoolService.GetSchoolById(id);
                return Ok(school);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet(Name = "GetAllSchools")] // GET api/schools/
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var schools = await _schoolService.GetAllSchools();

                if (schools.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(schools);
            } 
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost] // POST /api/schools/
        public async Task<IActionResult> CreateSchool([FromBody] School school)
        {
            var newSchool = await _schoolService.CreateSchool(school);
            // If successfully created, STATUS CODE IS 201
            //
            // /api/schools/9 add to header as location
           return CreatedAtRoute("GetSchoolById", new { id = newSchool.Id }, newSchool);
        }
    }
}
