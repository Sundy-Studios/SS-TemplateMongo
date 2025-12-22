namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Moq;

public class DeleteAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsyncCallsDomainOnce()
    {
        var id = "1";

        await Service.DeleteAsync(id);

        MockDomain.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
