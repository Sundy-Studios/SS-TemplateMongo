namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Moq;
using TemplateMongo.Models;

public class CreateAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task CreateAsyncReturnsCreatedModel()
    {
        var inputModel = new BasicModel { Name = "NewItem" };
        var createdModel = new BasicModel { Id = "1", Name = "NewItem" };

        MockDomain.Setup(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(createdModel);

        var result = await Service.CreateAsync(inputModel);

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
        Assert.Equal("NewItem", result.Name);
    }

    [Fact]
    public async Task CreateAsyncCallsDomainOnce()
    {
        var inputModel = new BasicModel { Name = "NewItem" };

        await Service.CreateAsync(inputModel);

        MockDomain.Verify(d => d.CreateAsync(inputModel, It.IsAny<CancellationToken>()), Times.Once);
    }
}
