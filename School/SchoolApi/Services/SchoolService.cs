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

        public async Task<School> CreateSchool(School schoolToCreate)
        {
            schoolToCreate.Id = await _repository.Create(schoolToCreate);

            return schoolToCreate;
        }

        public Task<IEnumerable<School>> GetAllSchools()
        {
            return _repository.GetAll();
        }

        public Task<School> GetSchoolById(int id)
        {
            return _repository.GetSchool(id);
        }
    }
}
