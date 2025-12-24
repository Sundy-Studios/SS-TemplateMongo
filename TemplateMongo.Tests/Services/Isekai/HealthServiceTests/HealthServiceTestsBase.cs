namespace TemplateMongo.Tests.Services.Isekai.HealthServiceTests;

using TemplateMongo.Services.Isekai;

public abstract class HealthServiceTestsBase
{
    protected HealthService Service { get; }

    protected HealthServiceTestsBase() => Service = new HealthService();
}
