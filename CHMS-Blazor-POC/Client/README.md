# CHMS-Blazor-POC.Client
The front end client in ASP .NET 6 Blazor WASM.

## Added packages
Here are the packages that we added on top of the vanilla ASP .NET 6 Blazor WASM project:
1. ### ASP.NET Core utilities
   ```
   dotnet add package Microsoft.AspNetCore.WebUtilities
   ```
   To have access to `QueryHelpers` to easily parse URIs. Might be a bit too much to add the whole package just for that though. :)
2. ### Configuration support for Microsoft.Extensions.Logging
   ```
   dotnet add package Microsoft.Extensions.Logging.Configuration
   ```
   To be able to configure the logging levels.
   #### Code setup
   1. In `Program.cs`:
      ```c#
      builder.Logging.AddConfiguration(
        builder.Configuration.GetSection("Logging")
      );
      ```
   2. Create `appsettings.json` under the `wwwroot` folder.
      ```json
      {
        "Logging": {
          "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning",
            "SoloX.BlazorJsonLocalization" : "Error"
          }
        }
      }
      ```
   3. Create `appsettings.Development.json` under the `wwwroot` folder.
      ```json
      {
        "Logging": {
          "LogLevel": {
            "Default": "Information",
            "StatCan.Chms.Client": "Debug",
            "Microsoft.AspNetCore": "Warning",
            "SoloX.BlazorJsonLocalization" : "Error"
          }
        }
      }
      ```
3. ### Radzen Blazor Components
   https://blazor.radzen.com/
   ```
   dotnet add package Radzen.Blazor
   ```
   Blazor components which includes the scheduler (calendar) component.
   #### Code setup
    1. In `Program.cs`:
       ```c#
       builder.Services.AddScoped<DialogService>();
       ```
    2. In `_Imports.razor`:
       ```
       @using Radzen
       @using Radzen.Blazor
       ```
    3. In `Mainlayout.razor`:
       ```html
       <RadzenDialog />
       ```
4. ### Blazor JSON Localization
   https://github.com/xaviersolau/BlazorJsonLocalization
   ```
   dotnet add package SoloX.BlazorJsonLocalization.WebAssembly
   ```
   Localization library using JSON files instead of the default embedded `.resx` file. This is necessary to support changing languages on the fly without reloading the application.
   
    1. The Blazor WASM framework only loads the resources for the current culture.

       When the culture is changed, it doesn't load the resources of the new culture. In fact, the Microsoft documented way to switch language is to reload the application. This has the unfortunate side effect of losing the app state that is memory.
  
       See ASP.NET Core Blazor globalization and localization, https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-6.0&pivots=webassembly
    2. On the other hand, `SoloX.BlazorJsonLocalization.WebAssembly` loads the resources for the new culture.
    3. When adding a new language file (`Component-[en|fr].json`), it must be:
       1. an embedded resource
       2. and removed from content
          ```
          <ItemGroup>
            <Content Remove="Components\Layout\CultureSelector-en.json" />
            <EmbeddedResource Include="Components\Layout\CultureSelector-en.json" />
            ...
          </ItemGroup>
          ```
       3. To nest the language files under the Razor component file in the IDE.
          1. For Visual Studio, create a `.filenesting.json` in the project folder.
             ```json
             {
               "help": "https://go.microsoft.com/fwlink/?linkid=866610",
               "dependentFileProviders": {
                 "add": {
                   "fileSuffixToExtension": {
                     "add": {
                       "-en.json": [
                         ".razor",
                         ".cs"
                       ],
                       "-fr.json": [
                         ".razor",
                         ".cs"
                       ]
                     }
                   }
                 }
               }
             }
             ```
          2. For JetBrains Rider, see https://www.jetbrains.com/help/rider/File_Nesting_Dialog.html
   #### Code setup
   In `Program.cs`:
   ```c#
   builder.Services.AddWebAssemblyJsonLocalization(
    options => options.UseEmbeddedJson()
   );
   ```
5. ### Strawberry Shake
   https://chillicream.com/docs/strawberryshake
   ```
   dotnet add package StrawberryShake.Transport.Http
   dotnet add package StrawberryShake.CodeGeneration.CSharp.Analyzers
   dotnet add package Microsoft.Extensions.DependencyInjection 
   dotnet add package Microsoft.Extensions.Http 
   ```
   ```
   dotnet new tool-manifest
   dotnet tool install StrawberryShake.Tools --local
   ```
   The ChilliCream Strawberry Shake GraphQL client. It generates a client class from the GraphQL queries.
   
    1. `.graphqlrc.json`, `schema.graphql`, `schema.extensions.graphql`
       ```
       dotnet graphql init https://localhost:7123/graphql/ -n ChmsGraphQLClient
       ```
       1. `.graphqlrc.json` is the configuration file of the code generator.
       
          Specify the namespace:
          ```
          ...
          "extensions": {
              "strawberryShake": {
              "name": "ChmsGraphQLClient",
              "namespace" : "StatCan.Chms.Client.GraphQL",
          ...
          ```
       2. `schema.graphql`, `schema.extensions.graphql` are the schema downloaded from the server.
       3. When the schema changes on the server, the `schema.graphql` on the client side needs to be updated.
          ```
          dotnet graphql update
          ```
          However, since we use schema first development on the server, it's easier to just copy the schema from the server code.
    2. The `GraphQL` folder contains the definition of GraphQL queries.
   
       The generated client library implements them.
    #### Code setup
    1. In `CHMS-Blazor-POC.Client.csproj`:
       
       If using Jetbrains Rider, the generated client code conflicts with the Roslyn injected code. We have to instruct Rider to ignore the generated code.
       ```
       <ItemGroup>
         <Compile Remove="Generated\ChmsGraphQLClient.StrawberryShake.cs" Condition="'$(BuildingByReSharper)' == 'true'" />
       </ItemGroup>
       ```
    3. In `Program.cs`:
       ```c#
       builder.Services
         .AddChmsGraphQLClient()
         .ConfigureHttpClient(client => client.BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress), "graphql"));
       ```
    4. The `ChmsGraphQLClient` object will be available from the DI container.