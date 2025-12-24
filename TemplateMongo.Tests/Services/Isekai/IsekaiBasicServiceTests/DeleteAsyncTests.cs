namespace TemplateMongo.Tests.Services.IsekaiBasicServiceTests;

using Moq;

public class DeleteAsyncTests : IsekaiBasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsyncCallsInternalService()
    {
        MockInternalService.Setup(d => d.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

        await Service.DeleteAsync("1");

        MockInternalService.Verify(d => d.DeleteAsync("1", It.IsAny<CancellationToken>()), Times.Once);
    }
}
