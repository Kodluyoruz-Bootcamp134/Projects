FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim as build
WORKDIR /app

COPY src/Common/Base.Common/*.csproj Common/Base.Common/

COPY src/Projections/Base.Projections.UserService/*.csproj .
RUN dotnet restore 
COPY . .
RUN dotnet publish src/Projections/Base.Projections.UserService/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Base.Common.dll" ]

