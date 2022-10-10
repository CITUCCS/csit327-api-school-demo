using AutoMapper;
using SchoolApi.Dtos.Student;
using SchoolApi.Models;

namespace SchoolApi.Mappings
{
    public class StudentMappings : Profile
    {
        public StudentMappings()
        {
            CreateMap<Student,StudentDto>()
                .ForMember(dto => dto.School, opt => opt.MapFrom(st => st.School!.Name));
            CreateMap<StudentCreationDto, Student>();
        }
    }
}
