using Moq;

namespace TemplateMongo.Tests.Domains.BasicDomainTests;

public class DeleteAsyncTests : BasicDomainTestsBase
{
    [Fact]
    public async Task DeleteAsync_CallsDaoOnce()
    {
        // Arrange
        var id = "1";

        _mockDao.Setup(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

        // Act
        await _domain.DeleteAsync(id);

        // Assert
        _mockDao.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
