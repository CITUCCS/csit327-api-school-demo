using SchoolApi.Dtos.Student;

namespace SchoolApi.Services
{
    public interface IEnrollmentService
    {
        /// <summary>
        /// Create and enroll a student to a school
        /// </summary>
        /// <param name="schoolId">Id of the school</param>
        /// <param name="student">Student details</param>
        /// <returns>Id of the newly created student</returns>
        Task<int> Enroll(int schoolId, StudentCreationDto student);
    }
}
