
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src


COPY OnlineGallery.csproj .
RUN dotnet restore "OnlineGallery.csproj"
COPY app.db .
COPY . .
RUN dotnet publish "OnlineGallery.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OnlineGallery.dll"]
