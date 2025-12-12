using Common.Paging;
using MongoDB.Driver;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

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

    public async Task<PagedResult<BasicModel>> GetAllAsync(
        GetAllBasicParams parameters,
        CancellationToken cancellationToken = default)
    {
        var filter = Builders<BasicModel>.Filter.Empty;

        var totalItems = await _collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        var items = await _collection.Find(filter)
            .SortBy(x => x.Location)
            .ThenBy(x => x.Date)
            .Skip(parameters.Skip)
            .Limit(parameters.PageSize)
            .ToListAsync(cancellationToken);

        return PagedResult<BasicModel>.Create(
            items,
            parameters.PageNumber,
            parameters.PageSize,
            totalItems);
    }

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
