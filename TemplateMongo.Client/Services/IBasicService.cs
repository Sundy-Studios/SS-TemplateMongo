namespace TemplateMongo.Client.Services;

using System.Net;
using Common.Exceptions.Responses;
using Common.Isekai.Attributes;
using Common.Isekai.Services;
using Common.Paging;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;

[IsekaiGate("template-mongo-client", "basic")]
[IsekaiConsumes("application/json")]
[IsekaiProduces("application/json")]
[IsekaiResponse((int)HttpStatusCode.BadRequest, typeof(ExceptionDetailsResponse), "The server could not understand the request due to invalid syntax.")]
[IsekaiResponse((int)HttpStatusCode.Unauthorized, typeof(ExceptionDetailsResponse), "Network credentials are no longer valid.")]
[IsekaiResponse((int)HttpStatusCode.Forbidden, typeof(ExceptionDetailsResponse), "The client does not have access rights to the content.")]
[IsekaiResponse((int)HttpStatusCode.NotFound, typeof(ExceptionDetailsResponse), "The server can not find the requested resource.")]
[IsekaiResponse((int)HttpStatusCode.InternalServerError, typeof(ExceptionResponse), "Internal server error")]
public interface IBasicService : IIsekaiService
{
    [IsekaiPath("api/basic", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    [IsekaiResponse((int)HttpStatusCode.OK, typeof(PagedResult<BasicDto>), "Get all basic items response")]
    public Task<PagedResult<BasicDto>> GetAllAsync([IsekaiFromQuery] GetAllBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    [IsekaiResponse((int)HttpStatusCode.OK, typeof(BasicDto), "Get basic item response by ID")]
    public Task<BasicDto> GetByIdAsync([IsekaiFromRoute] string id);

    [IsekaiPath("api/basic", IsekaiHttpMethod.Post)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    [IsekaiResponse((int)HttpStatusCode.OK, typeof(BasicDto), "Create basic item")]
    [IsekaiAuthorize]
    public Task<BasicDto> CreateAsync([IsekaiFromBody] CreateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Put)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    [IsekaiResponse((int)HttpStatusCode.OK, null, "Update basic item")]
    [IsekaiAuthorize]
    public Task UpdateAsync([IsekaiFromRoute] string id, [IsekaiFromBody] UpdateBasicParams parameters);

    [IsekaiPath("api/basic/{id}", IsekaiHttpMethod.Delete)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Medium)]
    [IsekaiResponse((int)HttpStatusCode.OK, null, "Delete basic item")]
    [IsekaiAuthorize]
    public Task DeleteAsync([IsekaiFromRoute] string id);
}
