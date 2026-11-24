namespace kolosB.Models.DTOs;

public class PurchaseResponseDTO
{
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public TicketResponseDTO Ticket { get; set; }
    public ConcertResponseDTO Concert { get; set; }
}