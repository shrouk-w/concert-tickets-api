namespace kolosB.Models.DTOs;

public class InfoResponseDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<PurchaseResponseDTO> Purchases { get; set; }
}