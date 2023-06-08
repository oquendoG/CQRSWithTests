using App.Courses.Commands;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace Api.Extensions;

public static class AppServiceExtensions
{
    public static void AddServiceExtensions(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCourseHandler).Assembly));
    }
}