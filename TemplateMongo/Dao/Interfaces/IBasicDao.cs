using TemplateMongo.Models;

namespace TemplateMongo.Dao.Interfaces;

public interface IBasicDao
{
    Task<List<BasicModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default);
    Task UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}