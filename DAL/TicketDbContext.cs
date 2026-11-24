using kolosB.Models;
using Microsoft.EntityFrameworkCore;

namespace kolosB.DAL;

public class TicketDbContext :DbContext
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Ticket_Concert> Ticket_Concerts { get; set; }
    public DbSet<Purchased_Ticket> Purchased_Tickets { get; set; }
    
    protected TicketDbContext()
    {
    }

    public TicketDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Purchased_Ticket>()
            .HasKey(p => new { p.CustomerId, p.TicketConcertId });

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { SeatNumber = 1, SerialNumber = "123", TicketId = 1 },
            new Ticket { SeatNumber = 10, SerialNumber = "121233", TicketId = 2 }
        );

        modelBuilder.Entity<Concert>().HasData(
            new Concert { ConcertId = 1, Date = new DateTime(10), Name = "aaaaaaaa", AvailableTickets = 170}
        );

        modelBuilder.Entity<Ticket_Concert>().HasData(
            new Ticket_Concert{ ConcertId = 1, TicketConcertId = 1, TicketId = 1, Price = 1800},
            new Ticket_Concert{ ConcertId = 1, TicketConcertId = 2, TicketId = 2, Price = 2}
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer(){CustomerId = 1, FirstName = "skibid", LastName = "Toileten", PhoneNumber = "123456789"}
        );

        modelBuilder.Entity<Purchased_Ticket>().HasData(
            new Purchased_Ticket(){TicketConcertId = 1, CustomerId = 1, PurchaseDate = new DateTime(900)},
            new Purchased_Ticket(){TicketConcertId = 2, CustomerId = 1, PurchaseDate = new DateTime(900)}
            
        );
    }
}