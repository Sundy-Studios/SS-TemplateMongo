using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Services.BasicServiceTests;

public class CreateAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task CreateAsync_ReturnsCreatedModel()
    {
        var inputModel = new BasicModel { Name = "NewItem" };
        var createdModel = new BasicModel { Id = "1", Name = "NewItem" };

        _mockDomain.Setup(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(createdModel);

        var result = await _service.CreateAsync(inputModel);

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
        Assert.Equal("NewItem", result.Name);
    }

    [Fact]
    public async Task CreateAsync_CallsDomainOnce()
    {
        var inputModel = new BasicModel { Name = "NewItem" };

        await _service.CreateAsync(inputModel);

        _mockDomain.Verify(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()), Times.Once);
    }
}
