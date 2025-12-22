namespace TemplateMongo.Tests.Dao.BasicDaoTests;

using MongoDB.Driver;
using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : BasicDaoTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsModel()
    {
        var expected = new BasicModel { Id = "123", Name = "Test" };

        var mockCursor = CreateMockCursor([expected]);

        MockCollection
            .Setup(c => c.FindAsync(
                It.IsAny<FilterDefinition<BasicModel>>(),
                It.IsAny<FindOptions<BasicModel, BasicModel>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockCursor.Object);

        var result = await Dao.GetByIdAsync("123");

        Assert.NotNull(result);
        Assert.Equal("123", result.Id);
        Assert.Equal("Test", result.Name);
    }

}
