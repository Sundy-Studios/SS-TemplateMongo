// using Moq;
// using MongoDB.Driver;
// using TemplateMongo.Models;

// namespace TemplateMongo.Tests.Dao.BasicDaoTests;

// public class GetByIdAsyncTests : BasicDaoTestsBase
// {
//     [Fact]
//     public async Task GetByIdAsync_ReturnsModel()
//     {
//         var expected = new BasicModel { Id = "123", Name = "Test" };

//         var mockCursor = new Mock<IAsyncCursor<BasicModel>>();
//         mockCursor.SetupSequence(c => c.MoveNext(It.IsAny<CancellationToken>()))
//                   .Returns(true)
//                   .Returns(false);
//         mockCursor.SetupGet(c => c.Current).Returns(new[] { expected });

//         _mockCollection
//             .Setup(c => c.FindAsync(
//                 It.IsAny<FilterDefinition<BasicModel>>(),
//                 It.IsAny<FindOptions<BasicModel, BasicModel>>(),
//                 It.IsAny<CancellationToken>()))
//             .ReturnsAsync(mockCursor.Object);

//         var result = await _dao.GetByIdAsync("123");

//         Assert.NotNull(result);
//         Assert.Equal("123", result.Id);
//         Assert.Equal("Test", result.Name);
//     }

//     [Fact]
//     public async Task GetByIdAsync_CallsFindOnce()
//     {
//         await _dao.GetByIdAsync("123");

//         _mockCollection.Verify(c => c.FindAsync(
//             It.IsAny<FilterDefinition<BasicModel>>(),
//             It.IsAny<FindOptions<BasicModel, BasicModel>>(),
//             It.IsAny<CancellationToken>()),
//             Times.Once);
//     }
// }
