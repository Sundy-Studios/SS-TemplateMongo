using Common.Paging;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;

namespace TemplateMongo.Client.Interfaces;

public interface IBasicApi
{
    Task<PagedResult<BasicDto>> GetAllAsync(
        GetAllBasicParams parameters,
        CancellationToken ct = default);

    Task<BasicDto> GetByIdAsync(
        string id,
        CancellationToken ct = default);

    Task<BasicDto> CreateAsync(
        CreateBasicParams parameters,
        CancellationToken ct = default);

    Task UpdateAsync(
        string id,
        UpdateBasicParams parameters,
        CancellationToken ct = default);

    Task DeleteAsync(
        string id,
        CancellationToken ct = default);
}
