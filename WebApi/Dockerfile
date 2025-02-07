FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

WORKDIR /app

COPY ./WebApi ./WebApi

COPY ./Shared ./Shared

WORKDIR /app/WebApi

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS runtime

WORKDIR /App

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY --from=build-env /app/WebApi .

EXPOSE 8080
ENTRYPOINT [ "dotnet", "out/WebApi.dll" ]
