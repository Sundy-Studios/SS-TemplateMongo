namespace TemplateMongo.Tests.Domains.BasicDomainTests;

using Moq;
using TemplateMongo.Models;

public class CreateAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task CreateAsyncReturnsCreatedModel()
    {
        // Arrange
        var inputModel = new BasicModel { Name = "NewItem" };
        var createdModel = new BasicModel { Id = "1", Name = "NewItem" };

        MockDao.Setup(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(createdModel);

        // Act
        var result = await Domain.CreateAsync(inputModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
        Assert.Equal("NewItem", result.Name);
    }

    [Fact]
    public async Task CreateAsyncCallsDaoOnce()
    {
        var inputModel = new BasicModel { Name = "NewItem" };

        // Act
        await Domain.CreateAsync(inputModel);

        // Assert
        MockDao.Verify(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()), Times.Once);
    }
}
