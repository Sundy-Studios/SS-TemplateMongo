using System.Net.Http.Json;
using System.Text.Json;
using Common.Paging;
using TemplateMongo.Client.Dto;
using TemplateMongo.Client.Parameters;

var baseUrl = args.Length > 0 ? args[0] : "http://localhost:5070";
using var client = new HttpClient { BaseAddress = new Uri(baseUrl) };

try
{
    Console.WriteLine("GetAll...");
    var all = await client.GetFromJsonAsync<PagedResult<BasicDto>>(
        "api/Basic"
    );
    Dump(all);

    Console.WriteLine("Create...");
    var createResponse = await client.PostAsJsonAsync(
        "api/Basic",
        new CreateBasicParams
        {
            Name = "ConsoleTest",
            Location = "Console",
            Date = DateTime.UtcNow
        }
    );
    createResponse.EnsureSuccessStatusCode();

    var created = await createResponse.Content.ReadFromJsonAsync<BasicDto>();
    Dump(created);

    var id = created!.Id!;

    Console.WriteLine("GetById...");
    Dump(await client.GetFromJsonAsync<BasicDto>($"api/Basic/{id}"));

    Console.WriteLine("Update...");
    var updateResponse = await client.PutAsJsonAsync(
        $"api/Basic/{id}",
        new UpdateBasicParams
        {
            Name = "UpdatedFromConsole",
            Location = "UpdatedLoc",
            Date = DateTime.UtcNow
        }
    );
    updateResponse.EnsureSuccessStatusCode();

    Console.WriteLine("GetById after update...");
    Dump(await client.GetFromJsonAsync<BasicDto>($"api/Basic/{id}"));

    Console.WriteLine("Delete...");
    var deleteResponse = await client.DeleteAsync($"api/Basic/{id}");
    deleteResponse.EnsureSuccessStatusCode();

    Console.WriteLine("GetById after delete (should fail)...");
    var afterDelete = await client.GetAsync($"api/Basic/{id}");
    Console.WriteLine($"Status: {(int)afterDelete.StatusCode}");

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

void Dump<T>(T? value) => Console.WriteLine(
        JsonSerializer.Serialize(
            value,
            new JsonSerializerOptions { WriteIndented = true }
        )
    );