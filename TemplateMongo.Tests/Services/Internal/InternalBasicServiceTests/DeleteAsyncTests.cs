namespace TemplateMongo.Tests.Services.InternalBasicServiceTests;

using Common.Exception.Models;
using Moq;

public class DeleteAsyncTests : InternalBasicServiceTestsBase
{
    [Fact]
    public async Task DeleteAsyncCallsDomainOnce()
    {
        var id = "1";

        MockUser
        .Setup(u => u.IsAuthenticated)
        .Returns(true);

        await Service.DeleteAsync(id);

        MockDomain.Verify(d => d.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsyncFailsAuthenticationIsFalse()
    {
        var id = "1";

        MockUser
        .Setup(u => u.IsAuthenticated)
        .Returns(false);

        var ex = await Assert.ThrowsAsync<ForbiddenException>(
            () => Service.DeleteAsync(id)
        );

        Assert.Equal(
            "User is not authorized to delete items.",
            ex.Message
        );
    }

    [Fact]
    public async Task DeleteAsyncFailsAuthenticationIsNull()
    {
        var id = "1";

        var ex = await Assert.ThrowsAsync<ForbiddenException>(
            () => Service.DeleteAsync(id)
        );

        Assert.Equal(
            "User is not authorized to delete items.",
            ex.Message
        );
    }

}
