using App.Courses.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Courses.Queries;

/// <summary>
/// Representa los parámetros que envía el cliente
/// </summary>
public record GetCoursesQueryRequest : IRequest<List<CourseDTO>>;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQueryRequest, List<CourseDTO>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<CourseDTO>> Handle(GetCoursesQueryRequest request, CancellationToken cancellationToken)
    {
        List<Course> courses = await _context.Courses.ToListAsync(cancellationToken);
        return _mapper.Map<List<Course>, List<CourseDTO>>(courses);
    }
}
