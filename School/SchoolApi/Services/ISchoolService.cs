using SchoolApi.Dtos.School;
using SchoolApi.Models;

namespace SchoolApi.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetAllSchools();
        Task<SchoolDto?> GetSchoolById(int id);
        Task<SchoolDto> CreateSchool(SchoolCreationDto schoolToCreate);
    }
}
