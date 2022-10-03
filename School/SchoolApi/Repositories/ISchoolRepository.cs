using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface ISchoolRepository
    {
        Task<School> GetSchool(int id);
    }
}
