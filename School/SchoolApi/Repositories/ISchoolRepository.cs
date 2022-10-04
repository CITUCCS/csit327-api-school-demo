using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetAll();
        Task<School> GetSchool(int id);
        Task<int> Create(School school);
    }
}
