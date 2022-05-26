FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim as build
WORKDIR /app
EXPOSE 80

COPY src/Common/Base.Common/*.csproj Common/Base.Common/

COPY src/Api/Core/Base.Api.Domain/*.csproj Core/Base.Api.Domain/
COPY src/Api/Core/Base.Api.Application/*.csproj Core/Base.Api.Application/
COPY src/Api/Infrastructure/Base.Api.Infrastructure/*.csproj Infrastructure/Base.Api.Infrastructure/
COPY src/Api/Infrastructure/Base.Api.Persistence/*.csproj Infrastructure/Base.Api.Persistence/
COPY src/Api/Presentation/Base.Api/*.csproj Presentation/Base.Api/
RUN dotnet restore Presentation/Base.Api/*.csproj
COPY . .
RUN dotnet publish src/Api/Presentation/Base.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Base.Api.dll" ]

