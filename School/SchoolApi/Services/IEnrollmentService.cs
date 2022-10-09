using SchoolApi.Dtos.Student;

namespace SchoolApi.Services
{
    public interface IEnrollmentService
    {
        Task<int> Enroll(int schoolId, StudentCreationDto student);
    }
}
