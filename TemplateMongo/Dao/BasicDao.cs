using MongoDB.Driver;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Models;
using MongoDB.Bson;

namespace TemplateMongo.Dao;

public class BasicDao : IBasicDao
{
    private readonly ILogger<BasicDao> _logger;
    private readonly IMongoCollection<BasicModel> _collection;

    public BasicDao(ILogger<BasicDao> logger, IMongoDatabase database)
    {
        _logger = logger;
        _collection = database.GetCollection<BasicModel>("basics");

        SetupIndexes();
        PrintIndexes().Wait();
    }

    private void SetupIndexes()
    {
        CreateNameIndex();
        CreateLocationDateIndex();
    }

    private void CreateNameIndex()
    {
        var keys = Builders<BasicModel>.IndexKeys.Ascending(x => x.Name);
        var model = new CreateIndexModel<BasicModel>(keys, new CreateIndexOptions { Unique = false });
        _collection.Indexes.CreateOne(model);
    }

    private void CreateLocationDateIndex()
    {
        var keys = Builders<BasicModel>.IndexKeys
            .Ascending(x => x.Location)
            .Ascending(x => x.Date);
        var model = new CreateIndexModel<BasicModel>(keys, new CreateIndexOptions { Unique = false });
        _collection.Indexes.CreateOne(model);
    }

    public async Task<List<BasicModel>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _collection.Find(_ => true).ToListAsync(cancellationToken);

    public async Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default)
    {
        model.Id = Guid.NewGuid().ToString();
        await _collection.InsertOneAsync(model, cancellationToken: cancellationToken);
        return model;
    }

    public async Task UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default)
        => await _collection.ReplaceOneAsync(x => x.Id == id, model, cancellationToken: cancellationToken);

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        => await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
}
