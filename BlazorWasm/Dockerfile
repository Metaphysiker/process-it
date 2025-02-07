FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app
COPY ./BlazorWasm ./BlazorWasm

COPY ./Shared ./Shared

WORKDIR /app/BlazorWasm

RUN dotnet publish -c Release -o output

ARG API_BASE_URL
RUN sed -i "s|http://localhost:8081/|${API_BASE_URL}|g" output/wwwroot/appsettings.json

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/BlazorWasm/output/wwwroot .
COPY ./BlazorWasm/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
