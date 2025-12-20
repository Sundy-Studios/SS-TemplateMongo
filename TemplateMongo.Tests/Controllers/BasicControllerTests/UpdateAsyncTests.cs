using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class UpdateAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task UpdateBasicAsync_ReturnsOk()
    {
        var model = new BasicModel { Id = "1", Name = "N", Location = "L" };

        _mockService.Setup(s => s.UpdateAsync("1", It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(model);

        var id = "1";
        var param = new UpdateBasicParams { Name = "N", Location = "L" };

        var result = await _controller.UpdateBasicAsync(id, param);

        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<TemplateMongo.Dto.BasicDto>(ok.Value);
        Assert.Equal("1", returned.Id);
    }
}
