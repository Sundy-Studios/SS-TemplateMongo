namespace TemplateMongo.Tests.Controllers.HealthControllerTests;

using Microsoft.AspNetCore.Mvc;

public class HealthControllerTests : HealthControllerTestsBase
{
    [Fact]
    public void GetReturnsOkWithStatus()
    {
        var result = Controller.Get();

        var ok = Assert.IsType<OkObjectResult>(result);
        var obj = Assert.IsType<System.Text.Json.JsonElement>(System.Text.Json.JsonSerializer.SerializeToElement(ok.Value));
        Assert.True(obj.TryGetProperty("status", out _));
    }
}
