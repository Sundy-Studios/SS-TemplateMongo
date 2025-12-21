namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Moq;
using TemplateMongo.Models;

public class UpdateAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task UpdateAsyncForwardsIdAndReturnsUpdated()
    {
        var model = new BasicModel { Name = "Updated" };
        var updated = new BasicModel { Id = "1", Name = "Updated" };

        MockDomain.Setup(d => d.CreateAsync(It.Is<BasicModel>(m => m.Id == "1" && m.Name == "Updated"), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(updated);

        var result = await Service.UpdateAsync("1", model);

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }
}
