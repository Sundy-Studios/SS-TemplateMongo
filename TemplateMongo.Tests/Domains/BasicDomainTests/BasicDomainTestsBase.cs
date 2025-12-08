using Microsoft.Extensions.Logging;
using Moq;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Domains;

namespace TemplateMongo.Tests.Domains.BasicDomainTests;

public abstract class BasicDomainTestsBase
{
    protected readonly Mock<IBasicDao> _mockDao;
    protected readonly Mock<ILogger<BasicDomain>> _mockLogger;
    protected readonly BasicDomain _domain;

    protected BasicDomainTestsBase()
    {
        _mockDao = new Mock<IBasicDao>();
        _mockLogger = new Mock<ILogger<BasicDomain>>();
        _domain = new BasicDomain(_mockLogger.Object, _mockDao.Object);
    }
}
