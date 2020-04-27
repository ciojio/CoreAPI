FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final

ENV EmailServer=127.0.0.1
ENV ConnectionString=User/ Id=scott;Password=12345;Data/ Source=192.168.137.1:1521/orcl;

WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]