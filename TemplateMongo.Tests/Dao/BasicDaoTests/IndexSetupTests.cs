// using MongoDB.Driver;
// using Moq;
// using TemplateMongo.Models;

// namespace TemplateMongo.Tests.Dao.BasicDaoTests;

// public class IndexSetupTests : BasicDaoTestsBase
// {
//     [Fact]
//     public void Constructor_Creates_Id_Index()
//     {
//         _mockCollection.Verify(c => c.Indexes.CreateOne(
//             It.Is<CreateIndexModel<BasicModel>>(i =>
//                 i.Keys.ToString().Contains("Id")),
//             null),
//             Times.Once);
//     }
// }
