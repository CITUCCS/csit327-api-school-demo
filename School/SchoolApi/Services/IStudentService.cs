using SchoolApi.Dtos.Student;

namespace SchoolApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudents(string? schoolName = null);
        Task<StudentDto?> GetStudentById(int id);
    }
}
