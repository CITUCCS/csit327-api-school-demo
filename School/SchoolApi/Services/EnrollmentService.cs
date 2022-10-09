using SchoolApi.Dtos.Student;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IStudentRepository _studentRepository;

        public EnrollmentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Enroll(int schoolId, StudentCreationDto student)
        {
            var model = new Student
            {
                Name = student.Name,
                Email = student.Email,
                School = new School
                {
                    Id = schoolId
                }
            };

            return await _studentRepository.Create(model);
        }
    }
}
