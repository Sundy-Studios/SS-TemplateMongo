using Common.Paging;
using Moq;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

namespace TemplateMongo.Tests.Services.BasicServiceTests;

public class GetAllAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task GetAllAsync_ReturnsPagedResult()
    {
        var paged = PagedResult<BasicModel>.Create(new[] { new BasicModel { Id = "1", Name = "A" } }, 1, 10, 1);

        _mockDomain.Setup(d => d.GetAllAsync(It.IsAny<GetAllBasicParams>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(paged);

        var result = await _service.GetAllAsync(new GetAllBasicParams());

        Assert.NotNull(result);
        Assert.Equal(1, result.TotalItems);
    }
}
