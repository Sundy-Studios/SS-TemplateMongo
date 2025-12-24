namespace TemplateMongo.Client.Services;

using Common.Attributes.Isekai;
using Common.Paging;
using Common.Services.Isekai;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;

[IsekaiGate("template-mongo-client", "basic")]
public interface IBasicService : IIsekaiService
{
    [IsekaiPath("api/basic", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    public Task<PagedResult<BasicDto>> GetAllAsync([IsekaiFromQuery] GetAllBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    public Task<BasicDto> GetByIdAsync([IsekaiFromRoute] string id);

    [IsekaiPath("api/basic", IsekaiHttpMethod.Post)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    public Task<BasicDto> CreateAsync([IsekaiFromBody] CreateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Put)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    public Task UpdateAsync([IsekaiFromRoute] string id, [IsekaiFromBody] UpdateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Delete)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    public Task DeleteAsync([IsekaiFromRoute] string id);
}
