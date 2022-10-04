using Dapper;
using SchoolApi.Context;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DapperContext _context;

        public SchoolRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> Create(School school)
        {
            var sql = "INSERT INTO School (Name, Address, Motto, AverageTuition) VALUES (@Name, @Address, @Motto, @AverageTuition); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, school);
            }
        }

        public async Task<IEnumerable<School>> GetAll()
        {
            var sql = "SELECT * FROM School";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<School>(sql);
            }
        }

        public async Task<School> GetSchool(int id)
        {
            var sql = "SELECT * FROM School WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleAsync<School>(sql, new { id });
            }
        }
    }
}
