using AutoMapper;
using SchoolApi.Dtos.Student;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<int> Enroll(int schoolId, StudentCreationDto student)
        {
            // Convert DTO -> Model
            var model = _mapper.Map<Student>(student);
            model.School = new School { Id = schoolId };

            return await _studentRepository.Create(model);
        }
    }
}
