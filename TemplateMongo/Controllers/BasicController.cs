using Microsoft.AspNetCore.Mvc;
using TemplateMongo.Services.Interfaces;
using TemplateMongo.Utility;
using TemplateMongo.Dto;
using TemplateMongo.Parameters;
using TemplateMongo.Models;

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
        var basicModels = await _service.GetAllAsync();
        return Ok(basicModels?.Select(BasicModel.ToDto).ToList());
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
