namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Models;

public class GetByIdAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task GetByIdAsyncReturnsOkWhenFound()
    {
        var model = new BasicModel { Id = "1", Name = "Item", Location = "L" };

        MockService.Setup(s => s.GetByIdAsync("1", It.IsAny<CancellationToken>()))
                    .ReturnsAsync(model);

        var result = await Controller.GetBasicByIdAsync("1");

        var ok = Assert.IsType<OkObjectResult>(result);
        var dto = Assert.IsType<Dto.BasicDto>(ok.Value);
        Assert.Equal("1", dto.Id);
    }

    [Fact]
    public async Task GetByIdAsyncReturnsNotFoundWhenNull()
    {
        MockService.Setup(s => s.GetByIdAsync("2", It.IsAny<CancellationToken>()))
                    .ReturnsAsync((BasicModel?)null);

        var result = await Controller.GetBasicByIdAsync("2");

        Assert.IsType<NotFoundResult>(result);
    }
}
