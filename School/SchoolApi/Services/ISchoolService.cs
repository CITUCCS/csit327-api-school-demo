using SchoolApi.Models;

namespace SchoolApi.Services
{
    public interface ISchoolService
    {
        Task<School> GetSchoolById(int id);
    }
}
