using App.Courses.DTO;
using AutoMapper;
using Domain.Entities;

namespace App.Courses.Courses.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseDTO>().ReverseMap();
    }
}
