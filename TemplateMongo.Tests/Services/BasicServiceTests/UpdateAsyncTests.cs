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

        await Service.UpdateAsync("1", model);

        MockDomain.Verify(d => d.UpdateAsync("1", It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
