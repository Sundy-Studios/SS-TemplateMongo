namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Common.Auth;
using Microsoft.Extensions.Logging;
using Moq;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services.Internal;

public abstract class InternalBasicServiceTestsBase
{
    protected Mock<IBasicDomain> MockDomain { get; }
    protected Mock<ILogger<InternalBasicService>> MockLogger { get; }
    protected InternalBasicService Service { get; }
    protected Mock<ICurrentUser> MockUser { get; }
    protected InternalBasicServiceTestsBase()
    {
        MockDomain = new Mock<IBasicDomain>();
        MockLogger = new Mock<ILogger<InternalBasicService>>();
        MockUser = new Mock<ICurrentUser>();
        Service = new InternalBasicService(MockLogger.Object, MockDomain.Object, MockUser.Object);
    }
}
