namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Common.Paging;
using Moq;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

public class GetAllAsyncTests : BasicServiceTestsBase
{
    [Fact]
    public async Task GetAllAsyncReturnsPagedResult()
    {
        var paged = PagedResultFactory.Create([new BasicModel { Id = "1", Name = "A" }], 1, 10, 1);

        _mockDomain.Setup(d => d.GetAllAsync(It.IsAny<GetAllBasicParams>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(paged);

        var result = await _service.GetAllAsync(new GetAllBasicParams());

        Assert.NotNull(result);
        Assert.Equal(1, result.TotalItems);
    }
}
