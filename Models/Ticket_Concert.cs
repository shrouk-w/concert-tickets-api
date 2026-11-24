using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolosB.Models;

public class Ticket_Concert
{
    [Key]
    public int TicketConcertId { get; set; }
    public int TicketId { get; set; }
    public int ConcertId { get; set; }
    public decimal Price { get; set; }
    
    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; }
    [ForeignKey("ConcertId")]
    public Concert Concert { get; set; }
    
    public ICollection<Purchased_Ticket> PurchasedTickets { get; set; }
}