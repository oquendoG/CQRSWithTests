using App.Courses.DTO;
using App.Helper;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Persistence;

namespace App.Courses.Queries;

[TestFixture]
public class GetCoursesQueryXunitTest
{
    private GetCoursesQueryHandler _handler;

    [SetUp]
    public void Setup()
    {
        //el fixture permite crear data de prueba
        Fixture fixture = new();
        List<Course> courseRecords = fixture.CreateMany<Course>().ToList();

        //se agrega un registro adicional con id vacío
        courseRecords.Add(fixture.Build<Course>()
            .With(course => course.Id, Guid.Empty)
            .Create());

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid}")
            .Options;

        AppDbContext contextFake = new(options);
        contextFake.AddRange(courseRecords);
        contextFake.SaveChanges();

        MapperConfiguration mapConfig = new(cfg => cfg.AddProfile(new MappingTest()));
        IMapper mapper = mapConfig.CreateMapper();

        _handler = new(contextFake, mapper);
    }

    [Test]
    public async Task GetCoursesQueryHandler()
    {
        //emular el context

        //emular al mapeador

        //instanciar objeto de la clase GetCoursesQueryHandler y pasarle las dependencias
        GetCoursesQueryRequest request = new();
        List<CourseDTO> courses = await _handler.Handle(request, new CancellationToken());

        Assert.IsNotNull(courses);
    }
}