using System.Net.Http.Json;
using Common.Paging;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Interfaces;
using TemplateMongo.Client.Parameters;

namespace TemplateMongo.Client.Http;

internal sealed class BasicApiClient : IBasicApi
{
    private readonly HttpClient _http;

    public BasicApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<PagedResult<BasicDto>> GetAllAsync(
        GetAllBasicParams parameters,
        CancellationToken ct)
    {
        var query =
            $"api/basics?pageNumber={parameters.PageNumber}&pageSize={parameters.PageSize}";

        return await _http.GetFromJsonAsync<PagedResult<BasicDto>>(query, ct)
            ?? throw new InvalidOperationException("Null response");
    }

    public async Task<BasicDto> GetByIdAsync(string id, CancellationToken ct)
    {
        return await _http.GetFromJsonAsync<BasicDto>($"api/basics/{id}", ct)
            ?? throw new InvalidOperationException("Null response");
    }

    public async Task<BasicDto> CreateAsync(
        CreateBasicParams parameters,
        CancellationToken ct)
    {
        var response = await _http.PostAsJsonAsync("api/basics", parameters, ct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<BasicDto>(ct)
            ?? throw new InvalidOperationException("Null response");
    }

    public async Task UpdateAsync(
        string id,
        UpdateBasicParams parameters,
        CancellationToken ct)
    {
        var response = await _http.PutAsJsonAsync($"api/basics/{id}", parameters, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string id, CancellationToken ct)
    {
        var response = await _http.DeleteAsync($"api/basics/{id}", ct);
        response.EnsureSuccessStatusCode();
    }
}
