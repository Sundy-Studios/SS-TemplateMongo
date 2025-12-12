using Common.Paging;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using TemplateMongo.Dto;
using TemplateMongo.Models;
using TemplateMongo.Parameters;
using TemplateMongo.Services.Interfaces;

namespace TemplateMongo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasicController : ControllerBase
{
    private readonly IBasicService _service;

    public BasicController(IBasicService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllBasicParams parameters)
    {
        var result = await _service.GetAllAsync(parameters);

        var dtoItems = result.Items.Select(BasicModel.ToDto).ToList();

        var dtoResult = PagedResult<BasicDto>.Create(
            dtoItems,
            result.PageNumber,
            result.PageSize,
            result.TotalItems);

        return Ok(dtoResult);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBasicByIdAsync([FromRoute] string id)
    {
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));

        var basicModel = await _service.GetByIdAsync(id);

        return basicModel is not null ? Ok(BasicModel.ToDto(basicModel)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBasicAsync([FromBody] CreateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(parameters.Basic.Name, nameof(parameters.Basic.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Basic.Location, nameof(parameters.Basic.Location));

        var createdModel = await _service.CreateAsync(BasicModel.FromDto(parameters.Basic));
        var dto = BasicModel.ToDto(createdModel);

        return Created("", dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBasicAsync([FromRoute] UpdateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(parameters.Id, nameof(parameters.Id));
        Guard.AgainstNullOrWhiteSpace(parameters.Basic.Name, nameof(parameters.Basic.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Basic.Location, nameof(parameters.Basic.Location));

        var basicModel = await _service.UpdateAsync(parameters.Id, BasicModel.FromDto(parameters.Basic));

        return Ok(BasicModel.ToDto(basicModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBasicAsync([FromRoute] DeleteBasicParams parameters)
    {
        Guard.AgainstNullOrWhiteSpace(parameters.Id, nameof(parameters.Id));
        await _service.DeleteAsync(parameters.Id);

        return NoContent();
    }
}
