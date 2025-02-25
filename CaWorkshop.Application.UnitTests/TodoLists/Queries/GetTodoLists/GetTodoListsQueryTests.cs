using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Infrastructure.Data;
using FluentAssertions;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists;

[Collection(nameof(ReadOnlyCollection))]
public class GetTodoListsQueryTests
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoListsQueryTests(TestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task Handle_ReturnsCorrectVmAndListCount()
    {
        // Arrange
        var query = new GetTodoListsQuery();
        var handler = new GetTodoListsQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<TodosVm>();
        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(4);
    }
}