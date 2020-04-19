FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ENV EmailServer=127.0.0.1
ENV ConnectionString=ServerONE

WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]