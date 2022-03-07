using System.Globalization;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Radzen;
using SoloX.BlazorJsonLocalization;
using SoloX.BlazorJsonLocalization.WebAssembly;
using StatCan.Chms.Client;
using StatCan.Chms.Client.Models;
using StatCan.Chms.Client.OpenApi;
using StatCan.Chms.Client.OpenApi.ViewModels.CalendarToastUI;
using StatCan.Chms.Client.Services;
using StatCan.Chms.Client.Store.CultureSelection;
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
builder.Services.AddHttpClient<ChmsOpenApiClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

//Radzen
builder.Services.AddScoped<DialogService>();

//MudBlazor
builder.Services.AddMudServices();

builder.Services.AddSingleton<AppState>();
builder.Services.AddSingleton<AppStateInitializer>();
builder.Services.AddSingleton<CycleService>();
builder.Services.AddTransient<SignedInUserViewModel>();
builder.Services.AddTransient<SiteSelectorViewModel>();
builder.Services.AddTransient<CurrentSiteViewModel>();
builder.Services.AddTransient<CalendarViewModel>();

// Add the following
var currentAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options => options
    .ScanAssemblies(currentAssembly)
    .UseRouting()
    .UseReduxDevTools()
    .UseCultureSelection()
);

var host = builder.Build();

var appStateInitializer = host.Services.GetRequiredService<AppStateInitializer>();
await appStateInitializer.InitializeStateAsync();


await host.RunAsync();
