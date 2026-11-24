using System.ComponentModel.DataAnnotations;

namespace kolosB.Models.DTOs;

public class CustomerRequestDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string PhoneNumber { get; set; }
}