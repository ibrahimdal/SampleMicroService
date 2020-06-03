#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SampleMicroService.GateWay/SampleMicroService.GateWay.csproj", "SampleMicroService.GateWay/"]
RUN dotnet restore "SampleMicroService.GateWay/SampleMicroService.GateWay.csproj"
COPY . .
WORKDIR "/src/SampleMicroService.GateWay"
RUN dotnet build "SampleMicroService.GateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleMicroService.GateWay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleMicroService.GateWay.dll"]