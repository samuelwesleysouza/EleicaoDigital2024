#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8008

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EleicaoDigital2024/EleicaoDigital2024.csproj", "EleicaoDigital2024/"]
COPY ["EleicaoDigital.Application/EleicaoDigital.Application.csproj", "EleicaoDigital.Application/"]
COPY ["EleicaoDigital.Repository/EleicaoDigital.Repository.csproj", "EleicaoDigital.Repository/"]
RUN dotnet restore "EleicaoDigital2024/EleicaoDigital2024.csproj"
COPY . .
WORKDIR "/src/EleicaoDigital2024"
RUN dotnet build "EleicaoDigital2024.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EleicaoDigital2024.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
EXPOSE 5000
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EleicaoDigital2024.dll"]