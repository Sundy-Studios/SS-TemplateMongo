// using MongoDB.Driver;
// using Moq;
// using TemplateMongo.Models;

// namespace TemplateMongo.Tests.Dao.BasicDaoTests;

// public class GetAllAsyncTests : BasicDaoTestsBase
// {
//     [Fact]
//     public async Task GetAllAsync_ReturnsAllModels()
//     {
//         var models = new List<BasicModel>
//         {
//             new BasicModel { Id = "1", Name = "A" },
//             new BasicModel { Id = "2", Name = "B" }
//         };

//         var mockCursor = CreateMockCursor(models);

//         _mockCollection
//             .Setup(c => c.FindAsync(
//                 It.IsAny<FilterDefinition<BasicModel>>(),
//                 It.IsAny<FindOptions<BasicModel, BasicModel>>(),
//                 It.IsAny<CancellationToken>()))
//             .ReturnsAsync(mockCursor.Object);

//         var result = await _dao.GetAllAsync();

//         Assert.Equal(2, result.Count);
//         Assert.Equal("1", result[0].Id);
//         Assert.Equal("2", result[1].Id);
//     }
// }
