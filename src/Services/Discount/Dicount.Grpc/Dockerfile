#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Discount/Dicount.Grpc/Dicount.Grpc.csproj", "Services/Discount/Dicount.Grpc/"]
RUN dotnet restore "Services/Discount/Dicount.Grpc/Dicount.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Dicount.Grpc"
RUN dotnet build "Dicount.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dicount.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dicount.Grpc.dll"]
