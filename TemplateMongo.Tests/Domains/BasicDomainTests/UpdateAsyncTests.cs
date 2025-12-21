namespace TemplateMongo.Tests.Domains.BasicDomainTests;

using Moq;
using TemplateMongo.Models;

public class UpdateAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task UpdateAsyncReturnsUpdatedModel()
    {
        // Arrange
        var id = "1";
        var inputModel = new BasicModel { Name = "UpdatedItem" };
        var updatedModel = new BasicModel { Id = id, Name = "UpdatedItem" };

        MockDao.Setup(d => d.CreateAsync(It.Is<BasicModel>(m => m.Id == id), It.IsAny<CancellationToken>()))
                .ReturnsAsync(updatedModel);

        // Act
        var result = await Domain.UpdateAsync(id, inputModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal("UpdatedItem", result.Name);
    }

    [Fact]
    public async Task UpdateAsyncCallsDaoOnceWithIdSet()
    {
        var id = "1";
        var inputModel = new BasicModel { Name = "UpdatedItem" };

        // Act
        await Domain.UpdateAsync(id, inputModel);

        // Assert
        MockDao.Verify(d => d.CreateAsync(It.Is<BasicModel>(m => m.Id == id), It.IsAny<CancellationToken>()), Times.Once);
    }
}
