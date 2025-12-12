using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class DeleteAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task DeleteBasicAsync_ReturnsNoContent()
    {
        var param = new DeleteBasicParams { Id = "1" };

        var result = await _controller.DeleteBasicAsync(param);

        Assert.IsType<NoContentResult>(result);
        _mockService.Verify(s => s.DeleteAsync("1", It.IsAny<CancellationToken>()), Times.Once);
    }
}
