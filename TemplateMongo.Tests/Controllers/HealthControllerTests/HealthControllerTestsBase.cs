namespace TemplateMongo.Tests.Controllers.HealthControllerTests;

using TemplateMongo.Controllers;

public abstract class HealthControllerTestsBase
{
    protected HealthController Controller { get; }

    protected HealthControllerTestsBase() => Controller = new HealthController();
}
