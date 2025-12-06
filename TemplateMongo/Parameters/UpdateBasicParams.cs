using TemplateMongo.Dto;

namespace TemplateMongo.Parameters;

public class UpdateBasicParams
{
    public string Id { get; set; } = string.Empty;
    public BasicDto Basic { get; set; } = default!;
}
