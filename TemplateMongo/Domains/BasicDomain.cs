using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Models;

namespace TemplateMongo.Domains;

public class BasicDomain(
    ILogger<BasicDomain> logger,
    IBasicDao dao) : IBasicDomain
{
    private readonly ILogger<BasicDomain> _logger = logger;
    private readonly IBasicDao _dao = dao;

    public async Task<List<BasicModel>> GetAllAsync(CancellationToken cancellationToken = default) => await _dao.GetAllAsync(cancellationToken);

    public async Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _dao.GetByIdAsync(id, cancellationToken);

    public async Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default) => await _dao.CreateAsync(model, cancellationToken);

    public async Task<BasicModel> UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default)
    {
        model.Id = id;
        return await _dao.CreateAsync(model, cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default) => await _dao.DeleteAsync(id, cancellationToken);
}