namespace TemplateMongo.Services.Isekai;

using TemplateMongo.Client.Services;

public class HealthService : IHealthService
{
    public Task GetHealth() => Task.FromResult("Health is good!");
}
