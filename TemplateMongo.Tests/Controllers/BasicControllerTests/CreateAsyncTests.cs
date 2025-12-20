using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Dto;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class CreateAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task CreateBasicAsync_ReturnsCreated()
    {
        var created = new BasicModel { Id = "1", Name = "N", Location = "L" };

        _mockService.Setup(s => s.CreateAsync(It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(created);

        var param = new CreateBasicParams { Name = "N", Location = "L" };

        var result = await _controller.CreateBasicAsync(param);

        var createdResult = Assert.IsType<CreatedResult>(result);
        var returned = Assert.IsType<BasicDto>(createdResult.Value);
        Assert.Equal("1", returned.Id);
    }
}
