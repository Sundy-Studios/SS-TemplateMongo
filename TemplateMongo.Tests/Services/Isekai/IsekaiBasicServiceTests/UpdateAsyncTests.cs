namespace TemplateMongo.Tests.Services.IsekaiBasicServiceTests;

using Moq;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Models;

public class UpdateAsyncTests : IsekaiBasicServiceTestsBase
{
    [Fact]
    public async Task UpdateAsyncCallsInternalService()
    {
        MockInternalService.Setup(d => d.UpdateAsync(It.IsAny<string>(), It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

        await Service.UpdateAsync("1", new UpdateBasicParams { Name = "U", Location = "L" });

        MockInternalService.Verify(d => d.UpdateAsync("1", It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
