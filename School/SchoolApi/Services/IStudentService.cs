using SchoolApi.Dtos.Student;

namespace SchoolApi.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>All students</returns>
        Task<IEnumerable<StudentDto>> GetAllStudents();

        /// <summary>
        /// Get all students filtered by school name
        /// </summary>
        /// <param name="schoolName">Name of school</param>
        /// <returns>Students from that school</returns>
        Task<IEnumerable<StudentDto>> GetAllStudents(string schoolName);

        /// <summary>
        /// Get all students filtered by school Id
        /// </summary>
        /// <param name="schoolId">Id of school</param>
        /// <returns>Students from that school</returns>
        Task<IEnumerable<StudentDto>> GetAllStudents(int schoolId);

        /// <summary>
        /// Get a student by Id
        /// </summary>
        /// <param name="id">Id of student</param>
        /// <returns>Student</returns>
        Task<StudentDto?> GetStudentById(int id);
    }
}
