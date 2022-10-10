using AutoMapper;
using SchoolApi.Dtos.Student;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var studentModels = await _studentRepository.GetAll();

            return _mapper.Map<IEnumerable<StudentDto>>(studentModels);
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents(string schoolName)
        {
            var studentModels = await _studentRepository.GetAllBySchoolName(schoolName);

            return _mapper.Map<IEnumerable<StudentDto>>(studentModels);
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents(int schoolId)
        {
            var studentModels = await _studentRepository.GetAllBySchoolId(schoolId);

            return _mapper.Map<IEnumerable<StudentDto>>(studentModels);
        }

        public async Task<StudentDto?> GetStudentById(int id)
        {
            var model = await _studentRepository.GetStudent(id);
            if (model == null) return null;

            return _mapper.Map<StudentDto>(model);
        }
    }
}
