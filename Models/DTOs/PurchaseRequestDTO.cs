using System.ComponentModel.DataAnnotations;

namespace kolosB.Models.DTOs;

public class PurchaseRequestDTO
{
    [Required]
    public int SeatNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string ConcertName { get; set; }
    [Required]
    public decimal Price { get; set; }
}