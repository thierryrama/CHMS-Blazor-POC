using StatCan.Chms.Client;
using StatCan.Chms.Client.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SoloX.BlazorJsonLocalization;
using SoloX.BlazorJsonLocalization.WebAssembly;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddWebAssemblyJsonLocalization(
    builder => builder.UseEmbeddedJson()
);

builder.Services.AddCultureManager(options =>
{
    options.DefaultCulture = new CultureInfo("en-CA");
    options.SupportedCultures = new[] { new CultureInfo("en-CA"), new CultureInfo("fr-CA") };
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<AppState>();

var host = builder.Build();

await host.RunAsync();
