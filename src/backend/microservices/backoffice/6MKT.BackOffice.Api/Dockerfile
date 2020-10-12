#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./backend/microservices/backoffice/6MKT.BackOffice.Api/6MKT.BackOffice.Api.csproj", "microservices/backoffice/6MKT.BackOffice.Api/"]
COPY ["./backend/microservices/backoffice/6MKT.BackOffice.Infra/6MKT.BackOffice.Infra.csproj", "microservices/backoffice/6MKT.BackOffice.Infra/"]
COPY ["./backend/microservices/backoffice/6MKT.BackOffice.Domain/6MKT.BackOffice.Domain.csproj", "microservices/backoffice/6MKT.BackOffice.Domain/"]
RUN dotnet restore "microservices/backoffice/6MKT.BackOffice.Api/6MKT.BackOffice.Api.csproj"
COPY . .
WORKDIR "./backend/microservices/backoffice/6MKT.BackOffice.Api"
RUN dotnet build "6MKT.BackOffice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "6MKT.BackOffice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "6MKT.BackOffice.Api.dll"]