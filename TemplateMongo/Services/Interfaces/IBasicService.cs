using TemplateMongo.Models;
using TemplateMongo.Parameters;
using Common.Paging;

namespace TemplateMongo.Services.Interfaces;

public interface IBasicService
{
    Task<PagedResult<BasicModel>> GetAllAsync(GetAllBasicParams parameters, CancellationToken cancellationToken = default);
    Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default);
    Task<BasicModel> UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}