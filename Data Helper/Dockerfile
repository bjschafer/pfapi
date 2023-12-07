FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Data Helper/Data Helper.csproj", "Data Helper/"]
RUN dotnet restore "Data Helper/Data Helper.csproj"
COPY . .
WORKDIR "/src/Data Helper"
RUN dotnet build "Data Helper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Data Helper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Data Helper.dll"]
