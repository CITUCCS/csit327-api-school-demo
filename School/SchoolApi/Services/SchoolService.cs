using SchoolApi.Dtos;
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

        public async Task<School> CreateSchool(SchoolCreationDto schoolToCreate)
        {
            // Convert Dto to Models
            var schoolModel = new School
            {
                Name = schoolToCreate.Name,
                Motto = schoolToCreate.Motto,
                Address = schoolToCreate.Address,
                AverageTuition = schoolToCreate.AverageTuition
            };

            schoolModel.Id = await _repository.Create(schoolModel);

            return schoolModel;
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
