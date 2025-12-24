namespace TemplateMongo.Tests.Services.IsekaiBasicServiceTests;

using Moq;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Models;

public class CreateAsyncTests : IsekaiBasicServiceTestsBase
{
    [Fact]
    public async Task CreateAsyncReturnsDto()
    {
        var created = new BasicModel { Id = "1", Name = "Created", Location = "Loc" };

        MockInternalService.Setup(d => d.CreateAsync(It.IsAny<BasicModel>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(created);

        var result = await Service.CreateAsync(new CreateBasicParams { Name = "Created", Location = "Loc" });

        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }
}
