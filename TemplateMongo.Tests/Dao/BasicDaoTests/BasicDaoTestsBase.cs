using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Moq;
using TemplateMongo.Dao;
using TemplateMongo.Models;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public abstract class BasicDaoTestsBase
{
    protected readonly Mock<IMongoCollection<BasicModel>> _mockCollection;
    protected readonly Mock<IMongoIndexManager<BasicModel>> _mockIndexes;
    protected readonly Mock<IMongoDatabase> _mockDatabase;
    protected readonly Mock<ILogger<BasicDao>> _mockLogger;
    protected readonly BasicDao _dao;

    protected BasicDaoTestsBase()
    {
        _mockCollection = new Mock<IMongoCollection<BasicModel>>();

        // Needed so the driver doesn't throw on CollectionNamespace / DocumentSerializer
        _mockCollection.SetupGet(c => c.CollectionNamespace)
            .Returns(new CollectionNamespace(new DatabaseNamespace("testDb"), "basics"));
        _mockCollection.SetupGet(c => c.DocumentSerializer)
            .Returns(MongoDB.Bson.Serialization.BsonSerializer.SerializerRegistry.GetSerializer<BasicModel>());
        _mockCollection.SetupGet(c => c.Settings)
            .Returns(new MongoCollectionSettings());

        // Mock Indexes so CreateOne won't throw
        _mockIndexes = new Mock<IMongoIndexManager<BasicModel>>();
        _mockIndexes
            .Setup(i => i.CreateOne(It.IsAny<CreateIndexModel<BasicModel>>(), It.IsAny<CreateOneIndexOptions>(), It.IsAny<CancellationToken>()))
            .Returns("ok");
        _mockCollection.SetupGet(c => c.Indexes).Returns(_mockIndexes.Object);

        _mockDatabase = new Mock<IMongoDatabase>();
        _mockDatabase
            .Setup(d => d.GetCollection<BasicModel>("basics", null))
            .Returns(_mockCollection.Object);

        _mockLogger = new Mock<ILogger<BasicDao>>();

        // This now works because Indexes are mocked
        _dao = new BasicDao(_mockLogger.Object, _mockDatabase.Object);
    }

    public static Mock<IAsyncCursor<BasicModel>> CreateMockCursor(List<BasicModel> models)
    {
        var mockCursor = new Mock<IAsyncCursor<BasicModel>>();
        
        mockCursor.Setup(_ => _.Current).Returns(models);
        mockCursor
            .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
            .Returns(true)
            .Returns(false);
        mockCursor
            .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(true)
            .ReturnsAsync(false);

        return mockCursor;
    }

}
