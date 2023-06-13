using App.Courses.DTO;
using AutoMapper;
using Domain.Entities;

namespace App.Helper;
public class MappingTest : Profile
{
    public MappingTest()
    {
        CreateMap<Course, CourseDTO>().ReverseMap();
    }
}
