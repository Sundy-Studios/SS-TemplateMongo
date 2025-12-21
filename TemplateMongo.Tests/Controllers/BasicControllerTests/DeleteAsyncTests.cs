namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

using Microsoft.AspNetCore.Mvc;
using Moq;

public class DeleteAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task DeleteBasicAsyncReturnsNoContent()
    {
        var id = "1";

        var result = await Controller.DeleteBasicAsync(id);

        Assert.IsType<NoContentResult>(result);
        MockService.Verify(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
