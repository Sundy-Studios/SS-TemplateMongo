using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Models;

namespace TemplateMongo.Dao;

public class BasicDao(
    ILogger<BasicDao> logger,
    IMongoDatabase database) : IBasicDao
{
    private readonly ILogger<BasicDao> _logger = logger;
    private readonly IMongoCollection<BasicModel> _collection = database.GetCollection<BasicModel>("basics");

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