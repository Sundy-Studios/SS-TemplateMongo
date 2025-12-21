namespace TemplateMongo.Tests.Controllers.HealthControllerTests;

using TemplateMongo.Controllers;

public abstract class HealthControllerTestsBase
{
    protected readonly HealthController _controller;

    protected HealthControllerTestsBase() => _controller = new HealthController();
}
