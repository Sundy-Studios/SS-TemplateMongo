namespace TemplateMongo.Tests.Services.Isekai.BasicServiceTests;

using Moq;
using TemplateMongo.Services.Internal.Interfaces;
using TemplateMongo.Services.Isekai;

public abstract class BasicServiceTestsBase
{
    protected Mock<IInternalBasicService> MockInternalService { get; }
    protected BasicService Service { get; }

    protected BasicServiceTestsBase()
    {
        MockInternalService = new Mock<IInternalBasicService>();
        Service = new BasicService(MockInternalService.Object);
    }
}
