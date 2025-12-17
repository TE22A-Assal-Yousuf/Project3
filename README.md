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

- Docker & Docker Compose installerad
- eller Visual Studio / .NET 7 SDK

### Kör med Docker

```bash
docker-compose up --build
```

Applikationen blir tillgänglig på `http://localhost:5000`

### Kör lokalt (utan Docker)

1. Installera SQL Server lokalt
2. Uppdatera connection string i `appsettings.json`
3. Kör migrations:
   ```bash
   dotnet ef database update
   ```
4. Starta appen:
   ```bash
   dotnet run
   ```

## Databasstruktur

### Tabeller

- **Customers**: Kundinformation (ID, Namn, Email)
- **Products**: Produktkatalog (ID, Namn, Pris, Lager)
- **Orders**: Beställningar (ID, KundID, Datum)
- **OrderItems**: Beställningsrader - Kopplingstabell för Many-to-Many (ID, BeställningID, ProduktID, Kvantitet, PrisVidKöp)

### Relationer

- En Kund kan ha många Beställningar (1:N)
- En Beställning kan ha många Produkter via OrderItems (Many:Many)
- En Produkt kan finnas på många Beställningar via OrderItems (Many:Many)

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

- **Server**: sql,1433
- **User**: sa
- **Password**: Password123!
- **Database**: OrderingSystem

⚠️ Byt lösenord i production!

## Filstruktur

```
BlazorApp1/
├── Data/
│   ├── Customer.cs
│   ├── Product.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   └── OrderingContext.cs
├── Migrations/
│   └── InitialCreate
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

1. Gå till Kunder och lägg till nya kunder
2. Gå till Produkter och lägg till eller se produkter
3. Gå till Beställningar och skapa nya beställningar
4. Systemet uppdaterar lagret automatiskt

---
**Utveckling**: 2025
