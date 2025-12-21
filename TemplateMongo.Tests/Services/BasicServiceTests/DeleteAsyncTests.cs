namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Moq;

public class DeleteAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsyncCallsDomainOnce()
    {
        var id = "1";

        await _service.DeleteAsync(id);

        _mockDomain.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
