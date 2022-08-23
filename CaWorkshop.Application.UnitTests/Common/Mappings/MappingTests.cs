using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.UnitTests.Common.Mapping;

public class MappingTests : IClassFixture<MappingFixture>
{
    private readonly IMapper _mapper;

    public MappingTests(MappingFixture fixture)
    {
        _mapper = fixture.Mapper;
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _mapper
            .ConfigurationProvider
            .AssertConfigurationIsValid(); // for simple errors like not being able to map because of e.g. spell mistake
    }

    [Theory]
    [InlineData(typeof(TodoList), typeof(TodoListDto))]
    [InlineData(typeof(TodoItem), typeof(TodoItemDto))]
    public void ShouldSupportMappingFromSourceToDestination
        (Type source, Type destination)
    {
        var instance = Activator.CreateInstance(source);

        _mapper.Map(instance, source, destination);
    }
}