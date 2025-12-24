namespace TemplateMongo.Tests.Services.IsekaiHealthServiceTests;

public class HealthServiceTests
{
    [Fact]
    public async Task GetCompletesSuccessfully()
    {
        var service = new TemplateMongo.Services.Isekai.HealthService();

        await service.Get();

        Assert.True(true);
    }
}
