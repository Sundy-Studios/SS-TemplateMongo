using Moq;
using TemplateMongo.Controllers;

namespace TemplateMongo.Tests.Controllers.HealthControllerTests;

public abstract class HealthControllerTestsBase
{
    protected readonly HealthController _controller;

    protected HealthControllerTestsBase()
    {
        _controller = new HealthController();
    }
}
