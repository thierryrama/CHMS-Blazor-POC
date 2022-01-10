using Microsoft.AspNetCore.ResponseCompression;
using StatCan.Chms.DataTransfer.Booking;
using StatCan.Chms.QueryResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddGraphQLServer()
    .AddDocumentFromFile("schema.graphql")
    .BindRuntimeType<Query>();
    //.BindRuntimeType<Booking>();
    //.BindRuntimeType<AppointmentDetailData>();
builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();

// Register WebMVC controllers and GraphQL endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapControllers();
});

app.MapFallbackToFile("index.html");

app.Run();
