namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

using Moq;
using TemplateMongo.Controllers;
using TemplateMongo.Services.Interfaces;

public abstract class BasicControllerTestsBase
{
    protected Mock<IBasicService> MockService { get; }
    protected BasicController Controller { get; }

    protected BasicControllerTestsBase()
    {
        MockService = new Mock<IBasicService>();
        Controller = new BasicController(MockService.Object);
    }
}
