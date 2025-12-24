namespace TemplateMongo.Tests.Services.IsekaiBasicServiceTests;

using Moq;
using TemplateMongo.Services.Isekai;
using TemplateMongo.Services.Internal.Interfaces;

public abstract class IsekaiBasicServiceTestsBase
{
    protected Mock<IInternalBasicService> MockInternalService { get; }
    protected BasicService Service { get; }

    protected IsekaiBasicServiceTestsBase()
    {
        MockInternalService = new Mock<IInternalBasicService>();
        Service = new BasicService(MockInternalService.Object);
    }
}
