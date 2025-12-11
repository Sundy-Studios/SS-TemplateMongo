using TemplateMongo.Models;
using TemplateMongo.Parameters;
using Common.Paging;

namespace TemplateMongo.Dao.Interfaces;

public interface IBasicDao
{
    Task<PagedResult<BasicModel>> GetAllAsync(GetAllBasicParams parameters, CancellationToken cancellationToken = default);
    Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default);
    Task UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}