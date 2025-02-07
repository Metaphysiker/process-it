using Shared.Dtos;
using WebApi.Factories;
using WebApi.Repositories;
using WebApi.Repositories.RepositoriesImpl;
using WebApi.Services.ServicesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DtoConverterFactory>();
builder.Services.AddScoped<ModelServiceFactory>();
builder.Services.AddScoped<AutoMapperService>();
builder.Services.AddDbContext<DatabaseContext>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
