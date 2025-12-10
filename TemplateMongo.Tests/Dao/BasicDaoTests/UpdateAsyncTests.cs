using MongoDB.Driver;
using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public class UpdateAsyncTests : BasicDaoTestsBase
{
    [Fact]
    public async Task UpdateAsync_CallsReplaceOne()
    {
        var id = "xyz";
        var model = new BasicModel { Id = id, Name = "Updated" };

        _mockCollection.Setup(c => c.ReplaceOneAsync(
                It.IsAny<FilterDefinition<BasicModel>>(),
                model,
                It.IsAny<ReplaceOptions>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<ReplaceOneResult>());

        await _dao.UpdateAsync(id, model);

        _mockCollection.Verify(c => c.ReplaceOneAsync(
            It.IsAny<FilterDefinition<BasicModel>>(),
            model,
            It.IsAny<ReplaceOptions>(),
            It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
