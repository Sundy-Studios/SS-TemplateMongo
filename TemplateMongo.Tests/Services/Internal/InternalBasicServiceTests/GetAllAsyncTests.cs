namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Common.Paging;
using Moq;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Models;

public class GetAllAsyncTests : InternalBasicServiceTestsBase
{
    [Fact]
    public async Task GetAllAsyncReturnsPagedResult()
    {
        var paged = PagedResultFactory.Create([new BasicModel { Id = "1", Name = "A" }], 1, 10, 1);

        MockDomain.Setup(d => d.GetAllAsync(It.IsAny<GetAllBasicParams>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(paged);

        var result = await Service.GetAllAsync(new GetAllBasicParams());

        Assert.NotNull(result);
        Assert.Equal(1, result.TotalItems);
    }
}
