using App.Courses.Commands;
using App.Courses.DTO;
using App.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly IMediator mediator;

    public CourseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CourseDTO>>> Get()
    {
        return await mediator.Send(new GetCoursesQueryRequest());
    }

    [HttpPost]
    public async Task<ActionResult> Post(CourseDTO course)
    {
        int result = await mediator.Send(new CreateCourseRequest(course));
        return Ok(result);
    }
}
