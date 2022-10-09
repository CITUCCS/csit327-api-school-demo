using SchoolApi.Dtos.Student;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<StudentDto>> GetAllStudents(string? schoolName = null)
        {
            var studentModels = (schoolName == null)
                ? await _studentRepository.GetAll()
                : await _studentRepository.GetAllBySchoolName(schoolName);

            return studentModels.Select(model => new StudentDto
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                School = model.School?.Name
            });
        }

        public async Task<StudentDto?> GetStudentById(int id)
        {
            var model = await _studentRepository.GetStudent(id);
            if (model == null) return null;

            return new StudentDto
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                School = model.School?.Name
            };
        }
    }
}
