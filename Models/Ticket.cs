using System.ComponentModel.DataAnnotations;

namespace kolosB.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [MaxLength(50)]
    public string SerialNumber { get; set; }
    public int SeatNumber { get; set; }
    
    public ICollection<Ticket_Concert> TicketConcerts { get; set; }
}