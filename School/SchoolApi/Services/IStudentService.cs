using SchoolApi.Dtos.Student;

namespace SchoolApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudents();
        Task<IEnumerable<StudentDto>> GetAllStudents(string schoolName);
        Task<IEnumerable<StudentDto>> GetAllStudents(int schoolId);
        Task<StudentDto?> GetStudentById(int id);
    }
}
