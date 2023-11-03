using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OqtaneSSR.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddSingleton(httpClient);

builder.Services.AddScoped<ITextService, TextService>();

await builder.Build().RunAsync();
