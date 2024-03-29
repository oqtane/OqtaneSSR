using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OqtaneSSR.Client.Models;
using OqtaneSSR.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddSingleton(httpClient);

builder.Services.AddScoped<SiteState>();
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();

await builder.Build().RunAsync();
