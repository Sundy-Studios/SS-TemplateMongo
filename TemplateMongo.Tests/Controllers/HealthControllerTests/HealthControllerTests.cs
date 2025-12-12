using Microsoft.AspNetCore.Mvc;

namespace TemplateMongo.Tests.Controllers.HealthControllerTests;

public class HealthControllerTests : HealthControllerTestsBase
{
    [Fact]
    public void Get_ReturnsOkWithStatus()
    {
        var result = _controller.Get();

        var ok = Assert.IsType<OkObjectResult>(result);
        var obj = Assert.IsType<System.Text.Json.JsonElement>(System.Text.Json.JsonSerializer.SerializeToElement(ok.Value));
        Assert.True(obj.TryGetProperty("status", out _));
    }
}
