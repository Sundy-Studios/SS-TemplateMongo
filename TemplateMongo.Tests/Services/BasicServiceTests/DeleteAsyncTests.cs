using Moq;

namespace TemplateMongo.Tests.Services.BasicServiceTests;

public class DeleteAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsync_CallsDomainOnce()
    {
        var id = "1";

        await _service.DeleteAsync(id);

        _mockDomain.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
