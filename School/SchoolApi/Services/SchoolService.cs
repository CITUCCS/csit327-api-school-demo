using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public Task<School> GetSchoolById(int id)
        {
            return _schoolRepository.GetSchool(id);
        }
    }
}
