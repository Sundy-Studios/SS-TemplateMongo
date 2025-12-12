using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Services.BasicServiceTests;

public class UpdateAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task UpdateAsync_ForwardsIdAndReturnsUpdated()
    {
        var model = new BasicModel { Name = "Updated" };
        var updated = new BasicModel { Id = "1", Name = "Updated" };

        _mockDomain.Setup(d => d.CreateAsync(It.Is<BasicModel>(m => m.Id == "1" && m.Name == "Updated"), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(updated);

        var result = await _service.UpdateAsync("1", model);

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }
}
