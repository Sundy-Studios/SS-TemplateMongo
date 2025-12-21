using System.Net;
using Common.Auth;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using TemplateMongo.Dao;
using TemplateMongo.Dao.Interfaces;
using TemplateMongo.Domains;
using TemplateMongo.Domains.Interfaces;
using TemplateMongo.Services;
using TemplateMongo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFirebaseAuth(builder.Configuration);

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
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your Firebase ID token, example: Bearer eyJhbGciOiJSUzI1NiIs..."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options => options.AddPolicy("DevCors", policy => policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()));
}

var app = builder.Build();

// Global Exception Handling Middleware
app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
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
    }));


if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFirebaseAuth();

app.MapControllers();

app.Run();
