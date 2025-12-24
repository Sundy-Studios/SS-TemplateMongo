using Common.Attributes.Isekai;
using Common.Services.Isekai;

namespace TemplateMongo.Client.Services;

[IsekaiGateAttribute("template-mongo-client", "health")]
public interface IHealthService : IIsekaiService
{
    [IsekaiPath("api/health", Common.Attributes.Isekai.IsekaiHttpMethod.Get)]
    [IsekaiMethodTimeoutAttribute(IsekaiMethodTimeout.Low)]
    Task Get();
}