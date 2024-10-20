FROM mcr.microsoft.com/dotnet/sdk:8.0.204-bookworm-slim AS builder

WORKDIR /source
COPY PaymentGateway.sln .

COPY src/PaymentGateway.Api/PaymentGateway.Api.csproj src/PaymentGateway.Api/
COPY src/PaymentGateway.CrossCutting/PaymentGateway.CrossCutting.csproj src/PaymentGateway.CrossCutting/
COPY src/PaymentGateway.WebClients/PaymentGateway.WebClients.csproj src/PaymentGateway.WebClients/
COPY src/PaymentGateway.Infrastructure/PaymentGateway.Infrastructure.csproj src/PaymentGateway.Infrastructure/


COPY test/PaymentGateway.IntegrationTests/PaymentGateway.IntegrationTests.csproj test/PaymentGateway.IntegrationTests/
COPY test/PaymentGateway.UnitTests/PaymentGateway.UnitTests.csproj test/PaymentGateway.UnitTests/


RUN dotnet restore

COPY . .
RUN dotnet publish src/PaymentGateway.Api/PaymentGateway.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=builder /app .

ENV ASPNETCORE_URLS=http://+:80
CMD ["PaymentGateway.Api.dll"]

