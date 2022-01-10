# CHMS-Blazor-POC.Client
The front end client in ASP .NET 6 Blazor WASM.

## Added packages
Here are the packages that we added on top of the vanilla ASP .NET 6 Blazor WASM project:
1. **Microsoft.AspNetCore.WebUtilities**
   To have access to `QueryHelpers` to easily parse URIs. Might be a bit too much to add the whole library just for that though :)
2. **Microsoft.Extensions.Logging.Configuration**
   To be able to configure the logging levels.
3. **Radzen.Blazor**
   Blazor components -- includes the scheduler (calendar) component.
   https://blazor.radzen.com/
4. **SoloX.BlazorJsonLocalization.WebAssembly**
   Localization library using JSON files instead of the default embeded .resx file. This is necessary to support changing languages on the fly without reloading the application.
   https://github.com/xaviersolau/BlazorJsonLocalization
    1. The Blazor WASM framework only loads the resources for the current culture.
       When the culture is changed, it doesn't load the resources of the new culture. In fact, the Microsoft documented way to switch language is to reload the application. This has the unfortunate side effect of losing the app state that is memory.
  
       See ASP.NET Core Blazor globalization and localization, https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-6.0&pivots=webassembly
    1. On the other hand, SoloX.BlazorJsonLocalization.WebAssembly loads the resources for the new culture.
5. **StrawberryShake.CodeGeneration.CSharp.Analyzers**
   **StrawberryShake.Transport.Http**
   **Microsoft.Extensions.DependencyInjection**
   **Microsoft.Extensions.Http**
   The ChilliCream Strawberry Shake GraphQL client. It generates a client class from the GraphQL queries.
   https://chillicream.com/docs/strawberryshake

   Also required installing the `StrawberryShake.Tools` CLI tool locally.
   
    1. `.graphqlrc.json`, `schema.graphql`, `schema.extensions.graphql`
    Created by
       ```
       dotnet graphql init ...
       ```
    4. `GraphQL` folder contains the definition of GraphQL queries.
    The generated client library is based on them.
    5. When the schema changes on the server, the `schema.graphql` on the client side needs to be updated.
       ```
       dotnet graphql update
       ```