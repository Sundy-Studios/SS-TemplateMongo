using System;
using System.Threading.Tasks;
using TemplateMongo.Client.Services;
using TemplateMongo.Client.Parameters;

public sealed class SomeClass
{
    private readonly IBasicService _service;

    public SomeClass(IBasicService service)
    {
        _service = service;
    }

    public async Task RunAsync()
    {
        var items = await _service.GetAllAsync(new GetAllBasicParams
        {
            PageNumber = 1,
            PageSize = 10
        });
        Console.WriteLine(items);
    }
}
