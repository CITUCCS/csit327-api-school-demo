﻿using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetAllBySchoolName(string schoolName);
        Task<IEnumerable<Student>> GetAllBySchoolId(int schoolId);
        Task<Student?> GetStudent(int id);
        Task<int> Create(Student student);
    }
}
