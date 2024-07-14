# שלב 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# העתיקי את קובץ ה-solution והתקיני את התלויות
COPY *.sln ./
COPY Server/*.csproj ./Server/
COPY Dal/*.csproj ./Dal/
COPY BL/*.csproj ./BL/
RUN dotnet restore

# העתיקי את שאר קבצי הפרויקט ובני את הפרויקט
COPY . ./
WORKDIR /app/Server
RUN dotnet publish -c Release -o out

# שלב 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/Server/out ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "userLoginBackend.dll"]
