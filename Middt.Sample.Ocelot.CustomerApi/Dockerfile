#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Middt.Sample.Ocelot.CustomerApi/Middt.Sample.Ocelot.CustomerApi.csproj", "Middt.Sample.Ocelot.CustomerApi/"]
COPY ["Middt.Sample.Ocelot.Common/Middt.Sample.Ocelot.Common.csproj", "Middt.Sample.Ocelot.Common/"]
RUN dotnet restore "Middt.Sample.Ocelot.CustomerApi/Middt.Sample.Ocelot.CustomerApi.csproj"
COPY . .
WORKDIR "/src/Middt.Sample.Ocelot.CustomerApi"
RUN dotnet build "Middt.Sample.Ocelot.CustomerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Middt.Sample.Ocelot.CustomerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Middt.Sample.Ocelot.CustomerApi.dll"]