FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["eMentorUserServices/eMentorUserServices.csproj", "eMentorUserServices/"]
COPY ["eMentor.DBContext/eMentor.DBContext.csproj", "eMentor.DBContext/"]
COPY ["eMentor.Common/eMentor.Common.csproj", "eMentor.Common/"]
COPY ["eMentor.Entities/eMentor.Entities.csproj", "eMentor.Entities/"]
RUN dotnet restore "eMentorUserServices/eMentorUserServices.csproj"
COPY . .
WORKDIR "/src/eMentorUserServices"
RUN dotnet build "eMentorUserServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eMentorUserServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eMentorUserServices.dll"]