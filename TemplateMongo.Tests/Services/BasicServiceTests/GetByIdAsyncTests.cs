namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsModelWhenFound()
    {
        var model = new BasicModel { Id = "1", Name = "Item" };

        _mockDomain.Setup(d => d.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                   .ReturnsAsync(model);

        var result = await _service.GetByIdAsync("1");

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }

    [Fact]
    public async Task GetByIdAsyncReturnsNullWhenNotFound()
    {
        _mockDomain.Setup(d => d.GetByIdAsync("2", It.IsAny<CancellationToken>()))
                   .ReturnsAsync((BasicModel?)null);

        var result = await _service.GetByIdAsync("2");

        Assert.Null(result);
    }
}
