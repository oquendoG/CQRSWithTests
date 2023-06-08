using App.Courses.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Courses.Queries;
public record GetByIdQueryRequest(Guid Id) : IRequest<CourseDTO>;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryRequest, CourseDTO>
{
    private readonly AppDbContext _context;
    private readonly IMapper mapper;

    public GetByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;
    }
    public async Task<CourseDTO> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Course course = await _context.Courses
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        return mapper.Map<Course, CourseDTO>(course);
    }
}