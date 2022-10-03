using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _repository;

        public SchoolService(ISchoolRepository repository)
        {
            _repository = repository;
        }
        public Task<School> GetSchoolById(int id)
        {
            return _repository.GetSchool(id);
        }
    }
}
