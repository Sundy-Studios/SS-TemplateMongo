namespace TemplateMongo.Services.Isekai;

using Common.Paging;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;
using TemplateMongo.Client.Services;
using TemplateMongo.Models;
using TemplateMongo.Services.Internal.Interfaces;

public class BasicService(IInternalBasicService service) : IBasicService
{
    private readonly IInternalBasicService _service = service;

    public async Task<PagedResult<BasicDto>> GetAllAsync([FromQuery] GetAllBasicParams parameters)
    {
        var result = await _service.GetAllAsync(parameters);

        var dtoItems = result.Items.Select(BasicModel.ToDto).ToList();

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

        return BasicModel.ToDto(basicModel);
    }

    public async Task<BasicDto> CreateAsync([FromBody] CreateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        var createdModel = await _service.CreateAsync(BasicModel.FromParams(parameters));
        return BasicModel.ToDto(createdModel);
    }

    public async Task UpdateAsync([FromRoute] string id, [FromBody] UpdateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        await _service.UpdateAsync(id, BasicModel.FromParams(id, parameters));
    }

    public async Task DeleteAsync([FromRoute] string id)
    {
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        await _service.DeleteAsync(id);
    }
}
