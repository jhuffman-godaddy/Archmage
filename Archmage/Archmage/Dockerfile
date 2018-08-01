FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60163
EXPOSE 44374

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Archmage/Archmage.csproj Archmage/
RUN dotnet restore Archmage/Archmage.csproj
COPY . .
WORKDIR /src/Archmage
RUN dotnet build Archmage.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Archmage.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Archmage.dll"]
