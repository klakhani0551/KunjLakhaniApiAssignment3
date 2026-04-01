
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src


COPY ["KunjLakhaniApi.csproj", "./"]
RUN dotnet restore "KunjLakhaniApi.csproj"

COPY . .
RUN dotnet publish "KunjLakhaniApi.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .


EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "KunjLakhaniApi.dll"]