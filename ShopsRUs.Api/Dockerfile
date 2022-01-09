#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ShopsRUs.Api/ShopsRUs.Api.csproj", "ShopsRUs.Api/"]
RUN dotnet restore "ShopsRUs.Api/ShopsRUs.Api.csproj"
COPY . .
WORKDIR "/src/ShopsRUs.Api"
RUN dotnet build "ShopsRUs.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopsRUs.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopsRUs.Api.dll"]