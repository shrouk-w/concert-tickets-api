using System.ComponentModel.DataAnnotations;

namespace kolosB.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    public ICollection<Purchased_Ticket> PurchasedTickets;
}