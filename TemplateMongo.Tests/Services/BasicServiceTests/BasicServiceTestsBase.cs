namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Microsoft.Extensions.Logging;
using Moq;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services;

public abstract class BasicServiceTestsBase
{
    protected readonly Mock<IBasicDomain> _mockDomain;
    protected readonly Mock<ILogger<BasicService>> _mockLogger;
    protected readonly BasicService _service;

    protected BasicServiceTestsBase()
    {
        _mockDomain = new Mock<IBasicDomain>();
        _mockLogger = new Mock<ILogger<BasicService>>();
        _service = new BasicService(_mockLogger.Object, _mockDomain.Object);
    }
}
