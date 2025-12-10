using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public class CreateAsyncTests : BasicDaoTestsBase
{
    [Fact]
    public async Task CreateAsync_CallsInsertOne()
    {
        var model = new BasicModel { Name = "New" };

        await _dao.CreateAsync(model);

        _mockCollection.Verify(c => c.InsertOneAsync(
            It.Is<BasicModel>(m => m.Name == "New" && !string.IsNullOrEmpty(m.Id)),
            null,
            It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
