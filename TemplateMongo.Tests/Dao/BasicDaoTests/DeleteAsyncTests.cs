using MongoDB.Driver;
using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public class DeleteAsyncTests : BasicDaoTestsBase
{
    [Fact]
    public async Task DeleteAsync_CallsDeleteOne()
    {
        var id = "deleteMe";

        _mockCollection.Setup(c => c.DeleteOneAsync(
                It.IsAny<FilterDefinition<BasicModel>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<DeleteResult>());

        await _dao.DeleteAsync(id);

        _mockCollection.Verify(c => c.DeleteOneAsync(
            It.IsAny<FilterDefinition<BasicModel>>(),
            It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
