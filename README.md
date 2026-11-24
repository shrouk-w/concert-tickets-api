# Concert Tickets API

An academic C# API for concert-ticket purchases. It stores customers, concerts and tickets, retrieves purchase history and records new purchases. Built with ASP.NET Core and Entity Framework Core.

## Run

Requires .NET 8 or a newer SDK that can target .NET 8, SQL Server and the EF Core 8 CLI tool. Set `ConnectionStrings__DefaultConnection`, then run `dotnet restore`, `dotnet ef database update` and `dotnet run`. Includes Swagger and sample data. This is a classroom exercise with known rough edges, rather than a production ticketing service.
