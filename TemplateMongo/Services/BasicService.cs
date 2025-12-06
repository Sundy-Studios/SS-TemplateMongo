using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services.Interfaces;
using TemplateMongo.Models;

namespace TemplateMongo.Services;

public class BasicService(
    ILogger<BasicService> logger,
    IBasicDomain domain) : IBasicService
{
    private readonly ILogger<BasicService> _logger = logger;
    private readonly IBasicDomain _domain = domain;

    public async Task<List<BasicModel>> GetAllAsync(CancellationToken cancellationToken = default) => await _domain.GetAllAsync(cancellationToken);

    public async Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _domain.GetByIdAsync(id, cancellationToken);

    public async Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default) => await _domain.CreateAsync(model, cancellationToken);

    public async Task<BasicModel> UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default)
    {
        model.Id = id;
        return await _domain.CreateAsync(model, cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default) => await _domain.DeleteAsync(id, cancellationToken);
}