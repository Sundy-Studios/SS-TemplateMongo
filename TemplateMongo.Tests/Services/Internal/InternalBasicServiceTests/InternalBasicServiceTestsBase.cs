namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Microsoft.Extensions.Logging;
using Moq;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services.Internal;

public abstract class InternalBasicServiceTestsBase
{
    protected Mock<IBasicDomain> MockDomain { get; }
    protected Mock<ILogger<InternalBasicService>> MockLogger { get; }
    protected InternalBasicService Service { get; }

    protected InternalBasicServiceTestsBase()
    {
        MockDomain = new Mock<IBasicDomain>();
        MockLogger = new Mock<ILogger<InternalBasicService>>();
        Service = new InternalBasicService(MockLogger.Object, MockDomain.Object);
    }
}
