using App.Courses.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace App.Courses.Commands;

public record CreateCourseRequest(CourseDTO Course): IRequest<int>;

public class CreateCourseHandler : IRequestHandler<CreateCourseRequest, int>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCourseHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        Course course = _mapper.Map<CourseDTO, Course>(request.Course);

        _dbContext.Add(course);
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result == 0)
        {
            throw new Exception("No se pudo insertar el curso");
        }
        return result;
    }
}