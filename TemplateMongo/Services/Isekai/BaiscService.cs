namespace TemplateMongo.Services.Isekai;

using Common.Paging;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Client.Services;
using TemplateMongo.Models;
using TemplateMongo.Services.Internal.Interfaces;
using TemplateMongo.Mapping;

public class BasicService(IInternalBasicService service) : IBasicService
{
    private readonly IInternalBasicService _service = service;

    public async Task<PagedResult<BasicDto>> GetAllAsync([FromQuery] GetAllBasicParams parameters)
    {
        var result = await _service.GetAllAsync(parameters);

        var dtoItems = result.Items.Select(BasicMapper.ToDto).ToList();

        return PagedResultFactory.Create(
            dtoItems,
            result.PageNumber,
            result.PageSize,
            result.TotalItems);
    }

    public async Task<BasicDto> GetByIdAsync([FromRoute] string id)
    {
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));

        var basicModel = await _service.GetByIdAsync(id);

        return BasicMapper.ToDto(basicModel);
    }

    public async Task<BasicDto> CreateAsync([FromBody] CreateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        var createdModel = await _service.CreateAsync(BasicMapper.From(parameters));
        return BasicMapper.ToDto(createdModel);
    }

    public async Task UpdateAsync([FromRoute] string id, [FromBody] UpdateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        var model = new BasicModel() { Id = id };
        BasicMapper.Apply(parameters, model);
        await _service.UpdateAsync(id, model);
    }

    public async Task DeleteAsync([FromRoute] string id)
    {
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        await _service.DeleteAsync(id);
    }
}
