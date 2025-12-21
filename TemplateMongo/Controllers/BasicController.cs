using Common.Paging;
using Common.Utility;
using Microsoft.AspNetCore.Authorization;
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

        var dtoResult = PagedResultFactory.Create(
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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateBasicAsync([FromBody] CreateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        var createdModel = await _service.CreateAsync(BasicModel.FromParams(parameters));
        var dto = BasicModel.ToDto(createdModel);

        return Created("", dto);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBasicAsync([FromRoute] string id, [FromBody] UpdateBasicParams parameters)
    {
        Guard.AgainstNull(parameters, nameof(parameters));
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        Guard.AgainstNullOrWhiteSpace(parameters.Name, nameof(parameters.Name));
        Guard.AgainstNullOrWhiteSpace(parameters.Location, nameof(parameters.Location));

        var basicModel = await _service.UpdateAsync(id, BasicModel.FromParams(id, parameters));
        return Ok(BasicModel.ToDto(basicModel));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBasicAsync([FromRoute] string id)
    {
        Guard.AgainstNullOrWhiteSpace(id, nameof(id));
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
