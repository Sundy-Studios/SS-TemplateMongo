namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Moq;

public class DeleteAsyncTests : InternalBasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsyncCallsDomainOnce()
    {
        var id = "1";

        await Service.DeleteAsync(id);

        MockDomain.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
