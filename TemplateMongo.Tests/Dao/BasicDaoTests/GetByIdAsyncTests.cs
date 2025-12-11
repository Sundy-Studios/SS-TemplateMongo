using Moq;
using MongoDB.Driver;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public class GetByIdAsyncTests : BasicDaoTestsBase
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllModels()
    {
        var models = new List<BasicModel>
        {
            new BasicModel { Id = "1", Name = "A" },
            new BasicModel { Id = "2", Name = "B" }
        };

        var mockCursor = CreateMockCursor(models);

        _mockCollection
            .Setup(c => c.FindAsync(
                It.IsAny<FilterDefinition<BasicModel>>(),
                It.IsAny<FindOptions<BasicModel, BasicModel>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockCursor.Object);

        var result = await _dao.GetAllAsync();

        Assert.Equal(2, result.Count);
        Assert.Equal("1", result[0].Id);
        Assert.Equal("2", result[1].Id);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsModel()
    {
        var expected = new BasicModel { Id = "123", Name = "Test" };

        var mockCursor = CreateMockCursor(new List<BasicModel> { expected });

        _mockCollection
            .Setup(c => c.FindAsync(
                It.IsAny<FilterDefinition<BasicModel>>(),
                It.IsAny<FindOptions<BasicModel, BasicModel>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockCursor.Object);

        var result = await _dao.GetByIdAsync("123");

        Assert.NotNull(result);
        Assert.Equal("123", result.Id);
        Assert.Equal("Test", result.Name);
    }

}
