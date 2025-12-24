namespace TemplateMongo.Tests.Services.Isekai.HealthServiceTests;

public class HealthServiceTests : HealthServiceTestsBase
{
    [Fact]
    public async Task GetCompletesSuccessfully()
    {
        await Service.GetHealth();

        Assert.True(true);
    }
}
