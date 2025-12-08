using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Domains.BasicDomainTests;

public class CreateAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task CreateAsync_ReturnsCreatedModel()
    {
        // Arrange
        var inputModel = new BasicModel { Name = "NewItem" };
        var createdModel = new BasicModel { Id = "1", Name = "NewItem" };

        _mockDao.Setup(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(createdModel);

        // Act
        var result = await _domain.CreateAsync(inputModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
        Assert.Equal("NewItem", result.Name);
    }

    [Fact]
    public async Task CreateAsync_CallsDaoOnce()
    {
        var inputModel = new BasicModel { Name = "NewItem" };

        // Act
        await _domain.CreateAsync(inputModel);

        // Assert
        _mockDao.Verify(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()), Times.Once);
    }
}
