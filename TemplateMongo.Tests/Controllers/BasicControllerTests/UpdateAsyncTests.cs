using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Dto;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class UpdateAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task UpdateBasicAsync_ReturnsOk()
    {
        var dto = new BasicDto { Name = "N", Location = "L" };
        var model = new BasicModel { Id = "1", Name = "N", Location = "L" };

        _mockService.Setup(s => s.UpdateAsync("1", It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(model);

        var param = new UpdateBasicParams { Id = "1", Basic = dto };

        var result = await _controller.UpdateBasicAsync(param);

        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<TemplateMongo.Dto.BasicDto>(ok.Value);
        Assert.Equal("1", returned.Id);
    }
}
