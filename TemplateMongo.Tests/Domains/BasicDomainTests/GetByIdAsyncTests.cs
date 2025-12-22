namespace TemplateMongo.Tests.Domains.BasicDomainTests;

using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsModel()
    {
        // Arrange
        var sampleModel = new BasicModel { Id = "1", Name = "Test" };
        MockDao.Setup(d => d.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                .ReturnsAsync(sampleModel);

        // Act
        var result = await Domain.GetByIdAsync("1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public async Task GetByIdAsyncCallsDaoOnceWithCorrectId()
    {
        await Domain.GetByIdAsync("1");

        MockDao.Verify(d => d.GetByIdAsync("1", It.IsAny<CancellationToken>()), Times.Once);
    }
}
