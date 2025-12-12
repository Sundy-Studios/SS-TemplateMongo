using MongoDB.Driver;
using Moq;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public class GetAllAsyncTests : BasicDaoTestsBase
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

        var result = await _dao.GetAllAsync(new GetAllBasicParams() {});

        Assert.Equal(2, result.Items.Count);
        Assert.Equal("1", result.Items[0].Id);
        Assert.Equal("2", result.Items[1].Id);
    }
}
