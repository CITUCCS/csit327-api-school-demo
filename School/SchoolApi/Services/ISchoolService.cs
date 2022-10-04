using SchoolApi.Dtos;
using SchoolApi.Models;

namespace SchoolApi.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllSchools();
        Task<School> GetSchoolById(int id);
        Task<School> CreateSchool(SchoolCreationDto schoolToCreate);
    }
}
