namespace TemplateMongo.Models;

using TemplateMongo.Dto;
using TemplateMongo.Parameters;

public class BasicModel
{
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime Date { get; set; }

    public static BasicModel FromDto(BasicDto dto)
    {
        if (dto == null)
        {
            return null;
        }

        return new BasicModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Location = dto.Location,
            Date = dto.Date
        };
    }

    public static BasicDto ToDto(BasicModel model)
    {
        if (model == null)
        {
            return null;
        }

        return new BasicDto
        {
            Id = model.Id,
            Name = model.Name,
            Location = model.Location,
            Date = model.Date
        };
    }

    public static BasicModel FromParams(CreateBasicParams parameters)
    {
        if (parameters == null)
        {
            return null!;
        }

        return new BasicModel
        {
            Name = parameters.Name,
            Location = parameters.Location,
            Date = parameters.Date
        };
    }

    public static BasicModel FromParams(string id, UpdateBasicParams parameters)
    {
        if (parameters == null)
        {
            return null!;
        }

        return new BasicModel
        {
            Id = id,
            Name = parameters.Name,
            Location = parameters.Location,
            Date = parameters.Date
        };
    }
}
