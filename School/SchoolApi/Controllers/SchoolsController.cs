using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Dtos.School;
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
        private readonly ILogger<SchoolsController> _logger;

        public SchoolsController(ISchoolService schoolService, ILogger<SchoolsController> logger)
        {
            _schoolService = schoolService;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetSchoolById")] // GET /api/schools/{id} ex: /api/schools/-4.5
        public async Task<IActionResult> GetSchool(int id)
        {
            try
            {
                var school = await _schoolService.GetSchoolById(id);

                if (school == null) 
                    return NotFound($"School with id {id} does not exist.");

                return Ok(school);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost] // POST /api/schools/
        public async Task<IActionResult> CreateSchool([FromBody] SchoolCreationDto schoolDto)
        {
            try
            {
                var newSchool = await _schoolService.CreateSchool(schoolDto);

                // If successfully created, STATUS CODE IS 201
                // /api/schools/{id} add to header as location
                return CreatedAtRoute("GetSchoolById", new { id = newSchool.Id }, newSchool);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
