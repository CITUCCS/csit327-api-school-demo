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
