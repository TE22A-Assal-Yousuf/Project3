# Beställningssystem - Blazor med SQL Server i Docker

Ett förenklat e-handelsystem för att hantera kunder, produkter och beställningar.

## Features

- **Kundhantering**: Lägg till och visa kunder
- **Produkthantering**: Hantera produktlager och priser
- **Beställningshantering**: Skapa beställningar och se beställningshistorik
- **Lagerkontroll**: Automatisk minskning av lager vid beställning
- **3NF Databaskärna**: Normaliserad databasstruktur med PriceAtTimeOfPurchase för historiska priser

## Teknikstack

- **Frontend**: Blazor Server (C#)
- **Backend**: ASP.NET Core 7
- **Database**: SQL Server 2022
- **ORM**: Entity Framework Core 7
- **Container**: Docker & Docker Compose

## Snabbstart

### Förutsättningar

- Docker & Docker Compose (Windows: Docker Desktop)
- Eller: Visual Studio / .NET 7 SDK om du kör utan Docker

### Rekommenderat: Kör med Docker (utveckling)

Följande kommando bygger bilder och startar tjänsterna enligt `docker-compose.yml`.

PowerShell-exempel:

```powershell
# Starta i förgrunden (bra vid första körning)
docker-compose up --build

# Eller starta i bakgrunden (detta visar inte loggarna direkt)
docker-compose up --build -d
```

Applikationen exponeras på port `8000` i denna repo-konfiguration. Öppna i webbläsaren:

`http://localhost:8000`

Vill du rensa volumes och börja om:

```powershell
docker-compose down --volumes
docker-compose up --build -d
```

### Bygga om enskild tjänst

Om du gör ändringar i `BlazorApp1` och vill bygga om containern:

```powershell
docker-compose build blazor
docker-compose up -d
```

### Logs och felsökning

Visa senaste loggarna för blazor-tjänsten:

```powershell
docker-compose logs blazor --tail=200
```

Visa SQL Server-loggar:

```powershell
docker-compose logs sql --tail=200
```

Vanliga problem
- Om appen stänger anslutningen, kontrollera att Compose-miljöns connection string använder `Server=sql,1433` (hostnamn `sql` i compose-nätverket).
- Program.cs försöker köra migrations på uppstart (`db.Database.Migrate()`), så databasen skapas/uppdateras automatiskt vid start — kontrollera loggar om migrationerna misslyckas.
- Om du får SQL-login-fel, kontrollera `SA_PASSWORD` i `docker-compose.yml` och att containern är uppe.

### Kör lokalt utan Docker

1. Installera eller kör en SQL Server (lokalt eller fjärr).
2. Uppdatera `BlazorApp1/appsettings.json` så att `DefaultConnection` pekar mot din SQL Server (t.ex. `Server=localhost,1433;Database=OrderingSystem;User Id=sa;Password=...;TrustServerCertificate=true;Encrypt=false`).
3. Kör migrationer (valfritt — appen kör migreringar automatiskt om så är konfigurerat):

```powershell
cd BlazorApp1
dotnet ef database update
dotnet run
```

Appen startar på den port som Kestrel är konfigurerad för (standard i container: 80) men `dotnet run` kan exponera en annan port beroende på `launchSettings.json`.

## Databasstruktur

### Tabeller

- **Customers**: Kundinformation (ID, Namn, Email)
- **Products**: Produktkatalog (ID, Namn, Pris, Lager)
- **Orders**: Beställningar (ID, KundID, Datum, Total)
- **OrderItems**: Beställningsrader (ID, OrderId, ProductId, Quantity, PriceAtTimeOfPurchase)

### Relationer

- En Kund kan ha många Beställningar (1:N)
- En Beställning kan ha många OrderItems (1:N)
- En Produkt kan förekomma i många OrderItems (1:N från Product till OrderItem)

## Sidor

- **Hem**: Startsida med navigering
- **Kunder**: Visa och lägg till kunder
- **Produkter**: Visa och lägg till produkter
- **Beställningar**: Skapa beställningar, se historik, visa lagersaldo

## Standard Testdata

### Kunder
- Alice Johnson (alice@example.com)
- Bob Smith (bob@example.com)

### Produkter
- Laptop: 999,99 kr (10 i lager)
- Mouse: 29,99 kr (50 i lager)
- Keyboard: 79,99 kr (30 i lager)

## SQL Credentials (Docker)

- **Server**: `sql,1433` (Compose service `sql`)
- **User**: `sa`
- **Password**: `Password123!` (sätt i `docker-compose.yml`)
- **Database**: `OrderingSystem`

⚠️ Byt lösenord i production!

## Filstruktur (viktigaste delar)

```
BlazorApp1/
├── Data/
│   ├── Customer.cs
│   ├── Product.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   └── OrderingContext.cs
├── Migrations/
│   └── 20251216000000_InitialCreate
├── Pages/
│   ├── Customers.razor
│   ├── Products.razor
│   ├── Orders.razor
│   └── Index.razor
├── Shared/
│   └── NavMenu.razor
├── Program.cs
├── appsettings.json
├── BlazorApp1.csproj
└── Dockerfile
```

## Användning

1. Starta Docker (Docker Desktop)
2. Kör `docker-compose up --build -d`
3. Öppna `http://localhost:8000`
4. Lägg till kunder/produkter och skapa beställningar

---
**Utveckling**: 2025

file:///C:/Users/yousuf.assal/Downloads/diagram.svg