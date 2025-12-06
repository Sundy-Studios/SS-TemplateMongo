using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateMongo.Models;

namespace TemplateMongo.Domains.Interfaces;

public interface IBasicDomain
{
    Task<List<BasicModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BasicModel> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<BasicModel> CreateAsync(BasicModel model, CancellationToken cancellationToken = default);
    Task<BasicModel> UpdateAsync(string id, BasicModel model, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}