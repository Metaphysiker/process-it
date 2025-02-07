using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environmentVariables = new EnvironmentVariables();
environmentVariables.API_BASE_URL = builder.Configuration["API_BASE_URL"] ?? "http://localhost:8081/";

builder.Services.AddScoped(sp =>
{
    return environmentVariables;
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<BackendHttpClient, BackendHttpClient>();
builder.Services.AddScoped<Currenty>();

await builder.Build().RunAsync();
