using SchoolApi.Dtos.School;
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

        public async Task<SchoolDto> CreateSchool(SchoolCreationDto schoolToCreate)
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

            return new SchoolDto
            {
                Id = schoolModel.Id,
                Name = schoolModel.Name,
                Address = schoolModel.Address,
                Motto = schoolModel.Motto
            };
        }

        public async Task<IEnumerable<SchoolDto>> GetAllSchools()
        {
            var schoolModels = await _repository.GetAll();
            return schoolModels.Select(school => new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                Address = school.Address,
                Motto = school.Motto
            });
        }

        public async Task<SchoolDto?> GetSchoolById(int id)
        {
            var schoolModel = await _repository.GetSchool(id);
            if(schoolModel == null) return null;

            return new SchoolDto
            {
                Id = schoolModel.Id,
                Name = schoolModel.Name,
                Address = schoolModel.Address,
                Motto = schoolModel.Motto
            };
        }
    }
}
