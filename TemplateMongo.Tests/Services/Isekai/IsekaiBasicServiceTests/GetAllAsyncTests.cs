namespace TemplateMongo.Tests.Services.IsekaiBasicServiceTests;

using Common.Paging;
using Moq;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Models;

public class GetAllAsyncTests : IsekaiBasicServiceTestsBase
{
    [Fact]
    public async Task GetAllAsyncReturnsPagedResult()
    {
        var paged = PagedResultFactory.Create(new[] { new BasicModel { Id = "1", Name = "A" } }, 1, 10, 1);

        MockInternalService.Setup(d => d.GetAllAsync(It.IsAny<GetAllBasicParams>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(paged);

        var result = await Service.GetAllAsync(new GetAllBasicParams());

        Assert.NotNull(result);
        Assert.Equal(1, result.TotalItems);
    }
}
