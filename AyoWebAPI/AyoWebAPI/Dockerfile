FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AyoWebAPI/AyoWebAPI.csproj", "AyoWebAPI/"]
RUN dotnet restore "AyoWebAPI/AyoWebAPI.csproj"
COPY . .
WORKDIR "/src/AyoWebAPI"
RUN dotnet build "AyoWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AyoWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AyoWebAPI.dll"]