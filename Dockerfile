ENV EmailServer=127.0.0.1
ENV ConnectionString= Data Source=127.0.0.1,1500;Initial Catalog=Test.Database;

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]