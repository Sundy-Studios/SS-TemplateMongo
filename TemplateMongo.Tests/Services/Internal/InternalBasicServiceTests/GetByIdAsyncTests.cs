namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : InternalBasicServiceTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsModelWhenFound()
    {
        var model = new BasicModel { Id = "1", Name = "Item" };

        MockDomain.Setup(d => d.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                   .ReturnsAsync(model);

        var result = await Service.GetByIdAsync("1");

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }

    [Fact]
    public async Task GetByIdAsyncReturnsNullWhenNotFound()
    {
        MockDomain.Setup(d => d.GetByIdAsync("2", It.IsAny<CancellationToken>()))
                   .ReturnsAsync((BasicModel?)null);

        var result = await Service.GetByIdAsync("2");

        Assert.Null(result);
    }
}
