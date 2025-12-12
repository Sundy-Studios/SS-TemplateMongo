using Common.Paging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TemplateMongo.Dto;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public class GetAllAsyncTests : BasicControllerTestsBase
{
    [Fact]
    public async Task GetAllAsync_ReturnsOkWithPagedDto()
    {
        var model = new BasicModel { Id = "1", Name = "A", Location = "L" };
        var paged = PagedResult<BasicModel>.Create(new[] { model }, 1, 10, 1);

        _mockService.Setup(s => s.GetAllAsync(It.IsAny<GetAllBasicParams>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(paged);

        var result = await _controller.GetAllAsync(new GetAllBasicParams());

        var ok = Assert.IsType<OkObjectResult>(result);
        var dtoPaged = Assert.IsType<PagedResult<BasicDto>>(ok.Value);
        Assert.Equal(1, dtoPaged.TotalItems);
        Assert.Equal("1", dtoPaged.Items.First().Id);
    }
}
