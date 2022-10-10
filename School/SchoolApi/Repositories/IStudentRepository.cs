using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>All students</returns>
        Task<IEnumerable<Student>> GetAll();

        /// <summary>
        /// Get all students from a school
        /// </summary>
        /// <param name="schoolName">Name of school</param>
        /// <returns>Students from that school</returns>
        Task<IEnumerable<Student>> GetAllBySchoolName(string schoolName);

        /// <summary>
        /// Get all students from a school
        /// </summary>
        /// <param name="schoolId">Id of school</param>
        /// <returns>Students from that school</returns>
        Task<IEnumerable<Student>> GetAllBySchoolId(int schoolId);

        /// <summary>
        /// Get student by Id
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>Student</returns>
        Task<Student?> GetStudent(int id);

        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="student">Student model</param>
        /// <returns>Id of the new student</returns>
        Task<int> Create(Student student);
    }
}
