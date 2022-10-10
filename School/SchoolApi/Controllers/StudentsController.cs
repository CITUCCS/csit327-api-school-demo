using Microsoft.AspNetCore.Mvc;
using SchoolApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
        // GET: api/students?school=USC
        [HttpGet(Name = "GetAllStudents")]
        public async Task<IActionResult> GetAllStudents([FromQuery] string? school = null)
        {
            try
            {
                var students = school != null 
                    ? await _studentService.GetAllStudents(school)
                    : await _studentService.GetAllStudents();
                
                if (!students.Any())
                {
                    _logger.LogInformation("No students found.");
                    return NoContent(); // Status Code 204
                }

                return Ok(students); // Status Code 200
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }
        // GET api/students/5
        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);

                if (student == null)
                {
                    return NotFound($"Student with id {id} does not exist");
                }

                return Ok(student);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

    }
}
