using Dapper;
using SchoolApi.Context;
using SchoolApi.Models;
using System.Data;

namespace SchoolApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Student student)
        {
            var sql = "INSERT INTO Student (Name, Email, SchoolId) VALUES (@Name, @Email, @SchoolId); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { student.Name, student.Email, SchoolId=student.School?.Id});
            }
        }


        public async Task<IEnumerable<Student>> GetAll()
        {
            var sql = "SELECT * FROM Student AS S INNER JOIN School AS SC ON S.SchoolId = SC.Id";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Student, School, Student>(sql, MapStudentSchool); ;
            }
        }

        public async Task<IEnumerable<Student>> GetAllBySchoolId(int schoolId)
        {
            var sp = "[spStudent_GetAllBySchoolId]";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Student, School, Student>(
                    sp,
                    MapStudentSchool,
                    new { schoolId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Student>> GetAllBySchoolName(string schoolName)
        {
            var sp = "[spStudent_GetAllBySchoolName]";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Student, School, Student>(
                    sp,
                    MapStudentSchool,
                    new { schoolName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Student?> GetStudent(int id)
        {
            var sql = "SELECT * FROM Student AS S INNER JOIN School AS SC ON S.SchoolId = SC.Id WHERE S.Id = @Id";

            using (var con = _context.CreateConnection())
            {
                var student = await con.QueryAsync<Student, School, Student>(sql, MapStudentSchool, new { id });
                return student.SingleOrDefault();
            }
        }

        private static Student MapStudentSchool (Student student, School school)
        {
            student.School = school;
            return student;
        }
    }
}
