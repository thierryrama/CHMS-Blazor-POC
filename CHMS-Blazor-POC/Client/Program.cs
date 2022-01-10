using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SoloX.BlazorJsonLocalization;
using SoloX.BlazorJsonLocalization.WebAssembly;
using StatCan.Chms.Client;
using StatCan.Chms.Client.Models;
using StatCan.Chms.Client.Services;
using StatCan.Chms.Client.ViewModels.Layout;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging")
);

builder.Services.AddWebAssemblyJsonLocalization(
    options => options.UseEmbeddedJson()
);

builder.Services.AddCultureManager(options =>
{
    options.DefaultCulture = new CultureInfo("en-CA");
    options.SupportedCultures = new[] { new CultureInfo("en-CA"), new CultureInfo("fr-CA") };
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services
    .AddChmsGraphQLClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress), "graphql"));

builder.Services.AddScoped<DialogService>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddSingleton<AppStateInitializer>();
builder.Services.AddSingleton<CycleService>();
builder.Services.AddTransient<SignedInUserViewModel>();
builder.Services.AddTransient<SiteSelectorViewModel>();
builder.Services.AddTransient<CurrentSiteViewModel>();

var host = builder.Build();

var appStateInitializer = host.Services.GetService<AppStateInitializer>();
await appStateInitializer.InitializeStateAsync();

await host.RunAsync();
