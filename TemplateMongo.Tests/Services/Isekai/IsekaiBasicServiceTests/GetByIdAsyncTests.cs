namespace TemplateMongo.Tests.Services.Isekai.BasicServiceTests;

using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsDtoWhenFound()
    {
        var model = new BasicModel { Id = "1", Name = "Item" };

        MockInternalService.Setup(d => d.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                           .ReturnsAsync(model);

        var result = await Service.GetByIdAsync("1");

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }

    [Fact]
    public async Task GetByIdAsyncReturnsNullWhenNotFound()
    {
        MockInternalService
        .Setup(d => d.GetByIdAsync("2", It.IsAny<CancellationToken>()))
        .ThrowsAsync(new KeyNotFoundException());

        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            Service.GetByIdAsync("2"));
    }
}
