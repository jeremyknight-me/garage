#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JK.Garage.Web/JK.Garage.Web.csproj", "JK.Garage.Web/"]
COPY ["JK.Garage.Common/JK.Garage.Common.csproj", "JK.Garage.Common/"]
COPY ["JK.Garage.Data.Sqlite/JK.Garage.Data.Sqlite.csproj", "JK.Garage.Data.Sqlite/"]
RUN dotnet restore "JK.Garage.Web/JK.Garage.Web.csproj"
COPY . .
WORKDIR "/src/JK.Garage.Web"
RUN dotnet build "JK.Garage.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JK.Garage.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JK.Garage.Web.dll"]