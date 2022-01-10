#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CHMS-Blazor-POC/Server/CHMS-Blazor-POC.Server.csproj", "CHMS-Blazor-POC/Server/"]
COPY ["CHMS-Blazor-POC/Client/CHMS-Blazor-POC.Client.csproj", "CHMS-Blazor-POC/Client/"]
COPY ["CHMS-Blazor-POC/Shared/CHMS-Blazor-POC.Shared.csproj", "CHMS-Blazor-POC/Shared/"]
RUN dotnet restore "CHMS-Blazor-POC/Server/CHMS-Blazor-POC.Server.csproj"
COPY . .
WORKDIR "/src/CHMS-Blazor-POC/Server"
RUN dotnet build "CHMS-Blazor-POC.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CHMS-Blazor-POC.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Statcan.Chms.Server.dll"]