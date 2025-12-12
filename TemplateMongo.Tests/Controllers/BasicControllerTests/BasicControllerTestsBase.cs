using Moq;
using TemplateMongo.Controllers;
using TemplateMongo.Services.Interfaces;

namespace TemplateMongo.Tests.Controllers.BasicControllerTests;

public abstract class BasicControllerTestsBase
{
    protected readonly Mock<IBasicService> _mockService;
    protected readonly BasicController _controller;

    protected BasicControllerTestsBase()
    {
        _mockService = new Mock<IBasicService>();
        _controller = new BasicController(_mockService.Object);
    }
}
