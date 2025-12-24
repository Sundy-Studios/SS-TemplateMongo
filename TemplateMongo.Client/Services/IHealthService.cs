namespace TemplateMongo.Client.Services;

using Common.Attributes.Isekai;
using Common.Services.Isekai;

[IsekaiGate("template-mongo-client", "health")]
public interface IHealthService : IIsekaiService
{
    [IsekaiPath("api/health", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Low)]
    public Task GetHealth();
}
