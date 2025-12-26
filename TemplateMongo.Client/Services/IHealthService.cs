namespace TemplateMongo.Client.Services;

using System.Net;
using Common.Exception.Contracts;
using Common.Isekai.Attributes;
using Common.Isekai.Services;

[IsekaiGate("template-mongo-client", "health")]
[IsekaiResponse((int)HttpStatusCode.InternalServerError, typeof(ErrorResponse), "Internal server error")]
public interface IHealthService : IIsekaiService
{
    [IsekaiPath("api/health", IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeout(IsekaiMethodTimeout.Low)]
    [IsekaiResponse((int)HttpStatusCode.OK, null, "Health check successful")]
    public Task GetHealth();
}
