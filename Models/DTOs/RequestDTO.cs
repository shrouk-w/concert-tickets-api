using System.ComponentModel.DataAnnotations;

namespace kolosB.Models.DTOs;

public class RequestDTO
{
    [Required]
    public Customer Customer { get; set; }
    [Required]
    public List<PurchaseRequestDTO> Purchases { get; set; }
}