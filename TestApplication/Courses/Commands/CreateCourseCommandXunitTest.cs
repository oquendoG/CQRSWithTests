using App.Courses.DTO;
using App.Courses.Queries;
using App.Helper;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Persistence;

namespace App.Courses.Commands;

[TestFixture]
public class CreateCourseCommandXunitTest
{
    private CreateCourseHandler _handler;

    [SetUp]
    public void Setup()
    {
        //el fixture permite crear data de prueba
        //Fixture fixture = new();
        //List<Course> courseRecords = fixture.CreateMany<Course>().ToList();

        ////se agrega un registro adicional con id vacío
        //courseRecords.Add(fixture.Build<Course>()
        //    .With(course => course.Id, Guid.Empty)
        //    .Create());

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid}")
            .Options;

        AppDbContext contextFake = new(options);
        //contextFake.AddRange(courseRecords);
        //contextFake.SaveChanges();

        MapperConfiguration mapConfig = new(cfg => cfg.AddProfile(new MappingTest()));
        IMapper mapper = mapConfig.CreateMapper();

        _handler = new(contextFake, mapper);
    }

    [Test]
    public async Task CreateCoursesCommandHandler()
    {
        //instanciar objeto de la clase GetCoursesQueryHandler y pasarle las dependencias
        CreateCourseRequest request = new(new CourseDTO()
        {
            PublicationDate = DateTime.UtcNow.AddDays(100),
            Title = "Unit test wth CQRS",
            Description = "Unit test for CQRS pattern from scratch",
            Price = 99
        });
        int result = await _handler.Handle(request, new CancellationToken());

        Assert.That(result, Is.EqualTo(1));
    }
}
