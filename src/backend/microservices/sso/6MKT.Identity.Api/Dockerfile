#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./backend/microservices/sso/6MKT.Identity.Api/6MKT.Identity.Api.csproj", "microservices/sso/6MKT.Identity.Api/"]
COPY ["./backend/common/6MKT.Common/6MKT.Common.csproj", "common/6MKT.Common/"]
COPY ["./backend/microservices/sso/6MKT.Identity.Domain/6MKT.Identity.Domain.csproj", "microservices/sso/6MKT.Identity.Domain/"]
COPY ["./backend/microservices/sso/6MKT.Identity.Infra/6MKT.Identity.Infra.csproj", "microservices/sso/6MKT.Identity.Infra/"]
RUN dotnet restore "microservices/sso/6MKT.Identity.Api/6MKT.Identity.Api.csproj"
COPY . .
WORKDIR "./backend/microservices/sso/6MKT.Identity.Api"
RUN dotnet build "6MKT.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "6MKT.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "6MKT.Identity.Api.dll"]