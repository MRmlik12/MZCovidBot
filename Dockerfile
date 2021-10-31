FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet build -c Release -o /app --no-restore

WORKDIR /app

ENTRYPOINT [ "dotnet", "MZCovidBot.dll"]