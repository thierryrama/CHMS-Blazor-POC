using System.Reflection;
using StatCan.Chms.QueryResolvers;
using Path = System.IO.Path;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen
(
    options =>
    {
        // Add support for Nullable Reference Types but Swashbuckle still differentiate between Non Nullable and Required.
        //   - Non Nullable means that if the key is present in the document, its value will not be null.
        //   - Required means that the key must be in the document.
        // See https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1686
        options.SupportNonNullableReferenceTypes();
        
        // Add support XML comments 
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
);
// Learn more about ChilliCream Hot Chocolate GraphQL server at https://chillicream.com/docs/hotchocolate
builder.Services.AddGraphQLServer()
    .AddDocumentFromFile("schema.graphql")
    .BindRuntimeType<Query>();

builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
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
