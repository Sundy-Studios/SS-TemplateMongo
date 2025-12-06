using TemplateMongo.Dto;

namespace TemplateMongo.Models;

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
}