using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Dtos.School;
using SchoolApi.Dtos.Student;
using SchoolApi.Services;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly ILogger<SchoolsController> _logger;

        public SchoolsController(
            ISchoolService schoolService,
            IStudentService studentService,
            IEnrollmentService enrollmentService,
            ILogger<SchoolsController> logger)
        {
            _schoolService = schoolService;
            _studentService = studentService;
            _enrollmentService = enrollmentService;
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

        /// <summary>
        /// Creates a school
        /// </summary>
        /// <param name="school">School details</param>
        /// <returns>Returns the newly created school</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/schools
        ///     {
        ///         "name" : "CIT-U",
        ///         "address" : "N.Bacalso Ave. Cebu City",
        ///         "motto" : "Tops again"
        ///         "averageTuition" : 1000
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a school</response>
        /// <response code="400">School details are invalid</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SchoolDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolCreationDto school)
        {
            try
            {
                var newSchool = await _schoolService.CreateSchool(school);

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

        [HttpPost("{id}/enroll", Name = "EnrollStudentToSchool")]  // POST /api/schools/1/enroll
        public async Task<IActionResult> EnrollStudent(int id, [FromBody] StudentCreationDto newStudent)
        {
            try
            {
                // Check if school exists
                var school = await _schoolService.GetSchoolById(id);
                if (school == null)
                    return NotFound($"School with id {id} does not exist.");

                var newStudentId = await _enrollmentService.Enroll(id, newStudent);

                return CreatedAtAction(
                    nameof(StudentsController.Get), // name of the action/function
                    "Students", // name of the controller
                    new { Id = newStudentId }, // parameter needed
                    $"Successfully enrolled {newStudent.Name} at {school.Name}"); // returned data
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("{id}/students", Name = "GetSchoolStudents")]
        public async Task<IActionResult> GetSchoolStudents(int id)
        {
            try
            {
                // Check if school exists
                var school = await _schoolService.GetSchoolById(id);
                if (school == null)
                    return NotFound($"School with id {id} does not exist.");

                var enrolledStudents = await _studentService.GetAllStudents(id);
                if (!enrolledStudents.Any())
                {
                    return NoContent();
                }

                return Ok(enrolledStudents);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        } 
    }
}
