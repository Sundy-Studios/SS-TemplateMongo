namespace TemplateMongo.Domains.Interfaces;

using Common.Paging;
using TemplateMongo.Models;
using TemplateMongo.Parameters;

public interface IBasicDomain
{
    public Task<PagedResult<BasicModel>> GetAllAsync(GetAllBasicParams parameters, CancellationToken cancellationToken = default);
    public Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    public Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default);
    public Task<BasicModel> UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default);
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
