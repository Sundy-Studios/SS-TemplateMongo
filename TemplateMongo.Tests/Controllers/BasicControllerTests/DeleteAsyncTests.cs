using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class DeleteAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task DeleteBasicAsync_ReturnsNoContent()
    {
        var id = "1";

        var result = await _controller.DeleteBasicAsync(id);

        Assert.IsType<NoContentResult>(result);
        _mockService.Verify(s => s.DeleteAsync("1", It.IsAny<CancellationToken>()), Times.Once);
    }
}
