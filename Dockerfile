FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app

ENV EmailServer=127.0.0.1
ENV ConnectionString=Data\ Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=MyHost)(PORT=MyPort))(CONNECT_DATA=(SERVICE_NAME=MyOracleSID)));User\ Id=myUsername;Password=myPassword;

COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]