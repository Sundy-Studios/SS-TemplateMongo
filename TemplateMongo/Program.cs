using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using TemplateMongo.Dao;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Domains;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services;
using TemplateMongo.Services.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// MongoDB
var mongoClient = new MongoClient(builder.Configuration["MongoDb:ConnectionString"]);
var mongoDatabase = mongoClient.GetDatabase(builder.Configuration["MongoDb:DatabaseName"]);
builder.Services.AddSingleton(mongoDatabase);

// Services
builder.Services.AddScoped<IBasicService, BasicService>();

// Domains
builder.Services.AddScoped<IBasicDomain, BasicDomain>();

// Dao
builder.Services.AddScoped<IBasicDao, BasicDao>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "X-Api-Key",
        Description = "API Key Authentication"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

WebApplication app = builder.Build();

// Global Exception Handling Middleware
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var feature = context.Features.Get<IExceptionHandlerFeature>();
        if (feature is null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { error = "Unknown error" });
            return;
        }

        var ex = feature.Error;

        context.Response.StatusCode = ex switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            OperationCanceledException => (int)HttpStatusCode.RequestTimeout,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = new
        {
            error = ex.Message,
            type = ex.GetType().Name,
            stackTrace = app.Environment.IsDevelopment() ? ex.StackTrace : null
        };

        await context.Response.WriteAsJsonAsync(response);
    });
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
