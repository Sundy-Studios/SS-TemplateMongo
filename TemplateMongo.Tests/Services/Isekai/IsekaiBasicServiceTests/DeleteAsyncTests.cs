namespace TemplateMongo.Tests.Services.Isekai.BasicServiceTests;

using Moq;

public class DeleteAsyncTests : BasicServiceTestsBase
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
