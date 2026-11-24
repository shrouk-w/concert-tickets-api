using kolokwiumA.Exceptions;
using kolosB.DAL;
using kolosB.Models;
using kolosB.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolosB.Services;

public class CustomerService : ICustomerService
{
    
    private readonly TicketDbContext _DbContext;

    public CustomerService(TicketDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task<InfoResponseDTO> GetInfoForCustomerAsync(int customerId, CancellationToken token)
    {
        if (customerId <= 0)
            throw new BadRequestException("Invalid customer id");
        
        var customer = await _DbContext.Customers.FindAsync(customerId, token);
        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }

        var response = new InfoResponseDTO
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber
        };

        var purchases = await _DbContext.Purchased_Tickets.Where(p => p.CustomerId == customerId).ToListAsync(token);
        var purchasesToAdd = new List<PurchaseResponseDTO>();

        foreach (var purchasedTicket in purchases)
        {
            var temp = new PurchaseResponseDTO
            {
                Date = purchasedTicket.PurchaseDate,
                Price = await _DbContext.Ticket_Concerts
                    .Where(p => p.TicketConcertId == purchasedTicket.TicketConcertId).Select(p => p.Price)
                    .FirstOrDefaultAsync(token),
            };
            var ticket = await _DbContext.Tickets.FindAsync(purchasedTicket.TicketConcertId);
            var concert = await _DbContext.Ticket_Concerts
                .Where(p => p.TicketConcertId == purchasedTicket.TicketConcertId).Select(p => p.Concert)
                .FirstOrDefaultAsync(token);
            temp.Ticket = new TicketResponseDTO()
            {
                Serial = ticket.SerialNumber,
                SeatNumber = ticket.SeatNumber
            };
            temp.Concert = new ConcertResponseDTO()
            {
                Date = concert.Date,
                Name = concert.Name
            };
            
            purchasesToAdd.Add(temp);

        }
        response.Purchases = purchasesToAdd;

        return response;
    }

    public async Task InsertCustomerAndPurchasesAsync(RequestDTO request, CancellationToken token)
    {
        using (var transaction = await _DbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var customer = await _DbContext.Customers.FindAsync(request.Customer.CustomerId, token);
                if (customer == null)
                {
                    customer = new Customer()
                    {
                        //CustomerId = request.Customer.CustomerId,
                        FirstName = request.Customer.FirstName,
                        LastName = request.Customer.LastName,
                        PhoneNumber = request.Customer.PhoneNumber,
                    };
                    
                    await _DbContext.Customers.AddAsync(
                        customer,
                        token);
                    
                    await _DbContext.SaveChangesAsync(token);
                    
                }

                if (request.Purchases.Count > 5)
                    throw new BadRequestException("Cannot have more than 5 purchases");
                
                foreach (var purchasedTicket in request.Purchases)
                {
                    var concert = await _DbContext.Concerts.Where(p=>p.Name == purchasedTicket.ConcertName).FirstOrDefaultAsync(token);
                    if (concert == null)
                        throw new NotFoundException("Concert not found");

                    var ticket = new Ticket()
                    {
                        SeatNumber = purchasedTicket.SeatNumber,
                        SerialNumber = "",
                        //TicketId = await _DbContext.Tickets.Select(p => p.TicketId).MaxAsync(token) + 1,
                    };
                    
                    await _DbContext.Tickets.AddAsync(ticket, token);
                    
                    await _DbContext.SaveChangesAsync(token);

                    var ticketconert = new Ticket_Concert()
                    {
                        //TicketConcertId = await _DbContext.Ticket_Concerts.Select(p => p.TicketConcertId).MaxAsync(token) + 1,
                        TicketId = ticket.TicketId,
                        ConcertId = concert.ConcertId,
                        Price = purchasedTicket.Price,
                    };
                    
                    await _DbContext.Ticket_Concerts.AddAsync(ticketconert, token);
                    
                    await _DbContext.SaveChangesAsync(token);

                    await _DbContext.Purchased_Tickets.AddAsync(
                        new Purchased_Ticket()
                        {
                            TicketConcertId = ticketconert.TicketConcertId,
                            CustomerId = customer.CustomerId,
                            PurchaseDate = DateTime.Now
                        }
                        , token);
                    
                    await _DbContext.SaveChangesAsync(token);
                    
                }
                
                await _DbContext.SaveChangesAsync(token);

                await transaction.CommitAsync(token);

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }
    }
}