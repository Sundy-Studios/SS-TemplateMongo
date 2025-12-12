using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class GetByIdAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task GetByIdAsync_ReturnsOk_WhenFound()
    {
        var model = new BasicModel { Id = "1", Name = "Item", Location = "L" };

        _mockService.Setup(s => s.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                    .ReturnsAsync(model);

        var result = await _controller.GetBasicByIdAsync("1");

        var ok = Assert.IsType<OkObjectResult>(result);
        var dto = Assert.IsType<TemplateMongo.Dto.BasicDto>(ok.Value);
        Assert.Equal("1", dto.Id);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNotFound_WhenNull()
    {
        _mockService.Setup(s => s.GetByIdAsync("2", It.IsAny<CancellationToken>()))
                    .ReturnsAsync((BasicModel?)null);

        var result = await _controller.GetBasicByIdAsync("2");

        Assert.IsType<NotFoundResult>(result);
    }
}
