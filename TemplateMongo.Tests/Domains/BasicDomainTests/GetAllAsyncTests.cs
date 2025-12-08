using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Domains.BasicDomainTests;

public class GetAllAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task GetAllAsync_ReturnsListOfModels()
    {
        // Arrange
        var sampleList = new List<BasicModel>
        {
            new BasicModel { Id = "1", Name = "Test1" },
            new BasicModel { Id = "2", Name = "Test2" }
        };

        _mockDao.Setup(d => d.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(sampleList);

        // Act
        var result = await _domain.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Test1", result[0].Name);
        Assert.Equal("Test2", result[1].Name);
    }

    [Fact]
    public async Task GetAllAsync_CallsDaoOnce()
    {
        // Act
        await _domain.GetAllAsync();

        // Assert
        _mockDao.Verify(d => d.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
