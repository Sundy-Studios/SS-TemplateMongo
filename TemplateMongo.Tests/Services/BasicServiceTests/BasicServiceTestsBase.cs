namespace TemplateMongo.Tests.Services.BasicServiceTests;

using Microsoft.Extensions.Logging;
using Moq;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services;

public abstract class BasicServiceTestsBase
{
    protected Mock<IBasicDomain> MockDomain { get; }
    protected Mock<ILogger<BasicService>> MockLogger { get; }
    protected BasicService Service { get; }

    protected BasicServiceTestsBase()
    {
        MockDomain = new Mock<IBasicDomain>();
        MockLogger = new Mock<ILogger<BasicService>>();
        Service = new BasicService(MockLogger.Object, MockDomain.Object);
    }
}
