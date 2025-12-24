using Common.Paging;
using Common.Attributes.Isekai;
using Common.Services.Isekai;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;

namespace TemplateMongo.Client.Services;

[IsekaiGateAttribute("template-mongo-client", "basic")]
public interface IBasicService : IIsekaiService
{
    [IsekaiPath("api/basic", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    Task<PagedResult<BasicDto>> GetAllAsync([IsekaiFromQuery] GetAllBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    Task<BasicDto> GetByIdAsync([IsekaiFromRoute] string id);

    [IsekaiPath("api/basic", IsekaiHttpMethod.Post)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    Task<BasicDto> CreateAsync([IsekaiFromBody] CreateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Put)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    Task UpdateAsync([IsekaiFromRoute] string id, [IsekaiFromBody] UpdateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Delete)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    Task DeleteAsync([IsekaiFromRoute] string id);
}