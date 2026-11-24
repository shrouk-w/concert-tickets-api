using System.ComponentModel.DataAnnotations.Schema;

namespace kolosB.Models;

public class Purchased_Ticket
{
    public int TicketConcertId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    [ForeignKey("TicketConcertId")]
    public Ticket_Concert TicketConcert { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}