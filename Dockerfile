FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ENV EmailServer: 127.0.0.1
ENV ConnectionString: Server=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe.oracle.docker)));direct=true;User\ Id=system;Password=oracle;

WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]