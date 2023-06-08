using App.Courses.Commands;
using FluentValidation.AspNetCore;

namespace Api.Extensions;

public static class AppServiceExtensions
{
    public static void AddServiceExtensions(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCourseHandler).Assembly));

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddCors(cors => cors.AddPolicy("corsApp", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));
    }
}