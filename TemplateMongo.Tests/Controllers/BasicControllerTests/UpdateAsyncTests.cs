namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

public class UpdateAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task UpdateBasicAsyncReturnsOk()
    {
        var model = new BasicModel { Id = "1", Name = "N", Location = "L" };

        var id = "1";
        var param = new UpdateBasicParams { Name = "N", Location = "L" };

        var result = await Controller.UpdateBasicAsync(id, param);

        Assert.IsType<NoContentResult>(result);
        MockService.Verify(s => s.UpdateAsync(id, It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
