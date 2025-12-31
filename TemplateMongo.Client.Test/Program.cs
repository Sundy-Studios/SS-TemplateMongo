using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TemplateMongo.Client.Services;
using Common.Isekai.Client;
using Common.Isekai.Startup;

class Program
{
    static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddIsekaiClient<IBasicService>(new HttpClient { BaseAddress = new Uri("http://localhost:5070/") });

                services.AddTransient<SomeClass>();
            })
            .Build();

        var runner = host.Services.GetRequiredService<SomeClass>();
        await runner.RunAsync();
    }
}
